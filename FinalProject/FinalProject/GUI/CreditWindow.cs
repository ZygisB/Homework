using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI
{
    sealed class CreditWindow : Window
    {
        private Button backButton;
        private TextBlock creditTextBlank;
        private TextBlock creditTextBlock;

        public CreditWindow(int x = 20, int y = 10, int width = 60, int height = 19, char frameChar = '@') : base(x, y, width, height, frameChar)
        {

            List<string> creditBlank = new List<string>();
            for (int i = 0; i < height-2; i++)
            {
                creditBlank.Add(new string(""));
            }
            creditTextBlank = new TextBlock(x, y + 1, width*2-1, creditBlank);

            int backButtonWidth = 20;
            backButton = new Button(x + ((width - backButtonWidth) / 2), y + height - 5, backButtonWidth, 3, "Back");

            List<string> creditBlock = new List<string>();
            creditBlock.Add(new string("Game design:"));
            creditBlock.Add(new string("Vardas Vardaitis"));
            creditBlock.Add(new string(""));
            creditBlock.Add(new string("Programuotojas:"));
            creditBlock.Add(new string("Vardas Vardaitis"));
            creditBlock.Add("");
            creditBlock.Add("\'Art\':");
            creditBlock.Add("Vardas Vardaitis");
            creditBlock.Add("");
            creditBlock.Add("Marketingas:");
            creditBlock.Add("Vardas Vardaitis");
            creditBlock.Add("");
            creditTextBlock = new TextBlock(x, y + 2, width, creditBlock);
        }

        public override void Render()
        {
            base.Render();
            creditTextBlank.Render();
            backButton.SetActive();
            backButton.Render();
            creditTextBlock.Render();
        }
    }
}
