using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Unit
{
    class Enemy : Unit
    {
        private int id;

        public Enemy(int id, string name, int x, int y) : base(name, x, y)
        {
            this.id = id;
        }

        public void MoveDown()
        {
            Y++;
        }

        public int GetId()
        {
            return id;
        }
    }
}
