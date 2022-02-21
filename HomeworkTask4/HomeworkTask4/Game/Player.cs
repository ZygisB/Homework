using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTask4.Game
{
    class Player
    {
        public int Score { get; set; }
        public string Name { get; set; }
        public bool MaxScore { get; set; }

        public Player(int Score, string Name, bool MaxScore = false)
        {
            this.Score = Score;
            this.Name = Name;
            this.MaxScore = MaxScore;
        }
    }
}
