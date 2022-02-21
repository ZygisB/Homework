using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTask4.GUI
{
    class GameOverWindow : Window
    {
        private TextLine winnerMessage;
        private Button replayButton;
        private Button menuButton;
        private Button quitButton;

        public GameOverWindow(int player, int score, int x = GuiInformation.X, int y = GuiInformation.Y, int width = GuiInformation.Width, int height = GuiInformation.Height, char frameChar = '@') : base(x, y, width, height, frameChar)
        {
            int buttonWidth = 16;
            replayButton = new Button(x + ((((width - buttonWidth) / 2) - buttonWidth) / 2), y + (height / 2), buttonWidth, 5, "Replay game");
            menuButton = new Button(x + ((width - buttonWidth) / 2), y + (height / 2), buttonWidth, 5, "Menu");
            quitButton = new Button(x + width - buttonWidth - ((((width - buttonWidth) / 2) - buttonWidth) / 2), y + (height / 2), buttonWidth, 5, "Quit");
            winnerMessage = new TextLine(x, y + (height / 4), width, $"The winner is player {player} with a total score of {score}");
        }

        public override void Render()
        {
            Console.Clear();
            base.Render();
            replayButton.Render();
            menuButton.Render();
            quitButton.Render();
            winnerMessage.Render();
        }
    }
}
