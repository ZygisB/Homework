using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI
{
    class GameOverWindow : Window
    {
        private Button menuButton;
        private Button playAgainButton;
        private TextBlock gameOverTextBlock;
        private Window border = new Window(0, 0, 100, 35, '%');
        List<Button> buttonList = new List<Button>();

        public GameOverWindow(int levelNumber, int enemiesKilled, int x = 20, int y = 10, int width = 60, int height = 19, char frameChar = '@') : base(x, y, width, height, frameChar)
        {
            int buttonWidth = 16;
            playAgainButton = new Button(x + (width/2-((width-buttonWidth) / 2)), y + (height / 2), buttonWidth, 5, "Play Again");
            menuButton = new Button(x + (width / 2 + (buttonWidth / 2)), y + (height / 2), buttonWidth, 5, "Menu");
            List<String> gameOverText = new List<String>();
            gameOverText.Add(new string("Game Over"));
            gameOverText.Add(new string("You reached level ") + levelNumber);
            gameOverText.Add(new string("and killed ") + enemiesKilled +" enemies");
            gameOverTextBlock = new TextBlock(x, y + (height / 4), width, gameOverText);
            buttonList.Add(playAgainButton);
            buttonList.Add(menuButton);
            playAgainButton.SetActive();
        }

        public override void Render()
        {
            border.Render();
            base.Render();
            playAgainButton.Render();
            menuButton.Render();
            gameOverTextBlock.Render();
        }

        public int ActiveButtonPosition()
        {
            if (buttonList[0].isActive)
                return 0;
            else
                return 1;
        }
        public void MoveActiveButtonRight()
        {
                buttonList[1].SetActive();
                buttonList[0].SetNotActive();

        }
        public void MoveActiveButtonLeft()
        {
                buttonList[0].SetActive();
                buttonList[1].SetNotActive();
        }
    }
}
