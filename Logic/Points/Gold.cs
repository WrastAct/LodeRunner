using LodeRunner.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace LodeRunner.Logic.Points
{
    class Gold : PickUpPoint
    {
        public Gold(int x, int y) : base(x, y, '@')
        {
            PointPic = Resources.gold;
        }
    }
}
