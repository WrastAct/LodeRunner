using System;
using System.Collections.Generic;
using System.Text;
using LodeRunner.Properties;

namespace LodeRunner.Logic.Points
{
    class Enemy : Character
    {
        public Enemy(int x, int y) : base(x, y, 'S')
        {
            PointPic = Resources.enemy;
            IsSolid = false;
            IsPassable = true;
        }

        public void MoveRight()
        {
            X++;
        }

        public void MoveLeft()
        {
            X--;
        }

        public void MoveUp()
        {
            Y--;
        }

        public void MoveDown()
        {
            Y++;
        }
    }
}
