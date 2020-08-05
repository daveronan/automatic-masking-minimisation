using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeMaskingLT
{
    class Logging
    {
        private StreamWriter _pCsvFile = null;
        private String _delimeter = ",";
        private Boolean _firstWrite = true;

        public Logging(String fileName, String delimeter)
        {
            _delimeter = delimeter;
            try
            {
                _pCsvFile = new StreamWriter(fileName, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save to CSV",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public void WriteLTData(Result data)
        {
            //Write header
            if (_firstWrite)
            {
                _pCsvFile.Write(
                    "Participant Name" + _delimeter
                    + "Time Elapsed" + _delimeter
                    + "Mix 1" + _delimeter
                    + "Score" + _delimeter
                    + "Times Fader Moved" + _delimeter
                    + "Mix 2" + _delimeter
                    + "Score" + _delimeter
                    + "Times Fader Moved" + _delimeter
                    + "Mix 3" + _delimeter
                    + "Score" + _delimeter
                    + "Times Fader Moved" + _delimeter
                    + "Mix 4" + _delimeter
                    + "Score" + _delimeter
                    + "Times Fader Moved" + _delimeter
                    + "Mix 5" + _delimeter
                    + "Score" + _delimeter
                    + "Times Fader Moved" + _delimeter);
                _pCsvFile.WriteLine();
                _firstWrite = false;
            }

            _pCsvFile.Write(
                data.ParticpantName + _delimeter
                + data.TimeSpentListening + _delimeter
                + data.MixScore1.FileName + _delimeter
                + data.MixScore1.Score + _delimeter
                + data.Mix1TimesSliderMoved + _delimeter
                + data.MixScore2.FileName + _delimeter
                + data.MixScore2.Score + _delimeter
                + data.Mix2TimesSliderMoved + _delimeter
                + data.MixScore3.FileName + _delimeter
                + data.MixScore3.Score + _delimeter
                + data.Mix3TimesSliderMoved + _delimeter
                + data.MixScore4.FileName + _delimeter
                + data.MixScore4.Score + _delimeter
                + data.Mix4TimesSliderMoved + _delimeter
                + data.MixScore5.FileName + _delimeter
                + data.MixScore5.Score + _delimeter
                + data.Mix5TimesSliderMoved + _delimeter);
            _pCsvFile.WriteLine();

        }

        public void WriteEmotionData(Result data)
        {
            //Write header
            if (_firstWrite)
            {
                _pCsvFile.Write(
                    "Participant Name" + _delimeter
                    + "Time Elapsed" + _delimeter
                    + "Mix 1" + _delimeter
                    + "Arousal Score" + _delimeter
                    + "Valence Score" + _delimeter
                    + "Tension Score" + _delimeter
                    + "Mix 2" + _delimeter
                    + "Arousal Score" + _delimeter
                    + "Valence Score" + _delimeter
                    + "Tension Score" + _delimeter);
                _pCsvFile.WriteLine();
                _firstWrite = false;
            }

            _pCsvFile.Write(
                data.ParticpantName + _delimeter
                + data.TimeSpentListening + _delimeter
                + data.EmotionScore1.FileName + _delimeter
                + data.EmotionScore1.ArousalScore + _delimeter
                + data.EmotionScore1.ValenceScore + _delimeter
                + data.EmotionScore1.TensionScore + _delimeter
                + data.EmotionScore2.FileName + _delimeter
                + data.EmotionScore2.ArousalScore + _delimeter
                + data.EmotionScore2.ValenceScore + _delimeter
                + data.EmotionScore2.TensionScore + _delimeter);
            _pCsvFile.WriteLine();

        }


        public void CloseFile()
        {
            if (_pCsvFile != null)
            {
                _pCsvFile.Close();
            }
        }
    }
    
}
