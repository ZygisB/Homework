using HomeworkTask4.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTask4.GUI
{
    sealed class DiceMenu : Window
    {
        TextLine playerCountText;
        TextLine diceCount;

        public DiceMenu(int x = GuiInformation.X, int y = GuiInformation.Y, int width = GuiInformation.Width, int height = GuiInformation.Height, char frameChar = '%') : base(x, y, width, height, frameChar)
        {
            playerCountText = new TextLine(x, y + (height / 4), width, $"Player count is ");
            diceCount = new TextLine(x, y + (height / 2), width, $"Dice count is ");
        }

        public override void Render()
        {
            base.Render();
            playerCountText.Render();
            Console.Write(GameInformation.PlayerCount);
            diceCount.Render();
            Console.Write(GameInformation.DiceCount);
            Console.Write("   ");
        }
    }
}
