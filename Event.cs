using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncingSquare
{
    public class ScoreEventArgs
    {
        private string message= string.Empty;
        private int _points = 0;

        public ScoreEventArgs(string s, int points)
        {
            message = s;
            _points = points;
        }
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }      
        public int Points
        {
            get
            {
                return _points;
            }
            set
            {
                _points = value;

            }
        }
    }
    public class Event
    {
        public delegate void SquareEventHandler(object sender, 
            ScoreEventArgs e);

        public event SquareEventHandler score;

        protected void RaiseEvent(object sender, 
            ScoreEventArgs e)
        {
            SquareEventHandler evt = score;
            if (evt != null)
            {
                evt(sender, e);
            }
        }
    }
}
