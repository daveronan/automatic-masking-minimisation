using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;

namespace DeMaskingLT
{
    public partial class PerceivedEmotion : Form
    {

        System.Media.SoundPlayer _player = new System.Media.SoundPlayer();
        private Logging _logger;

        private String _track1FileName = "C:\\Users\\David\\Desktop\\PO-12 Samples\\PO-12 Mix - Not Cut.wav";
        private String _track2FileName = "C:\\Users\\David\\Desktop\\PO-12 Samples\\PO-12 Techno Loop 1.wav";

        private bool _mix1played = false;
        private bool _mix2played = false;

        private Stopwatch _stopWatchListenToSong = new Stopwatch();

        ExperimentData _experimentData = new ExperimentData();

        private String _participantName = String.Empty;

        private int _testNumber = 0;

        public PerceivedEmotion()
        {
            InitializeComponent();
        }

        public PerceivedEmotion(String name)
        {
            InitializeComponent();
            _experimentData.NameOfParticipant = name;
        }

        private void CheckSubmitButton()
        {
            if (_mix1played && _mix2played)
            {
                buttonSubmit.Enabled = true;
            }
        }

        private void AssignSliders()
        {
            _track1FileName = _experimentData.Songs[_testNumber][0];
            _track2FileName = _experimentData.Songs[_testNumber][1];

            trackBarMix1Arousal.Value = 0;
            trackBarMix2Arousal.Value = 0;
            trackBarMix1Valence.Value = 0;
            trackBarMix2Valence.Value = 0;
            trackBarMix1Tension.Value = 0;
            trackBarMix2Tension.Value = 0;

            _mix1played = false;
            _mix2played = false;
            
        }

        private void PlayMusic(String audioFile)
        {
            _player.Stop();
            _player.SoundLocation = audioFile;
            _player.Play();
        }

        #region Events
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            _player.Stop();

            foreach (ToolStripStatusLabel label in statusStrip1.Items)
            {
                label.Text = "";
            }

            _stopWatchListenToSong.Stop();
            TimeSpan ts = _stopWatchListenToSong.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            Result currentResult = new Result(_experimentData.NameOfParticipant, elapsedTime, 
                new EmotionScore(Path.GetFileName(_track1FileName), trackBarMix1Arousal.Value, trackBarMix1Valence.Value, trackBarMix1Tension.Value), 
                new EmotionScore(Path.GetFileName(_track2FileName), trackBarMix2Arousal.Value, trackBarMix2Valence.Value, trackBarMix2Tension.Value));

            _logger.WriteEmotionData(currentResult);

            if (_testNumber == 4)
            {
                ThankYou thankYouDialog = new ThankYou("Thank you for taking part in this experiment.");
                    // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (thankYouDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of testDialog's TextBox.

                }
                _player.Stop();
                _logger.CloseFile();
                this.Close();
                Application.Exit(null);
            }
            else
            {
                ThankYou thankYouDialog = new ThankYou();
                    // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (thankYouDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of testDialog's TextBox.

                }

                _testNumber++;
                int songNum = _testNumber + 1;
                this.Text = "Perceived Emotion Experiment - Song " + songNum.ToString();
                AssignSliders();

                _stopWatchListenToSong.Reset();
                _stopWatchListenToSong.Start();

                buttonSubmit.Enabled = false;
            }
        }

        private void buttonPlayMix1_Click(object sender, EventArgs e)
        {
            timerStatusBar.Interval = 33000;
            timerStatusBar.Start();
            _mix1played = true;
            CheckSubmitButton();
            backgroundWorkerPlayAudio_DoWork(buttonPlayMix1, null);
        }

        private void buttonStopMix1_Click(object sender, EventArgs e)
        {
            _player.Stop();

            foreach (ToolStripStatusLabel label in statusStrip1.Items)
            {
                label.Text = "";
            }
        }

        private void buttonPlayMix2_Click(object sender, EventArgs e)
        {
            timerStatusBar.Interval = 33000;
            timerStatusBar.Start();
            _mix2played = true;
            CheckSubmitButton();
            backgroundWorkerPlayAudio_DoWork(buttonPlayMix2, null);
        }

        private void buttonStopMix2_Click(object sender, EventArgs e)
        {
            _player.Stop();

            foreach (ToolStripStatusLabel label in statusStrip1.Items)
            {
                label.Text = "";
            }
        }

        private void trackBarMix1Arousal_ValueChanged(object sender, EventArgs e)
        {
            textBoxMix1Arousal.Text = trackBarMix1Arousal.Value.ToString();
        }

        private void trackBarMix1Valence_ValueChanged(object sender, EventArgs e)
        {
            textBoxMix1Valence.Text = trackBarMix1Valence.Value.ToString();
        }

        private void trackBarMix1Tension_ValueChanged(object sender, EventArgs e)
        {
            textBoxMix1Tension.Text = trackBarMix1Tension.Value.ToString();
        }

        private void trackBarMix2Arousal_ValueChanged(object sender, EventArgs e)
        {
            textBoxMix2Arousal.Text = trackBarMix2Arousal.Value.ToString();
        }

        private void trackBarMix2Valence_ValueChanged(object sender, EventArgs e)
        {
            textBoxMix2Valence.Text = trackBarMix2Valence.Value.ToString();
        }

        private void trackBarMix2Tension_ValueChanged(object sender, EventArgs e)
        {
            textBoxMix2Tension.Text = trackBarMix2Tension.Value.ToString();
        }

        private void PerceivedEmotion_Load(object sender, EventArgs e)
        {
            CenterToScreen();

            //Create log file for Data
            _logger = new Logging(_experimentData.NameOfParticipant + "_PEResults.txt", ",");

            string path = Directory.GetCurrentDirectory();
            path = path + "\\EmotionFiles.txt";

            List<String> audioFiles = new List<string>();

            try
            {
                using (var sr = new StreamReader(path))
                {
                    var reader = new CsvReader(sr);

                    while (true)
                    {
                        reader.Configuration.HasHeaderRecord = false;
                        var row = reader.Read();
                        if (reader.CurrentRecord == null)
                        {
                            break;
                        }
                        audioFiles.Add(reader.CurrentRecord[0]);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw;
            }

            int songIndex = 0;
            foreach (var pathAudio in audioFiles)
            {

                ExperimentData expdata = new ExperimentData();
                string[] fileEntries = Directory.GetFiles(pathAudio, "*.wav");

                foreach (string fileName in fileEntries)
                {

                    _experimentData.Songs[songIndex].Add(fileName);

                }

                songIndex++;
            }

            //Randomise Everyting for the experiment
            var rnd = new Random();
            _experimentData.Song1Mixes = _experimentData.Song1Mixes.OrderBy(x => rnd.Next()).ToList();
            rnd = new Random();
            _experimentData.Song2Mixes = _experimentData.Song2Mixes.OrderBy(x => rnd.Next()).ToList();
            rnd = new Random();
            _experimentData.Song3Mixes = _experimentData.Song3Mixes.OrderBy(x => rnd.Next()).ToList();
            rnd = new Random();
            _experimentData.Song4Mixes = _experimentData.Song4Mixes.OrderBy(x => rnd.Next()).ToList();
            rnd = new Random();
            _experimentData.Song5Mixes = _experimentData.Song5Mixes.OrderBy(x => rnd.Next()).ToList();

            rnd = new Random();
            _experimentData.Songs = _experimentData.Songs.OrderBy(x => rnd.Next()).ToList();

            int songNum = _testNumber + 1;
            this.Text = "Perceived Emotion Experiment - Song " + songNum;

            AssignSliders();

            _stopWatchListenToSong.Reset();
            _stopWatchListenToSong.Start();
        }

        private void backgroundWorkerPlayAudio_DoWork(object sender, DoWorkEventArgs e)
        {
            if (sender.Equals(buttonPlayMix1))
            {
                foreach (ToolStripStatusLabel label in statusStrip1.Items)
                {
                    label.Text = "Mix 1 is now playing";
                }

                PlayMusic(_track1FileName);

            }
            else if (sender.Equals(buttonPlayMix2))
            {
                foreach (ToolStripStatusLabel label in statusStrip1.Items)
                {
                    label.Text = "Mix 2 is now playing";
                }

                PlayMusic(_track2FileName);

            }
        }

        private void timerStatusBar_Tick(object sender, EventArgs e)
        {
            timerStatusBar.Stop();
            foreach (ToolStripStatusLabel label in statusStrip1.Items)
            {
                label.Text = "";
            }
        }

        private void PerceivedEmotion_FormClosing(object sender, FormClosingEventArgs e)
        {
            _player.Stop();
            _logger.CloseFile();
        }
    } 
        #endregion
}
