using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMaskingLT
{
    public struct MixScore
    {
        public string FileName;
        public int Score;

        public MixScore(string p1, int p2)
        {
            FileName = p1;
            Score = p2;
        }
    }

    public struct EmotionScore
    {
        public string FileName;
        public int ArousalScore;
        public int ValenceScore;
        public int TensionScore;

        public EmotionScore(string p1, int arousal, int valence, int tension)
        {
            FileName = p1;
            ArousalScore = arousal;
            ValenceScore = valence;
            TensionScore = tension;
        }
    }

    class Result
    {
        private String _particpantName = String.Empty;
        private String _timeSpentListening = String.Empty;
        private MixScore _mixScore1 = new MixScore();
        private MixScore _mixScore2 = new MixScore();
        private MixScore _mixScore3 = new MixScore();
        private MixScore _mixScore4 = new MixScore();
        private MixScore _mixScore5 = new MixScore();

        private EmotionScore _emotionScore1 = new EmotionScore();
        private EmotionScore _emotionScore2 = new EmotionScore();

        private int _mix1TimesSliderMoved = 0;
        private int _mix2TimesSliderMoved = 0;
        private int _mix3TimesSliderMoved = 0;
        private int _mix4TimesSliderMoved = 0;
        private int _mix5TimesSliderMoved = 0;

        public Result(String name, String time, 
            MixScore score1, int mix1TimesMoved, 
            MixScore score2, int mix2TimesMoved, 
            MixScore score3, int mix3TimesMoved, 
            MixScore score4, int mix4TimesMoved, 
            MixScore score5, int mix5TimesMoved)
        {
            _particpantName = name;
            _timeSpentListening = time;
            _mixScore1 = score1;
            _mixScore2 = score2;
            _mixScore3 = score3;
            _mixScore4 = score4;
            _mixScore5 = score5;

            _mix1TimesSliderMoved = mix1TimesMoved;
            _mix2TimesSliderMoved = mix2TimesMoved;
            _mix3TimesSliderMoved = mix3TimesMoved;
            _mix4TimesSliderMoved = mix4TimesMoved;
            _mix5TimesSliderMoved = mix5TimesMoved;
        }

        public Result(String name, String time, EmotionScore score1, EmotionScore score2)
        {
            _particpantName = name;
            _timeSpentListening = time;
            _emotionScore1 = score1;
            _emotionScore2 = score2;
        }

        public Result()
        {

        }


        public string ParticpantName
        {
            get { return _particpantName; }
            set { _particpantName = value; }
        }

        public MixScore MixScore1
        {
            get { return _mixScore1; }
            set { _mixScore1 = value; }
        }

        public MixScore MixScore2
        {
            get { return _mixScore2; }
            set { _mixScore2 = value; }
        }

        public MixScore MixScore3
        {
            get { return _mixScore3; }
            set { _mixScore3 = value; }
        }

        public MixScore MixScore4
        {
            get { return _mixScore4; }
            set { _mixScore4 = value; }
        }

        public MixScore MixScore5
        {
            get { return _mixScore5; }
            set { _mixScore5 = value; }
        }

        public string TimeSpentListening
        {
            get { return _timeSpentListening; }
            set { _timeSpentListening = value; }
        }

        public int Mix1TimesSliderMoved
        {
            get { return _mix1TimesSliderMoved; }
            set { _mix1TimesSliderMoved = value; }
        }

        public int Mix2TimesSliderMoved
        {
            get { return _mix2TimesSliderMoved; }
            set { _mix2TimesSliderMoved = value; }
        }

        public int Mix3TimesSliderMoved
        {
            get { return _mix3TimesSliderMoved; }
            set { _mix3TimesSliderMoved = value; }
        }

        public int Mix4TimesSliderMoved
        {
            get { return _mix4TimesSliderMoved; }
            set { _mix4TimesSliderMoved = value; }
        }

        public int Mix5TimesSliderMoved
        {
            get { return _mix5TimesSliderMoved; }
            set { _mix5TimesSliderMoved = value; }
        }

        public EmotionScore EmotionScore1
        {
            get { return _emotionScore1; }
            set { _emotionScore1 = value; }
        }

        public EmotionScore EmotionScore2
        {
            get { return _emotionScore2; }
            set { _emotionScore2 = value; }
        }
    }
}
