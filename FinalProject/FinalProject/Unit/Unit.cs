using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Unit
{
    class Unit
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Health { get; set; }
        public double Attack { get; set; }
        public string Name { get; set; }

        public Unit(string Name, int X, int Y, double Health, double Attack)
        {
            this.Name = Name;
            this.X = X;
            this.Y = Y;
            this.Health = Health;
            this.Attack = Attack;
        }

        public void MoveRight()
        {
            X++;
        }

        public void MoveLeft()
        {
            X--;
        }

        public void MoveDown()
        {
            Y++;
        }

        public void MoveUp()
        {
            Y--;
        }

        public void Render(int x, int y, char z)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(z);
        }
        public void ClearRender(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
    }
}
