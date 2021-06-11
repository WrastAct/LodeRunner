using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LodeRunner.Forms;
using LodeRunner.Logic;

namespace LodeRunner
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            GameField firstLevel = FileHandler.Open("LodeRunner.lvl1.json");
            GameField secondLevel = FileHandler.Open("LodeRunner.lvl2.json");
            GameField thirdLevel = FileHandler.Open("LodeRunner.lvl1.json");
            MainGame mg = new MainGame(this, firstLevel, secondLevel, thirdLevel);
            mg.Show();
        }

        private void btnEditor_Click(object sender, EventArgs e)
        {
            LevelEditor lvlEditor = new LevelEditor(this);
            lvlEditor.Show();
        }
    }
}
