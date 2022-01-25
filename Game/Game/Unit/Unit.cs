using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Unit
{
    class Unit
    {
        public int X { get; set; }
        public int Y { get; set; }
        protected string Name;

        public Unit(string Name, int X, int Y)
        {
            this.Name = Name;
            this.X = X;
            this.Y = Y;
        }

        public void PrintInfo()
        {
            Console.Write($"Name - {Name}, ");
            Console.Write($"Horizontal position - {X}, ");
            Console.Write($"Vertical position - {Y} ");
            Console.WriteLine();
        }

        public void Render(int x, int y, char z)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(z);
        }
    }
}
