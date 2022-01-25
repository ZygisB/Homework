using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Unit
{
    class Bullet : Unit
    {
        public Bullet(int x, int y, string name = "Bullet") : base(name, x, y)
        {
        }

        public void MoveUp()
        {
            Y--;
        }
    }
}
