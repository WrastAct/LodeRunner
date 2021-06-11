using System;
using System.Collections.Generic;
using System.Text;

namespace LodeRunner.Logic.Points
{
    class TelePair
    {
        public Teleport Start { get; set; }
        public Teleport End { get; set; }

        public TelePair()
        {

        }

        public TelePair(int x1, int y1, int x2, int y2)
        {
            Start = new Teleport(x1, y1, '<');
            End = new Teleport(x2, y2, '>');
        }

        public TelePair(Teleport tp1, Teleport tp2)
        {
            Start = tp1;
            End = tp2;
        }
    }
}
