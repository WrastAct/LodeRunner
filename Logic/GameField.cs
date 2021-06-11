using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using LodeRunner.Logic.Points;
using LodeRunner.Forms;
using LodeRunner.Properties;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace LodeRunner.Logic
{
    [JsonObject(MemberSerialization.OptIn)]
    class GameField
    {
        private MainGame mainGame;
        private GamePoint[,] points;
        private int fieldW;
        private int fieldH;
        private GamePoint player;
        private TelePair telepair;
        private Enemy enemy;
        private int totalGold;
        private int currentGold;
        private bool gameEnded;
        private bool editorCreated;
        private char[] pointChars = {
            '@', ' ', '|', '#', ' ', 'I', ' ', '@', '<', ' ',
            '#', '#', '|', '#', '#', '#', '#', '#', '#', '#',
            ' ', ' ', '|', ' ', '@', ' ', ' ', ' ', '|', ' ',
            '#', '#', '#', '#', '#', '#', '#', '#', '|', '#',
            '>', ' ', '@', ' ', ' ', 's', ' ', ' ', '|', ' ',
            '#', '#', '#', '#', '#', '#', '#', '#', '#', '#',
        };

        [JsonProperty]
        public int TotalGold 
        { 
            get => totalGold; 
            set => totalGold = value; 
        }

        [JsonProperty]
        public int CurrentGold
        {
            get => currentGold;
            set => currentGold = value;
        }

        public int FieldW
        {
            get => fieldW;
            private set => fieldW = value;
        }

        public int FieldH
        {
            get => fieldH;
            private set => fieldH = value;
        }
        [JsonProperty]
        public int PlayerX
        {
            get => player.X;
            set
            {
                if (value >= 0 && value < this.FieldW)
                    player.X = value;
            }
        }
        [JsonProperty]
        public int PlayerY
        {
            get => player.Y;
            set
            {
                if (value >= 0 && value < this.FieldH)
                    player.Y = value;
            }
        }

        [JsonProperty]
        public char[] PointChars
        {
            get => pointChars;
            set => pointChars = value;
        }

        public MainGame MGame
        {
            get => mainGame;
            set => mainGame = value;
        }

        public bool EditorCreated
        {
            get => editorCreated;
            set => editorCreated = value;
        }

        public bool GameEnded
        {
            get => gameEnded;
            set => gameEnded = value;
        }

        public GameField()
        {
            const int fieldW = 10;
            FieldW = fieldW;
            const int fieldH = 6;
            FieldH = fieldH;
            points = new GamePoint[fieldH, fieldW];
            telepair = new TelePair();
            gameEnded = false;

            LoadPoints();
        }

        public GameField(MainGame mainGame) 
        {
            this.mainGame = mainGame;
            const int fieldW = 10;
            FieldW = fieldW;
            const int fieldH = 6;
            FieldH = fieldH;
            editorCreated = false;
            points = new GamePoint[fieldH, fieldW];
            telepair = new TelePair();
            gameEnded = false;

            LoadPoints();
        }

        public bool CheckGold()
        {
            return TotalGold == CurrentGold;
        }

        public void LoadPoints()
        {
            TotalGold = 0;
            CurrentGold = 0;
            ReloadEnemy();
            for (int i = 0; i < FieldH; i++)
            {
                for (int j = 0; j < FieldW; j++)
                {
                    if (pointChars[i * FieldW + j] == 'I')
                        player = new Player(j, i);
                    if (pointChars[i * FieldW + j] == '@')
                        TotalGold++;
                    if (pointChars[i * FieldW + j] == 's')
                        enemy = new Enemy(j, i);
                    this[i, j] = pointChars[i * FieldW + j] switch
                    {  
                        ' ' => new EmptyPoint(j, i),
                        'I' => new EmptyPoint(j, i),
                        's' => new EmptyPoint(j, i),
                        '@' => new Gold(j, i),
                        '|' => new Ladder(j, i),
                        '#' => new Brick(j, i),
                        '<' => telepair.Start = new Teleport(j, i, '<'),
                        '>' => telepair.End = new Teleport(j, i, '>'),
                        _ => throw new ArgumentException($"There is no such type of point as '{pointChars[i * FieldW + j]}'")
                    };
                }
            }
        }

        public void Move(char direction)
        {
            if (this[PlayerY, PlayerX].Type == 's')
                mainGame[PlayerY, PlayerX] = null;
            else
                mainGame[PlayerY, PlayerX] = this[PlayerY, PlayerX].PointPic;
            switch (direction)
            {
                case 'W':
                {
                    if (PlayerY - 1 >= 0 && this[PlayerY - 1, PlayerX].IsSolid &&
                                            this[PlayerY - 1, PlayerX].IsPassable)
                        PlayerY--;
                    if (this[PlayerY, PlayerX].Type == '@')
                    {
                        this[PlayerY, PlayerX] = new EmptyPoint(PlayerX, PlayerY);
                        CurrentGold++;
                    }
                    mainGame[PlayerY, PlayerX] = Resources.player;
                    break;
                }
                case 'A':
                {
                    if (PlayerX - 1 >= 0 && this[PlayerY, PlayerX - 1].IsPassable)
                        PlayerX--;
                    if (this[PlayerY, PlayerX].Type == '@')
                    {
                        this[PlayerY, PlayerX] = new EmptyPoint(PlayerX, PlayerY);
                        CurrentGold++;
                    }
                    mainGame[PlayerY, PlayerX] = Resources.player;
                    break;
                }
                case 'S':
                {
                    if (PlayerY + 1 < this.FieldH && this[PlayerY + 1, PlayerX].IsPassable)
                        PlayerY++;
                    if (this[PlayerY, PlayerX].Type == '@')
                    {
                        this[PlayerY, PlayerX] = new EmptyPoint(PlayerX, PlayerY);
                        CurrentGold++;
                    }
                    mainGame[PlayerY, PlayerX] = Resources.player;
                    break;
                }
                case 'D':
                {
                    if (PlayerX + 1 < this.FieldW && this[PlayerY, PlayerX + 1].IsPassable)
                        PlayerX++;
                    if (this[PlayerY, PlayerX].Type == '@')
                    {
                        this[PlayerY, PlayerX] = new EmptyPoint(PlayerX, PlayerY);
                        CurrentGold++;
                    }
                    mainGame[PlayerY, PlayerX] = Resources.player2;
                    break;
                }
            }
            if (PlayerY + 1 < this.FieldH && !this[PlayerY + 1, PlayerX].IsSolid)
                Move('S');
        }

        public void Explode(char key)
        {
            switch (key)
            {
                case 'Q':
                    ExplodeLeft();
                    break;
                case 'E':
                    ExplodeRight();
                    break;
            }
        }

        private void ExplodeLeft()
        {
            ExplodeProto(-1, 1);
        }

        private void ExplodeRight()
        {
            ExplodeProto(1, 1);
        }

        private void ExplodeProto(int a, int b)
        {
            if (PlayerX + a >= 0 && PlayerX + a < this.FieldW &&
               PlayerY + b >= 0 && PlayerY + b < this.FieldH &&
               this[PlayerY + b, PlayerX + a].IsSolid)
            {
                this[PlayerY + b, PlayerX + a] = new EmptyPoint(PlayerX + a, PlayerY + b);
                mainGame[PlayerY + b, PlayerX + a] = this[PlayerY + b, PlayerX + a].PointPic;

            }
        }

        public void Teleporting()
        {
            if (this[PlayerY, PlayerX].Type == '<')
            {
                mainGame[PlayerY, PlayerX] = Resources.portal;
                PlayerY = telepair.End.Y;
                PlayerX = telepair.End.X;
            }
            else if (this[PlayerY, PlayerX].Type == '>')
            {
                mainGame[PlayerY, PlayerX] = Resources.portal;
                PlayerY = telepair.Start.Y;
                PlayerX = telepair.Start.X;
            }
            mainGame[PlayerY, PlayerX] = Resources.player;
        }

        public void SaveField()
        {
            FileHandler.Save(this);
        }

        public void ReloadEnemy()
        {
            enemy = null;
        }

        private void MoveEnemy()
        {
            if (enemy == null)
                return;
            while (true)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PlayerX == enemy.X && PlayerY == enemy.Y || gameEnded)
                    {
                        gameEnded = true;
                        return;
                    }
                    if (enemy.X + 1 < FieldW && this[enemy.Y, enemy.X - 1].IsPassable)
                        enemy.MoveRight();
                    if (this[enemy.Y, enemy.X - 1].PointPic != Resources.enemy)
                        mainGame[enemy.Y, enemy.X - 1] = null;
                    else
                        mainGame[enemy.Y, enemy.X - 1] = this[enemy.Y, enemy.X - 1].PointPic;
                    if (enemy.Y + 1 < this.FieldH && !this[enemy.Y + 1, enemy.X].IsSolid)
                        enemy.MoveDown();
                    mainGame[enemy.Y, enemy.X] = Resources.enemy;
                    if (PlayerX == enemy.X && PlayerY == enemy.Y || gameEnded)
                    {
                        gameEnded = true;
                        return;
                    }
                    Thread.Sleep(700);
                }

                for (int i = 0; i < 3; i++)
                {
                    if (PlayerX == enemy.X && PlayerY == enemy.Y || gameEnded)
                    {
                        gameEnded = true;
                        return;
                    }
                    if (enemy.X - 1 >= 0 && this[enemy.Y, enemy.X - 1].IsPassable)
                        enemy.MoveLeft();
                    if (this[enemy.Y, enemy.X + 1].PointPic == Resources.enemy)
                        mainGame[enemy.Y, enemy.X + 1] = null;
                    else
                        mainGame[enemy.Y, enemy.X + 1] = this[enemy.Y, enemy.X + 1].PointPic;
                    if (enemy.Y + 1 < this.FieldH && !this[enemy.Y + 1, enemy.X].IsSolid)
                        enemy.MoveDown();
                    mainGame[enemy.Y, enemy.X] = Resources.enemy;
                    if (PlayerX == enemy.X && PlayerY == enemy.Y || gameEnded)
                    {
                        gameEnded = true;
                        return;
                    }
                    Thread.Sleep(700);
                }
            }
        }

        public async void EnemyMoving()
        {
            if(enemy == null)
                return;
            await Task.Run(() => this.MoveEnemy());
        }

        public GamePoint this[int i, int j]
        {
            get => points[i, j];
            set => points[i, j] = value;
        }
    }
}
