using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTask4.GUI
{
    class Window : GuiObject
    {
        private Frame border;

        public Window(int x, int y, int width, int height, char frameChar) : base(x, y, width, height)
        {
            border = new Frame(x, y, width, height, frameChar);
        }
        public override void Render()
        {
            border.Render();
        }
    }
}
