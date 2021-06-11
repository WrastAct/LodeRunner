using System;
using System.Collections.Generic;
using System.Text;

namespace LodeRunner.Logic
{
    abstract class SemiSolidPoint : GamePoint
    {
        public SemiSolidPoint(int x, int y, char t) : base(x, y, t)
        {
            IsSolid = true;
            IsPassable = true;
        }
    }
}
