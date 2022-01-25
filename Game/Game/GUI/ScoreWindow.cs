using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Game;

namespace Game.GUI
{
    class ScoreWindow : Window
    {
        private TextBlock creditTextBlock;

        public ScoreWindow(int score, int lives,int x = 102, int y = 0, int width = 20, int height = 6, char frameChar = '@') : base(x, y, width, height, frameChar)
        {
            List<string> creditBlock = new List<string>();
            creditBlock.Add(new string("Score: ")+ score);
            creditBlock.Add(new string("Lives: ")+ lives);
            creditTextBlock = new TextBlock(x, y + 2, width, creditBlock);
        }
        public override void Render()
        {
            base.Render();
            creditTextBlock.Render();
        }
    }
}
