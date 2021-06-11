using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LodeRunner.Logic
{
    class ScoreItem
    {
        private int score;
        private string name;

        [JsonProperty]
        public int Score
        {
            get => score;
            set => score = value;
        }

        [JsonProperty]
        public string Name
        {
            get => name;
            set => name = value;
        }

        public ScoreItem(int score, string name)
        {
            Score = score;
            Name = name;
        }
    }
}
