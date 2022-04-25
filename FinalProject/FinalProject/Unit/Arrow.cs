using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Unit
{
    class Arrow : Unit
    {
        /*Directions
         * 0 - Up
         * 1 - Right
         * 2 - Down
         * 3 - Left */
        public int direction { get; set; }
        public Arrow(string name, int direction, int x, int y, double health, double attack) : base(name, x, y, health, attack)
        {
            this.direction = direction;
        }
    }
}
