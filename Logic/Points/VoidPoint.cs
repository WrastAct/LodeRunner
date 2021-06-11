using System;
using System.Collections.Generic;
using System.Text;

namespace LodeRunner.Logic
{
    abstract class VoidPoint : GamePoint
    {
        public VoidPoint(int x, int y, char t) : base(x, y, t)
        {
            IsSolid = false;
            IsPassable = true;
        }
    }
}
