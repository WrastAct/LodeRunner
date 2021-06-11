using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LodeRunner.Forms;
using LodeRunner.Properties;
using LodeRunner.Logic;

namespace LodeRunner.Forms
{
    partial class MainGame : Form
    {
        private Form _mainSender;
        private PictureBox[,] _points;
        private GameField _gameField;
        private GameField[] _gFields;
        private FieldPair[] _gPairFields;
        private int _current;
        private int _size;
        private EndGame _endGame;
        private int _score;
        private int _finalScore;
        private bool _loadedOnce;

        public int Score
        {
            get => _score;
            set => _score = value > 0 ? value : 0;
        }

        public int FinalScore
        {
            get => _finalScore;
            private set => _finalScore = value;
        }

        public MainGame(Form sender, params GameField[] gameField)
        {
            InitializeComponent();
            _finalScore = 0;
            _current = 0;
            _gFields = gameField;
            _points = new PictureBox[6, 10];
            _size = _gFields.Length;
            _loadedOnce = false;
            NextLevel();
            _mainSender = sender;
            sender.Hide();
        }

        public MainGame(Form sender, params FieldPair[] fpairs)
        {
            InitializeComponent();
            _finalScore = 0;
            _current = 0;
            _gPairFields = fpairs;
            _gFields = fpairs[0].Fields;
            _points = new PictureBox[6, 10];
            _size = _gFields.Length;
            _loadedOnce = false;
            NextLevel();
            _mainSender = sender;
            sender.Hide();
        }

        public MainGame(Form sender, string addPath)
        {
            InitializeComponent();
            _finalScore = 0;
            _current = 0;
            _size = 1;
            _points = new PictureBox[6, 10];
            GameField temp = FileHandler.Open(addPath);
            _gameField = FileHandler.Open(addPath);
            _gameField.LoadPoints();
            _gameField.TotalGold = temp.TotalGold;
            _gameField.MGame = this;
            LoadGame(_gameField);
            RestartScore();
            this.timerMain.Start();
            _gameField.EnemyMoving();
            _mainSender = sender;
            sender.Hide();
        }

        public Form MainSender
        {
            get => _mainSender;
            private set => _mainSender = value;
        }

        private void LoadGame(GameField gf)
        {
            for (int i = 0; i < _points.GetUpperBound(0) + 1; i++)
            {
                for(int j = 0; j < _points.GetUpperBound(1) + 1; j++)
                {
                    if(!_loadedOnce)
                    {
                        _points[i, j] = new PictureBox();
                        _points[i, j].Margin = new System.Windows.Forms.Padding(0);
                        _points[i, j].Size = new Size(64, 64);
                        _points[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                        this.gameField.Controls.Add(_points[i, j]);
                    }
                    
                    _points[i, j].Image = gf[i, j].PointPic;
                }
            }
            _loadedOnce = true;
            this[gf.PlayerY, gf.PlayerX] = Resources.player;
        }

        private void RestartScore()
        {
            Score = 50000;
        }

        private void MainGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainSender.Show();
        }

        public Image this[int i, int j]
        {
            get => _points[i, j].Image;
            set => _points[i, j].Image = value;
        }

        private void MainGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'd':
                    if(_gameField.PlayerX == _gameField.FieldW - 1)
                    {
                        int pY = _gameField.PlayerY;
                        int tGold = _gameField.TotalGold;
                        int cGold = _gameField.CurrentGold;


                        NextLevel();

                        this[_gameField.PlayerY, _gameField.PlayerX] = _gameField[_gameField.PlayerY, _gameField.PlayerX].PointPic;
                        _gameField.PlayerX = 0;
                        _gameField.PlayerY = pY;
                        this[pY, 0] = Resources.player;


                        _gameField.TotalGold += tGold;
                        _gameField.CurrentGold += cGold;

                    }
                    else
                        _gameField.Move(Char.ToUpper(e.KeyChar));
                    break;
                case 'a':
                    if (_gameField.PlayerX == 0)
                    {
                        int pY = _gameField.PlayerY;
                        int tGold = _gameField.TotalGold;
                        int cGold = _gameField.CurrentGold;

                        PreviousLevel();

                        this[_gameField.PlayerY, _gameField.PlayerX] = _gameField[_gameField.PlayerY, _gameField.PlayerX].PointPic;
                        _gameField.PlayerX = _gameField.FieldW - 1;
                        _gameField.PlayerY = pY;
                        this[pY, _gameField.FieldW - 1] = Resources.player;

                        _gameField.TotalGold += tGold;
                        _gameField.CurrentGold += cGold;
                    }
                    else
                        _gameField.Move(Char.ToUpper(e.KeyChar));
                    break;
                case 'w':
                case 's':           
                    _gameField.Move(Char.ToUpper(e.KeyChar));
                    break;
                case 'q':
                case 'e':
                {
                    _gameField.Explode(Char.ToUpper(e.KeyChar));
                    break;
                }
                case ' ':
                {
                    _gameField.Teleporting();
                    break;
                }
                case 'Z':
                {
                    _endGame = new EndGame(this, "You lost!", false);
                    break;
                }
            }
        }

        private void CheckEnd()
        {
            if(_gameField.GameEnded)
            {
                this.timerMain.Stop();
                _endGame = new EndGame(this, "You lost!", false);
            }
            if (_gameField.CheckGold())
            {
                this.timerMain.Stop();
                _finalScore += Score;
                _gameField.GameEnded = true;
                _endGame = new EndGame(this, "You won!", false);
            }
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            CheckEnd();
            Score -= 200;
        }

        public void NextLevel()
        {
            RestartScore();
            this.timerMain.Stop();
            if(_gameField != null)
            {
                _gameField.GameEnded = true;
            }
            _gameField = _gFields[_current++];
            _gameField.GameEnded = false;
            _gameField.ReloadEnemy();
            _gameField.LoadPoints();
            _gameField.MGame = this;
            LoadGame(_gameField);
            this.timerMain.Start();
            _gameField.EnemyMoving();
        }

        public void PreviousLevel()
        {
            RestartScore();
            this.timerMain.Stop();
            if (_gameField != null)
            _gameField.GameEnded = true;
            _gameField = _gFields[_current - 2];
            _current--;
            _gameField.GameEnded = false;
            _gameField.ReloadEnemy();
            _gameField.LoadPoints();
            _gameField.MGame = this;
            LoadGame(_gameField);
            this.timerMain.Start();
            _gameField.EnemyMoving();
        }

        public bool isLast()
        {
           return _current == _size;
        }
    }
}
