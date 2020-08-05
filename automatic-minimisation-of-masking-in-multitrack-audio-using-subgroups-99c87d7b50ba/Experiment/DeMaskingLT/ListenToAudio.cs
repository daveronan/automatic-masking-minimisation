using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CsvHelper;

namespace DeMaskingLT
{
    public partial class ListenToAudio : Form
    {
        System.Media.SoundPlayer _player = new System.Media.SoundPlayer();
        private PerceivedEmotion _perceivedEmotion;
        
        private String _track1FileName = "C:\\Users\\David\\Desktop\\PO-12 Samples\\PO-12 Mix - Not Cut.wav";
        private String _track2FileName = "C:\\Users\\David\\Desktop\\PO-12 Samples\\PO-12 Techno Loop 1.wav";
        private String _track3FileName = "C:\\Users\\David\\Desktop\\PO-12 Samples\\PO-12 Techno Loop 2.wav";
        private String _track4FileName = "C:\\Users\\David\\Desktop\\PO-12 Samples\\PO-12 Techno Loop 3.wav";
        private String _track5FileName = "C:\\Users\\David\\Desktop\\PO-12 Samples\\PO-12 Techno Loop 4.wav";

        ExperimentData _experimentData = new ExperimentData();
        List<Result> _results = new List<Result>();
        private Logging _logger;

        private bool _track1Played = false;
        private bool _track2Played = false;
        private bool _track3Played = false;
        private bool _track4Played = false;
        private bool _track5Played = false;

        private Stopwatch _stopWatchListenToSong = new Stopwatch();

        private int _track1TimesMoved = 0;
        private int _track2TimesMoved = 0;
        private int _track3TimesMoved = 0;
        private int _track4TimesMoved = 0;
        private int _track5TimesMoved = 0;

        private int _track1CurrentValue = 0;
        private int _track2CurrentValue = 0;
        private int _track3CurrentValue = 0;
        private int _track4CurrentValue = 0;
        private int _track5CurrentValue = 0;

        private int _testNumber = 4;

        public ListenToAudio()
        {
            InitializeComponent();
        }

        private void trackBarTrack1_ValueChanged(object sender, EventArgs e)
        {
            textBoxTrack1.Text = trackBarTrack1.Value.ToString();
        }

        private void trackBarTrack2_ValueChanged(object sender, EventArgs e)
        {
            textBoxTrack2.Text = trackBarTrack2.Value.ToString();
        }

        private void trackBarTrack3_ValueChanged(object sender, EventArgs e)
        {
            textBoxTrack3.Text = trackBarTrack3.Value.ToString();
        }

        private void trackBarTrack4_ValueChanged(object sender, EventArgs e)
        {
            textBoxTrack4.Text = trackBarTrack4.Value.ToString();
        }

        private void trackBarTrack5_ValueChanged(object sender, EventArgs e)
        {
            textBoxTrack5.Text = trackBarTrack5.Value.ToString();
        }

        private void backgroundWorkerAudio_DoWork(object sender, DoWorkEventArgs e)
        {
            if (sender.Equals(buttonPlayTrack1))
            {
                foreach (ToolStripStatusLabel label in statusStrip1.Items)
                {
                    label.Text = "Mix 1 is now playing";
                }

                PlayMusic(_track1FileName);

            }
            else if (sender.Equals(buttonPlayTrack2))
            {
                foreach (ToolStripStatusLabel label in statusStrip1.Items)
                {
                    label.Text = "Mix 2 is now playing";
                }

                PlayMusic(_track2FileName);

            }
            else if (sender.Equals(buttonPlayTrack3))
            {
                foreach (ToolStripStatusLabel label in statusStrip1.Items)
                {
                    label.Text = "Mix 3 is now playing";
                }

                PlayMusic(_track3FileName);
            }
            else if (sender.Equals(buttonPlayTrack4))
            {
                foreach (ToolStripStatusLabel label in statusStrip1.Items)
                {
                    label.Text = "Mix 4 is now playing";
                }

                PlayMusic(_track4FileName);

            }
            else if (sender.Equals(buttonPlayTrack5))
            {
                foreach (ToolStripStatusLabel label in statusStrip1.Items)
                {
                    label.Text = "Mix 5 is now playing";
                }
                    
                PlayMusic(_track5FileName);
            }
        }

        private void PlayMusic(String audioFile)
        {
            _player.Stop();
            _player.SoundLocation = audioFile;
            _player.Play();
        }

        private void trackBarTrack1_MouseDown(object sender, MouseEventArgs e)
        {
            CheckSumbitButtonEnabled();
            backgroundWorkerAudio_DoWork(trackBarTrack1, null);
        }

        private void trackBarTrack2_MouseDown(object sender, MouseEventArgs e)
        {
            CheckSumbitButtonEnabled();
            backgroundWorkerAudio_DoWork(trackBarTrack2, null);
        }

        private void trackBarTrack3_MouseDown(object sender, MouseEventArgs e)
        {
            CheckSumbitButtonEnabled();
            backgroundWorkerAudio_DoWork(trackBarTrack3, null);
        }

        private void trackBarTrack4_MouseDown(object sender, MouseEventArgs e)
        {
            CheckSumbitButtonEnabled();
            backgroundWorkerAudio_DoWork(trackBarTrack4, null);
        }

        private void trackBarTrack5_MouseDown(object sender, MouseEventArgs e)
        {
            CheckSumbitButtonEnabled();
            backgroundWorkerAudio_DoWork(trackBarTrack5, null);
        }

        private void CheckSumbitButtonEnabled()
        {
            if (_track1Played && _track2Played && _track3Played && _track4Played && _track5Played)
            {
                buttonSubmit.Enabled = true;
            }
        }

        private void ListenToAudio_Load(object sender, EventArgs e)
        {

            this.CenterToScreen();

            Name nameDialog = new Name();
            String currentUser = String.Empty;
            String testType = String.Empty;

            this.Hide();
            nameDialog.ShowDialog(this);

            if (nameDialog.radioButtonTestA.Checked)
            {
                testType = "A";
                textBoxTestInstructions.Text = "Please rate the mixes in terms of your own overall preference.";
            }
            else if (nameDialog.radioButtonTestB.Checked)
            {
                testType = "B";
                textBoxTestInstructions.Text = "Please rate the mixes in terms of the ability to distinguish the sources (i.e. the lack of masking).";
            }

            nameDialog.ShowDialog(this);

            _experimentData.NameOfParticipant = nameDialog.tbName.Text;

            nameDialog.ShowDialog(this);

            //Create log file for Data
            _logger = new Logging(testType + "_" + _experimentData.NameOfParticipant + "_LTResults.txt", ",");


            string path = Directory.GetCurrentDirectory();
            path = path + "\\Files.txt";

            List <String> audioFiles = new List<string>();

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
                string [] fileEntries = Directory.GetFiles(pathAudio, "*.wav");

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
            this.Text = "Experiment - Song " + songNum.ToString();

            AssignSliders();

            _stopWatchListenToSong.Reset();
            _stopWatchListenToSong.Start();
        }

        private void AssignSliders()
        {
            //TODO: Put in the real mixes and run the fuckin experiment.
            _track1FileName = _experimentData.Songs[_testNumber][0];
            _track2FileName = _experimentData.Songs[_testNumber][1];
            _track3FileName = _experimentData.Songs[_testNumber][2];
            _track4FileName = _experimentData.Songs[_testNumber][3];
            _track5FileName = _experimentData.Songs[_testNumber][4];

            Random rnd = new Random();
            trackBarTrack1.Value = rnd.Next(0, 100);
            trackBarTrack2.Value = rnd.Next(0, 100);
            trackBarTrack3.Value = rnd.Next(0, 100);
            trackBarTrack4.Value = rnd.Next(0, 100);
            trackBarTrack5.Value = rnd.Next(0, 100);

            _track1CurrentValue = trackBarTrack1.Value;
            _track2CurrentValue = trackBarTrack2.Value;
            _track3CurrentValue = trackBarTrack3.Value;
            _track4CurrentValue = trackBarTrack4.Value;
            _track5CurrentValue = trackBarTrack5.Value;

            _track1Played = false;
            _track2Played = false;
            _track3Played = false;
            _track4Played = false;
            _track5Played = false;

            _track1TimesMoved = 0;
            _track2TimesMoved = 0;
            _track3TimesMoved = 0;
            _track4TimesMoved = 0;
            _track5TimesMoved = 0;
            
        }

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
                new MixScore(Path.GetFileName(_track1FileName), trackBarTrack1.Value), _track1TimesMoved,
                new MixScore(Path.GetFileName(_track2FileName), trackBarTrack2.Value), _track2TimesMoved,
                new MixScore(Path.GetFileName(_track3FileName), trackBarTrack3.Value), _track3TimesMoved,
                new MixScore(Path.GetFileName(_track4FileName), trackBarTrack4.Value), _track4TimesMoved, 
                new MixScore(Path.GetFileName(_track5FileName), trackBarTrack5.Value), _track5TimesMoved);
            _results.Add(currentResult);

            _logger.WriteLTData(currentResult);

            if (_testNumber == 4)
            {
                ThankYou thankYouDialog = new ThankYou("Thank you for taking part in this part of the experiment. Please continue to the next section.");           // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (thankYouDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of testDialog's TextBox.

                }
                _logger.CloseFile();
                _perceivedEmotion = new PerceivedEmotion(_experimentData.NameOfParticipant);
                _perceivedEmotion.Show(this);
                this.Hide();
            }
            else
            {
                ThankYou thankYouDialog = new ThankYou();           // Show testDialog as a modal dialog and determine if DialogResult = OK.
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

        private void buttonPlayTrack1_Click(object sender, EventArgs e)
        {
            _track1Played = true;
            CheckSumbitButtonEnabled();
            timerStatusBar.Interval = 33000;
            timerStatusBar.Start();
            backgroundWorkerAudio_DoWork(buttonPlayTrack1, null);
        }

        private void buttonPlayTrack2_Click(object sender, EventArgs e)
        {
            _track2Played = true;
            CheckSumbitButtonEnabled();
            timerStatusBar.Interval = 33000;
            timerStatusBar.Start();
            backgroundWorkerAudio_DoWork(buttonPlayTrack2, null);
        }

        private void buttonPlayTrack3_Click(object sender, EventArgs e)
        {
            _track3Played = true;
            CheckSumbitButtonEnabled();
            timerStatusBar.Interval = 33000;
            timerStatusBar.Start();
            backgroundWorkerAudio_DoWork(buttonPlayTrack3, null);
        }

        private void buttonPlayTrack4_Click(object sender, EventArgs e)
        {
            _track4Played = true;
            CheckSumbitButtonEnabled();
            timerStatusBar.Interval = 33000;
            timerStatusBar.Start();
            backgroundWorkerAudio_DoWork(buttonPlayTrack4, null);
        }

        private void buttonPlayTrack5_Click(object sender, EventArgs e)
        {
            _track5Played = true;
            CheckSumbitButtonEnabled();
            timerStatusBar.Interval = 33000;
            timerStatusBar.Start();
            backgroundWorkerAudio_DoWork(buttonPlayTrack5, null);
        }

        private void buttonStopTrack1_Click(object sender, EventArgs e)
        {
            _player.Stop();

            foreach (ToolStripStatusLabel label in statusStrip1.Items)
            {
                label.Text = "";
            }
        }

        private void buttonStopTrack2_Click(object sender, EventArgs e)
        {
            _player.Stop();

            foreach (ToolStripStatusLabel label in statusStrip1.Items)
            {
                label.Text = "";
            }
        }

        private void buttonStopTrack3_Click(object sender, EventArgs e)
        {
            _player.Stop();

            foreach (ToolStripStatusLabel label in statusStrip1.Items)
            {
                label.Text = "";
            }
        }

        private void buttonStopTrack4_Click(object sender, EventArgs e)
        {
            _player.Stop();

            foreach (ToolStripStatusLabel label in statusStrip1.Items)
            {
                label.Text = "";
            }
        }

        private void buttonStopTrack5_Click(object sender, EventArgs e)
        {
            _player.Stop();

            foreach (ToolStripStatusLabel label in statusStrip1.Items)
            {
                label.Text = "";
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
        
        private void trackBarTrack1_MouseUp(object sender, MouseEventArgs e)
        {
            
            if (trackBarTrack1.Value != _track1CurrentValue)
            {
                _track1TimesMoved++;
            }

            _track1CurrentValue = trackBarTrack1.Value;
        }

        private void trackBarTrack2_MouseUp(object sender, MouseEventArgs e)
        {
            
            if (trackBarTrack2.Value != _track2CurrentValue)
            {
                _track2TimesMoved++;
            }

            _track2CurrentValue = trackBarTrack2.Value;
        }

        private void trackBarTrack3_MouseUp(object sender, MouseEventArgs e)
        {
            
            if (trackBarTrack3.Value != _track3CurrentValue)
            {
                _track3TimesMoved++;
            }

            _track3CurrentValue = trackBarTrack3.Value;
        }

        private void trackBarTrack4_MouseUp(object sender, MouseEventArgs e)
        {
            
            if (trackBarTrack4.Value != _track4CurrentValue)
            {
                _track4TimesMoved++;
            }

            _track4CurrentValue = trackBarTrack4.Value;
        }

        private void trackBarTrack5_MouseUp(object sender, MouseEventArgs e)
        {
            
            if (trackBarTrack5.Value != _track5CurrentValue)
            {
                _track5TimesMoved++;
            }

            _track5CurrentValue = trackBarTrack5.Value;
        }

        private void ListenToAudio_FormClosing(object sender, FormClosingEventArgs e)
        {
            _player.Stop();
            _logger.CloseFile();
        }
    }
}
