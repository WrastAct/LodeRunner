using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LodeRunner.Logic;
using LodeRunner.Logic.Points;

namespace LodeRunner.Forms
{
    public partial class LevelEditor : Form
    {
        private GameField _gameField;
        public PictureBox[,] Points;
        private int _X, _Y;
        private readonly Form _sender;

        public int X
        {
            get => _X;
            set
            {
                Points[_Y, _X].BackColor = Color.Transparent;
                Points[_Y, _X].Image = _gameField[_Y, _X].PointPic;
                _X = value >= 0 ? value % 10 : (10 - (-value % 10));
                Points[_Y, _X].Image = null;
                Points[_Y, _X].BackColor = Color.Green; 
            }
        }

        public int Y
        {
            get => _Y;
            set
            {
                Points[_Y, _X].BackColor = Color.Transparent;
                Points[_Y, _X].Image = _gameField[_Y, _X].PointPic;
                _Y = value >= 0 ? value % 6 : (6 - (-value % 6));
                Points[_Y, _X].Image = null;
                Points[_Y, _X].BackColor = Color.Green;
            }
        }

        private void LevelEditor_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.S:
                    Y++;
                    break;
                case Keys.W:
                    Y--;
                    break;
                case Keys.A:
                    X--;
                    break;
                case Keys.D:
                    X++;
                    break;
                case Keys.E:
                    EditorDialog ed = new EditorDialog(this, _gameField, X, Y);
                    ed.ShowDialog();
                    break;
            }
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            _gameField[_Y, _X] = new EmptyPoint(X, Y);
            _gameField.PlayerX = _X;
            _gameField.PlayerY = _Y;
            _gameField.EditorCreated = true;
            MainGame maingame = new MainGame(this, _gameField);
            maingame.Show();
        }

        private void LevelEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            _sender.Show();
        }

        public LevelEditor(Form sender)
        {
            InitializeComponent();
            _sender = sender;
            sender.Hide();
            this.KeyPreview = true;
            _gameField = FileHandler.Open("LodeRunner.editor.json");
            _gameField.LoadPoints();
            _X = 0;
            _Y = 0;

            Points = new PictureBox[6, 10];
            for (int i = 0; i < Points.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < Points.GetUpperBound(1) + 1; j++)
                {
                    Points[i, j] = new PictureBox();
                    Points[i, j].Margin = new System.Windows.Forms.Padding(0);
                    Points[i, j].Size = new Size(64, 64);
                    Points[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    Points[i, j].Image = null;
                    this.editorField.Controls.Add(Points[i, j]);
                }
            }
            Points[_Y, _X].BackColor = Color.Green;
        }
    }
}
