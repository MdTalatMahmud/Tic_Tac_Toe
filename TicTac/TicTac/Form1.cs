using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTac
{
    public partial class Form1 : Form
    {
        private bool turn = true;
        private int turnCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Md. Talat Mahmud \nEmail: mahmud.talat@northsouth.edu \nPhone: +8801303292825");
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClickButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (turn)
            {
                button.Text = "0";
            }
            else
            {
                button.Text = "X";
            }

            turn = !turn;
            button.Enabled = false;
            turnCount++;

            Winner();

        }

        private void Winner()
        {
            //disableBtn();
            bool winnerCheck = false;

            //HORIZONTAL CHECK
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && !A1.Enabled)
            {
                winnerCheck = true;
            }
            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && !B1.Enabled)
            {
                winnerCheck = true;
            }
            if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && !C1.Enabled)
            {
                winnerCheck = true;
            }

            //VERTICAL CHECK
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && !A1.Enabled)
            {
                winnerCheck = true;
            }
            if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && !A2.Enabled)
            {
                winnerCheck = true;
            }
            if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && !A3.Enabled)
            {
                winnerCheck = true;
            }

            //DIAGONAL CHECK
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && !A1.Enabled)
            {
                winnerCheck = true;
            }
            if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && !A3.Enabled)
            {
                winnerCheck = true;
            }

            if (winnerCheck)
            {
                disableBtn();
                String winnerPlayer="";
                if (turn)
                {
                    winnerPlayer = "X";
                }
                else
                {
                    winnerPlayer = "O";
                }

                MessageBox.Show(winnerPlayer + " wins...!!!");

            }
            else
            {
                if (turnCount == 9)
                {
                    MessageBox.Show("draw");
                }
            }


        }

        private void disableBtn()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                
            }
            
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turnCount = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch (Exception exception)
            {

            }

            
        }
    }
}
