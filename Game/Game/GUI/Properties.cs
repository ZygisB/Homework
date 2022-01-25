using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI
{
    class Properties
    {
        private int a;
        private int b;
        private int c;
        private int d;

        //public int A { get; set; }
        //public int B { get; }

        public int C
        {
            set
            {
                Console.WriteLine(c);
                c = value;
                Console.WriteLine(c);
            }
        }
        //public int D { get; private set; }

        public int A
        {
            get
            {
                return a;
            }
            set
            {
                Console.WriteLine(a);
                a = value;
                Console.WriteLine(a);
            }
        }

        public int B
        {
            get
            {
                return b;
            }
        }
        public int D
        {
            get
            {
                return d;
            }
            private set
            {
                Console.WriteLine(d);
                d = value;
                Console.WriteLine(d);
            }
        }

    }
}
