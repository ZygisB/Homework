using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Unit
{
    class Enemy : Unit
    {
        private int id;

        public Enemy(int id, string name, int x, int y, int health, int attack) : base(name, x, y, health, attack)
        {
            this.id = id;
        }
    }
}
