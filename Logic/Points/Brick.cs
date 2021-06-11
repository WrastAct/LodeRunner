using System;
using System.Collections.Generic;
using System.Text;
using LodeRunner.Properties;

namespace LodeRunner.Logic.Points
{
    class Brick : SolidPoint
    {
        public Brick(int x, int y) : base(x, y, '#')
        {
            PointPic = Resources.brick;
        }
    }
}
