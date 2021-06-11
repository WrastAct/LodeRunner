using System;
using System.Collections.Generic;
using System.Text;

namespace LodeRunner.Logic
{
    abstract class SolidPoint : GamePoint
    {
        public SolidPoint(int x, int y, char t) : base(x, y, t)
        {
            IsSolid = true;
            IsPassable = false;
        }
    }
}
