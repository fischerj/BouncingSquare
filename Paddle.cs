using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BouncingSquare
{
    public class Paddle
    {
        #region Private Members
        private Form _form = null;
        private PictureBox _box = null;
        private Random _rnd = null;
        #endregion

        #region Public Properties
        public Keys Key
        {
           set
            {
                if (value==Keys.Left)
                {
                    //GETS THE CURRENT LOCATION OF THE PADDLE
                    Point location = _box.Location;
                    //MODIFYING THE LOCAL VARIABLE X
                    location.X -= 10;
                    //TESTING IF THE PADDLE SHOULD BE MOVED
                    if (location.X >= 0)
                    {
                        //MOVES THE PADDLE
                        _box.Location = location;
                    }
                    else
                    {
                        location.X = 0;
                        _box.Location = location;
                    }
                    
                }
                else if (value == Keys.Right)
                {
                    Point location = _box.Location;
                    location.X += 10;
                    if (location.X <= _form.Width-_box.Width-10)
                    {
                        //MOVES THE PADDLE
                        _box.Location = location;
                    }
                    else
                    {
                        location.X = _form.Width - _box.Width - 10;
                        _box.Location = location;
                    }
                }
            }
        }

        public PictureBox Box
        {
            get { return _box; }
        }
        /// <summary>
        /// RECEIVES THE X-COORDINATE FROM THE FORM
        /// OF WHERE THE MOUSE IS LOCATED
        /// </summary>
        public int Location
        {
            set
            {
                Point location = _box.Location;
                location.X = value;
                _box.Location = location;
            }

        }
        #endregion

        #region  Private Methods 

        #endregion

        #region  Public Methods 

        #endregion

        #region  Public Events 

        #endregion

        #region  Public Event Handlers 

        #endregion

        #region Construction 
        public Paddle(Form frm, Random rnd)
        {
            //CREATE A NEW INSTANCE OF THE PICTURE BOX
            _box = new PictureBox();
            //SET THE LOCAL VARIABLE FROM THE FORM OBJECT
            _form = frm;
            _rnd = rnd;
            Size size = new Size(100, 5);
            _box.Size = size;
            int x = (_form.Width/2)-(_box.Width/2);
            int y = _form.Height - _box.Height-25;
            Point location = new Point(x, y);
            _box.Location = location;
            _box.BackColor = Color.White;
            _form.Controls.Add(_box);
        }
        #endregion

    }
}
