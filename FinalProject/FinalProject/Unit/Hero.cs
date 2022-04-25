using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Unit
{
    class Hero : Unit
    {
        public double defence { get; set; }
        public int enemiesKilled { get; set; }
        public Hero(string name, int x, int y, int health, int attack, int enemiesKilled = 0, double defence = 0) : base(name, x, y, health, attack)
        {
            this.enemiesKilled = enemiesKilled;
            this.defence = defence;
        }

    }
}
