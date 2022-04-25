using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Unit
{
    class Item : Unit
    {
        public int type { get; set; }
        public double defence { get; set; }
        public Item(string name, int type, int x, int y, double health, double attack, double defence) : base(name, x, y, health, attack)
        {
            this.type = type;
            this.defence = defence;
        }
    }
}
