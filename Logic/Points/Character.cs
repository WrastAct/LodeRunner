using System;
using System.Collections.Generic;
using System.Text;
using LodeRunner.Properties;

namespace LodeRunner.Logic
{
    abstract class Character : GamePoint
    {
        public Character(int x, int y, char t) : base(x, y, t)
        {
        }
    }
}
