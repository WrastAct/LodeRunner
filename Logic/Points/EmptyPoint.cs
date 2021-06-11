using System;
using System.Collections.Generic;
using System.Text;

namespace LodeRunner.Logic.Points
{
    class EmptyPoint : VoidPoint
    {
        public EmptyPoint(int x, int y) : base(x, y, ' ')
        {
            PointPic = null;
        }
    }
}
