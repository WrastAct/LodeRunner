using System;
using System.Collections.Generic;
using System.Text;
using LodeRunner.Properties;

namespace LodeRunner.Logic.Points
{
    class Teleport : VoidPoint
    {
        public Teleport(int x, int y, char t) : base(x, y, t)
        {
            PointPic = Resources.portal;
        }
    }
}
