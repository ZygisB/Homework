using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTask4.GUI
{
    sealed class MainMenu : Window
    {
        private TextLine gameName;
        private Button playButton;
        private Button quitButton;
        List<Button> buttonList = new List<Button>();

        public MainMenu(int x = GuiInformation.X, int y = GuiInformation.Y, int width = GuiInformation.Width, int height = GuiInformation.Height, char frameChar = '%') : base(x, y, width, height, frameChar)
        {
            int buttonWidth = 16;
            gameName = new TextLine(x, y + (height / 3), width, "The Dice Game");
            playButton = new Button(x+((width/2)- buttonWidth)/2, y + (height / 2), buttonWidth, 5, "Play");
            quitButton = new Button(x+(width/2) + ((width / 2) - buttonWidth) / 2, y + (height / 2), buttonWidth, 5, "Quit");
            buttonList.Add(playButton);
            buttonList.Add(quitButton);
        }

        public override void Render()
        {
            base.Render();
            gameName.Render();
            playButton.Render();
            quitButton.Render();
        }
    }
}
