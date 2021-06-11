using LodeRunner.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace LodeRunner.Logic.Points
{
    class Ladder : SemiSolidPoint
    {
        public Ladder(int x, int y) : base(x, y, '|')
        {
            PointPic = Resources.ladder;
        }
    }
}
