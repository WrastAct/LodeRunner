using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LodeRunner.Logic;
using LodeRunner.Logic.Points;
using LodeRunner.Properties;

namespace LodeRunner.Forms
{
    partial class EditorDialog : Form
    {
        private LevelEditor _lvlEd;
        private GameField _gameField;
        private int _x, _y;

        private void btnBrick_Click(object sender, EventArgs e)
        {
            _lvlEd.Points[_y, _x].Image = Resources.brick;
            _gameField.PointChars[_y * _gameField.FieldW + _x] = '#';
            _gameField[_y, _x] = new Brick(_x, _y);
            this.Close();
        }

        private void btnGold_Click(object sender, EventArgs e)
        {
            _lvlEd.Points[_y, _x].Image = Resources.gold;
            _gameField.PointChars[_y * _gameField.FieldW + _x] = '@';
            _gameField[_y, _x] = new Gold(_x, _y);
            this.Close();
        }

        private void btnLadder_Click(object sender, EventArgs e)
        {
            _lvlEd.Points[_y, _x].Image = Resources.ladder;
            _gameField.PointChars[_y * _gameField.FieldW + _x] = '|';
            _gameField[_y, _x] = new Ladder(_x, _y);
            this.Close();
        }

        private void btnEmpty_Click(object sender, EventArgs e)
        {
            _lvlEd.Points[_y, _x].Image = null;
            _gameField.PointChars[_y * _gameField.FieldW + _x] = ' ';
            _gameField[_y, _x] = new EmptyPoint(_x, _y);
            this.Close();
        }

        public EditorDialog(LevelEditor lvlEditor, GameField gf, int x, int y)
        {
            InitializeComponent();
            _lvlEd = lvlEditor;
            _gameField = gf;
            _x = x;
            _y = y;
        }


    }
}
