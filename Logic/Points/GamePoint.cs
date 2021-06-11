using System;
using System.Collections.Generic;
using System.Text;
using LodeRunner.Properties;
using Newtonsoft.Json;

namespace LodeRunner.Logic
{
    abstract class GamePoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Type { get; protected set; }
        public bool IsPassable { get; protected set; }
        public bool IsSolid { get; protected set; }
        public bool IsPickUp { get; protected set; }
        public System.Drawing.Image PointPic { get; set; }

        [JsonConstructor]
        public GamePoint(int x, int y, char t)
        {
            X = x;
            Y = y;
            Type = t;
            IsPickUp = false;
        }


    }
}
