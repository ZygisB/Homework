using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI
{
    class Frame : GuiObject
    {
        public char RenderChar { get; set; }

        public Frame(int x, int y, int width, int height, char renderChar) : base(x, y, width, height)
        {
            this.RenderChar = renderChar;
        }

        public override void Render()
        {
            
            for(int i = 0; i<Width; i++){
                Console.SetCursorPosition(X+i, Y);
                Console.Write(RenderChar);
            }
            for(int i = 1; i<Height-1; i++){
                Console.SetCursorPosition(X, Y+i);
                Console.Write(RenderChar);
                Console.SetCursorPosition(X+Width-1, Y+i);
                Console.Write(RenderChar);

            }
            for(int i = 0; i<Width; i++){

                Console.SetCursorPosition(X+i, Y+Height-1);
                Console.Write(RenderChar);
            }
        }
    }
}
