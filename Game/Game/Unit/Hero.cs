using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Unit
{
    class Hero : Unit
    {
        public Hero(string name, int x, int y) : base(name, x, y)
        {
        }

        public void MoveRight()
        {
            X++;
        }

        public void MoveLeft()
        {
            X--;
        }
    }
}
