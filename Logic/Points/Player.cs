using System;
using System.Collections.Generic;
using System.Text;
using LodeRunner.Properties;

namespace LodeRunner.Logic
{
    class Player : Character
    {
        public Player(int x, int y) : base(x, y, 'I')
        {
            PointPic = Resources.player;
        }
    }
}
