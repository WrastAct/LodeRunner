using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LodeRunner.Logic;

namespace LodeRunner.Forms
{
    public partial class Score : Form
    {
        private int _sc;

        public Score(Form sender, int score)
        {
            InitializeComponent();
            _sc = score;
            numScore.Text = score.ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ScoreItem sItem = new ScoreItem(_sc, this.textName.Text);
            FileHandler.Save(sItem);
            this.Close();
        }
    }
}
