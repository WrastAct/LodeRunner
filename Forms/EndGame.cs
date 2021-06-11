using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LodeRunner.Forms
{
    partial class EndGame : Form
    {
        private MainGame _mainGame;
        public EndGame()
        {
            InitializeComponent();
        }



        public EndGame(MainGame mg, string txt, bool isEditor)
        {
            InitializeComponent();
            _mainGame = mg;
            this.textBox1.Text = txt;
            if (txt == "You lost!" || isEditor)
            {
                this.btnNext.Hide();
                Score scr = new Score(this, _mainGame.FinalScore);
                scr.Show();
            }     
            this.ShowDialog(mg);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainGame.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_mainGame.isLast())
            {
                Score sc = new Score(this, _mainGame.FinalScore);
                sc.Show();
                _mainGame.Close();
            }
            else
                _mainGame.NextLevel();
            this.Close();
        }

        private void EndGame_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
