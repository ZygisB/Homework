using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI
{
    sealed class MenuWindow : Window
    {
        private Button creditsButton;
        private Button quitButton;
        private Button startButton;
        private TextBlock titleTextBlock;
        List<Button> buttonList = new List<Button>();

        public MenuWindow(int x = 0, int y = 0, int width = 100, int height = 35, char frameChar = '%') : base(x, y, width, height, frameChar)
        {
            int buttonWidth = 16;
            startButton = new Button(x + ((((width - buttonWidth) / 2) - buttonWidth) / 2), y + (height / 2), buttonWidth, 5, "Start");
            creditsButton = new Button(x + ( (width - buttonWidth) / 2), y + (height/2), buttonWidth, 5, "Credits");
            quitButton = new Button(x + width - buttonWidth - ((((width - buttonWidth) / 2) - buttonWidth) / 2), y + (height / 2), buttonWidth, 5, "Quit");
            buttonList.Add(startButton);
            buttonList.Add(creditsButton);
            buttonList.Add(quitButton);
            startButton.SetActive();

            List<string> titleBlock = new List<string>();
            titleBlock.Add(new string("Final Project"));
            titleBlock.Add(new string("Dungeon Crawl Game"));
            titleBlock.Add(new string("Zygimantas Bogusevicius"));
            titleTextBlock = new TextBlock(x, y + 4, width, titleBlock);
        }

        public override void Render()
        {
            base.Render();
            titleTextBlock.Render();
            startButton.Render();
            creditsButton.Render();
            quitButton.Render();
        }
        public int ActiveButtonPosition()
        {
            if (buttonList[0].isActive)
                return 0;
            else if (buttonList[1].isActive)
                return 1;
            else
                return 2;
        }
        public void MoveActiveButtonRight()
        {
            if(ActiveButtonPosition()==0)
            {
                buttonList[1].SetActive();
                buttonList[0].SetNotActive();
            }

            else
            {
                buttonList[2].SetActive();
                buttonList[1].SetNotActive();
            }
        }
        public void MoveActiveButtonLeft()
        {
            if (ActiveButtonPosition() == 2)
            {
                buttonList[1].SetActive();
                buttonList[2].SetNotActive();
            }

            else
            {
                buttonList[0].SetActive();
                buttonList[1].SetNotActive();
            }
        }
    }
}
