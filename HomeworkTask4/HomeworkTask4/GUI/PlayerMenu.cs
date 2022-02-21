using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTask4.GUI
{
    class PlayerMenu : Window
    {
        private Button player2;
        private Button player3;
        private Button player4;
        private Button player5;
        private Button player6;
        private Button player7;
        private TextLine playerCountText;
        List<Button> buttonList = new List<Button>();

        public PlayerMenu(int x = GuiInformation.X, int y = GuiInformation.Y, int width = GuiInformation.Width, int height = GuiInformation.Height, char frameChar = '%') : base(x, y, width, height, frameChar)
        {
            int buttonWidth = 16;
            int buttonHeight = 5;
            player2 = new Button(x + ((((width - buttonWidth) / 2) - buttonWidth) / 2), y + 4, buttonWidth, buttonHeight, "P2");
            player3 = new Button(x + ((width - buttonWidth) / 2), y + 4, buttonWidth, buttonHeight, "P3");
            player4 = new Button(x + width - buttonWidth - ((((width - buttonWidth) / 2) - buttonWidth) / 2), y + 4, buttonWidth, buttonHeight, "P4");
            player5 = new Button(x + ((((width - buttonWidth) / 2) - buttonWidth) / 2), y + 10, buttonWidth, buttonHeight, "P5");
            player6 = new Button(x + ((width - buttonWidth) / 2), y + 10, buttonWidth, buttonHeight, "P6");
            player7 = new Button(x + width - buttonWidth - ((((width - buttonWidth) / 2) - buttonWidth) / 2), y + 10, buttonWidth, buttonHeight, "P7");
            playerCountText = new TextLine(x, y + 2, width, "Plase select the number of players");
            buttonList.Add(player2);
            buttonList.Add(player3);
            buttonList.Add(player4);
            buttonList.Add(player5);
            buttonList.Add(player6);
            buttonList.Add(player7);
            player2.SetActive();
        }

        public override void Render()
        {
            base.Render();
            playerCountText.Render();
            player2.Render();
            player3.Render();
            player4.Render();
            player5.Render();
            player6.Render();
            player7.Render();
        }
        public int ActiveButtonPosition()
        {
            if (buttonList[0].isActive)
                return 0;
            else if (buttonList[1].isActive)
                return 1;
            else if (buttonList[2].isActive)
                return 2;
            else if (buttonList[3].isActive)
                return 3;
            else if (buttonList[4].isActive)
                return 4;
            else
                return 5;
        }
        public void MoveActiveButtonRight()
        {
            if (ActiveButtonPosition() == 0)
            {
                buttonList[1].SetActive();
                buttonList[0].SetNotActive();
            }

            else if (ActiveButtonPosition() == 1)
            {
                buttonList[2].SetActive();
                buttonList[1].SetNotActive();
            }
            else if (ActiveButtonPosition() == 2)
            {
                buttonList[2].SetActive();
            }
            else if (ActiveButtonPosition() == 3)
            {
                buttonList[4].SetActive();
                buttonList[3].SetNotActive();
            }

            else if (ActiveButtonPosition() == 4)
            {
                buttonList[5].SetActive();
                buttonList[4].SetNotActive();
            }
            else
            {
                buttonList[5].SetActive();
            }
        }
        public void MoveActiveButtonLeft()
        {
            if (ActiveButtonPosition() == 2)
            {
                buttonList[1].SetActive();
                buttonList[2].SetNotActive();
            }

            else if (ActiveButtonPosition() == 1)
            {
                buttonList[0].SetActive();
                buttonList[1].SetNotActive();
            }
            else if (ActiveButtonPosition() == 0)
            {
                buttonList[0].SetActive();
            }
            else if (ActiveButtonPosition() == 5)
            {
                buttonList[4].SetActive();
                buttonList[5].SetNotActive();
            }

            else if (ActiveButtonPosition() == 4)
            {
                buttonList[3].SetActive();
                buttonList[4].SetNotActive();
            }
            else
            {
                buttonList[3].SetActive();
            }
        }
        public void MoveActiveButtonDown()
        {
            if (ActiveButtonPosition() == 0)
            {
                buttonList[3].SetActive();
                buttonList[0].SetNotActive();
            }

            else if (ActiveButtonPosition() == 1)
            {
                buttonList[4].SetActive();
                buttonList[1].SetNotActive();
            }
            else if (ActiveButtonPosition() == 2)
            {
                buttonList[5].SetActive();
                buttonList[2].SetNotActive();
            }
            else if (ActiveButtonPosition() == 3)
            {
                buttonList[3].SetActive();
            }
            else if (ActiveButtonPosition() == 4)
            {
                buttonList[4].SetActive();
            }
            else
            {
                buttonList[5].SetActive();
            }
        }
        public void MoveActiveButtonUp()
        {
            if (ActiveButtonPosition() == 3)
            {
                buttonList[0].SetActive();
                buttonList[3].SetNotActive();
            }

            else if (ActiveButtonPosition() == 4)
            {
                buttonList[1].SetActive();
                buttonList[4].SetNotActive();
            }
            else if (ActiveButtonPosition() == 5)
            {
                buttonList[2].SetActive();
                buttonList[5].SetNotActive();
            }
            else if (ActiveButtonPosition() == 0)
            {
                buttonList[0].SetActive();
            }
            else if (ActiveButtonPosition() == 1)
            {
                buttonList[1].SetActive();
            }
            else
            {
                buttonList[2].SetActive();
            }
        }
    }
}
