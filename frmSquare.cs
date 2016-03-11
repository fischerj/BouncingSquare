using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncingSquare
{
    public partial class frmSquare : Form
    {
        Random rnd = new Random();
        Paddle paddle = null;
        public frmSquare()
        {
            InitializeComponent();
            this.KeyDown += FrmSquare_KeyDown;
            this.Load += FrmSquare_Load;
            this.MouseMove += FrmSquare_MouseMove;
            Cursor.Hide();
        }

        private void FrmSquare_MouseMove(object sender, 
            MouseEventArgs e)
        {
            paddle.Location = e.Location.X;
        }

        private void FrmSquare_Load(object sender, EventArgs e)
        {
            paddle = new Paddle(this, rnd);
        }

        private void FrmSquare_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Escape)
            {
                Application.Exit(); 
            }
            else if (e.KeyData == Keys.N)
            {
                Square square = new Square(this, rnd, paddle, lblScore);
            }
            else if (e.KeyData == Keys.Left ||
                     e.KeyData == Keys.Right)
            {
                paddle.Key = e.KeyData;
            }
        }
    }
}
