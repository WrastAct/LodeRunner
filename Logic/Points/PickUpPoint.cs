using System;
using System.Collections.Generic;
using System.Text;

namespace LodeRunner.Logic
{
    abstract class PickUpPoint : VoidPoint
    {
        public PickUpPoint(int x, int y, char t) : base(x, y, t)
        {
            IsPickUp = true;
        }
    }
}
