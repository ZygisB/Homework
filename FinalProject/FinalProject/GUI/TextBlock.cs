using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI
{
    class TextBlock : GuiObject
    {
        private List<TextLine> textLines = new List<TextLine>();

        public TextBlock (int x, int y, int width, List<string> lines) : base(x, y, width, lines.Count)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                textLines.Add(new TextLine(x, y + i, width, lines[i]));
            }
        }

        public override void Render()
        {
            for (int i = 0; i < textLines.Count; i++)
            {
                textLines[i].Render();
            }
        }
    }
}
