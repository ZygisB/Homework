using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI
{
    class Button : GuiObject
    {
        private Frame activeFrame;
        public bool isActive { get; set; }
        private Frame notActiveFrame;
        private TextLine textLine;
        public string Label
        {
            get
            {
                return textLine.Label;
            }
            set
            {
                textLine.Label = value;
            }
        }

        public Button(int x, int y, int width, int height, string buttonText) : base(x, y, width, height)
        {
            activeFrame = new Frame(x, y, width, height, '#');
            notActiveFrame = new Frame(x, y, width, height, '+');

            textLine = new TextLine(x, y + (height / 2), width, buttonText);

        }

        public override void Render()
        {
            if (isActive)
            {
                activeFrame.Render();
            }
            else
            {
                notActiveFrame.Render();
            }

            textLine.Render();
        }

        public void SetActive()
        {
            isActive = true;
        }
        public void SetNotActive()
        {
            isActive = false;
        }
    }
}
