using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMaskingLT
{
    class ExperimentData
    {
        private List<String> _song1Mixes = new List<string>();
        private List<String> _song2Mixes = new List<string>();
        private List<String> _song3Mixes = new List<string>();
        private List<String> _song4Mixes = new List<string>();
        private List<String> _song5Mixes = new List<string>();

        private List<List<String>> _songs = new List<List<String>>();

        private String _nameOfParticipant = String.Empty; 

        public ExperimentData()
        {
            _songs.Add(_song1Mixes);
            _songs.Add(_song2Mixes);
            _songs.Add(_song3Mixes);
            _songs.Add(_song4Mixes);
            _songs.Add(_song5Mixes);
        }

        public List<List<String>> Songs
        {
            get { return _songs; }
            set { _songs = value; }
        }

        public List<string> Song1Mixes
        {
            get { return _song1Mixes; }
            set { _song1Mixes = value; }
        }

        public List<string> Song2Mixes
        {
            get { return _song2Mixes; }
            set { _song2Mixes = value; }
        }

        public List<string> Song3Mixes
        {
            get { return _song3Mixes; }
            set { _song3Mixes = value; }
        }

        public List<string> Song4Mixes
        {
            get { return _song4Mixes; }
            set { _song4Mixes = value; }
        }

        public List<string> Song5Mixes
        {
            get { return _song5Mixes; }
            set { _song5Mixes = value; }
        }

        public string NameOfParticipant
        {
            get { return _nameOfParticipant; }
            set { _nameOfParticipant = value; }
        }
    }
}
