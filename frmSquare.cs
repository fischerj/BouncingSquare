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

        List<Square> squares = new List<Square>();

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
            if (e.KeyData == Keys.Escape)
            {
                Application.Exit();
            }
            else if (e.KeyData == Keys.N)
            {
                if (squares.Count < 6)
                { 
                    Square square = new Square(this, rnd, paddle);
                    squares.Add(square);
                    square.score += Square_score;
                }
            }
            else if (e.KeyData == Keys.Left ||
                     e.KeyData == Keys.Right)
            {
                paddle.Key = e.KeyData;
            }
        }

        private void Square_score(object sender, 
            ScoreEventArgs e)
        {
            int score = Convert.ToInt32(lblScore.Text);
            score += e.Points;
            lblScore.Text = score.ToString();

            if (e.Points <= 0)
            {
                Square sq = (Square)sender;
                Guid id = sq.Id;
                for (int i = 0; i < squares.Count; i++)
                {
                    if (squares[i].Id == id)
                    {
                        squares.RemoveAt(i);
                        break;
                    }
                }
            }
        }
    }
}
