using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTask4.GUI
{
    class TextLine : GuiObject
    {
        public string Label { get; set; }

        public TextLine(int x, int y, int width, string label) : base(x, y, width, 1)
        {
            Label = label;
        }

        public override void Render()
        {
            Console.SetCursorPosition(X, Y);

            if (Width > Label.Length)
            {
                int offset = (Width - Label.Length) / 2;
                for (int i = 0; i < offset; i++)
                {
                    if (i == 0)
                    {
                        Console.SetCursorPosition(X + 1, Y);
                    }
                    else
                    {
                        Console.Write(' ');
                    }

                }
            }

            Console.Write(Label);
        }
    }
}
