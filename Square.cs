using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BouncingSquare
{
    public class Square: IDisposable
    {
        #region Private Members
        private Guid _id = Guid.Empty;
        private Form _form = null;
        private PictureBox _box = null;
        private Timer _timer = null;
        private int _xDir = 0;
        private int _yDir = 0;
        private Random _rnd = null;
        private Paddle _paddle = null;
        private Label _lblScore = null;
        private int _Value = 0;

        #endregion

        #region Public Properties
        public PictureBox Box
        {
            get { return _box; }
        }
        public int xDir
        {
            get { return _xDir; }
            set {_xDir=value; }
        }
        public int yDir
        {   
            get { return _yDir; }
            set { _yDir = value; }
        }
        public Guid Id
        {
            get { return _id; }
        }
        #endregion

        #region Public Methods
        public void SetBackGround()
        {
            _box.BackColor = Color.Black;
        }
        #endregion

        #region Private Methods
        private void Move()
        {
            Point location = _box.Location;
            location.X += _xDir;
            location.Y += _yDir;
            _box.Location = location;
            if (location.Y >= _form.Height - _box.Height)
            {
                Dispose();
                //change the score
                int score = Convert.ToInt32(_lblScore.Text);
                score -= _Value;
                _lblScore.Text = score.ToString();
            }
            else if (location.Y <= 0)
            {
                _yDir = -_yDir;
            }
            else if (location.X >= _form.Width - _box.Width)
            {
                _xDir = -_xDir;
            }
            else if (location.X <= 0)
            {
                _xDir = -_xDir;
            }
            else if (_paddle.Box.Bounds.IntersectsWith(_box.Bounds))
            {
                _yDir = -_yDir;
                //change the score
                int score = Convert.ToInt32(_lblScore.Text);
                score += _Value;
                _lblScore.Text = score.ToString();
            }
        }
        #endregion

        #region Event Handlers
        private void _timer_Tick(object sender, EventArgs e)
        {
            Move();
        }

        #endregion

        #region Construction
        public Square(Form frm, 
                      Random rnd, Paddle paddle, Label lbl)
        {
           
            _Value = rnd.Next(0, 6);
            _lblScore = lbl;
            _paddle = paddle;
            _rnd = rnd; 
            _form = frm;
            _box = new PictureBox();

            _box.Paint += _box_Paint;

            _box.Width = 20;
            _box.Height = 20;

            _box.BackColor = Color.White;
            //_box.BackColor = Color.FromArgb(
            //    _rnd.Next(0, 256), 
            //    _rnd.Next(0, 256), 
            //    _rnd.Next(0, 256));

            Point location = new Point();
            location.X = _rnd.Next(0, _form.Width-_box.Width);
            location.Y = _rnd.Next(0, _form.Height - _box.Height);
            _box.Location = location;

            _timer = new Timer();
            _timer.Interval = 1;
            _timer.Enabled = true;
            _timer.Tick += _timer_Tick;
            do
            {
                _xDir = rnd.Next(-5, 6);
            } while (_xDir == 0);

            do
            {
                _yDir = rnd.Next(-5, 6);
            } while (_yDir == 0);
            

            _form.Controls.Add(_box);

            _id = Guid.NewGuid();
        }

        private void _box_Paint(object sender, PaintEventArgs e)
        {
            using (Font myFont = new Font("Arial", 14, FontStyle.Bold))
            {
                e.Graphics.DrawString(_Value.ToString(), 
                    myFont, Brushes.Green, new Point(2, 0));
            }
        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _timer.Enabled = false;
                    _box.Dispose();
                    _form.Controls.Remove(_box);
                    _form = null;
                    _rnd = null; 
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Square() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
