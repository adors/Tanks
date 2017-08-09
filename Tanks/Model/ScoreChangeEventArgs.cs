using System;
using System.Collections.Generic;
using System.Text;

namespace Tanks.MVC
{
    public class ScoreChangeEventArgs : EventArgs
    {
        private int score;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public ScoreChangeEventArgs(int score) : base()
        {
            this.score = score;
        }
    }
}
