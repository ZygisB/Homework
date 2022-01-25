using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.GUI;
using Game.Game;

namespace Game
{
    class Program
    {
        static void Main()
        {


            GuiController guiController = new GuiController();

            Console.CursorVisible = false;

            guiController.ShowMenu();


            //MenuWindow menuWindow = new MenuWindow();
            //menuWindow.Render();

            //CreditWindow creditWindow = new CreditWindow();
            //creditWindow.Render();

            //Console.ReadKey();

            //Console.Clear();

            //menuWindow.Render();


            //GameController myGame = new GameController();
            //myGame.StartGame();

            //Properties test = new Properties();

            //Console.WriteLine(test.A);
            //Console.WriteLine(test.B);
            //Console.WriteLine(test.C);
            //Console.WriteLine(test.D);


            //test.A = 11;
            //test.B = 12;
            //test.C = 13;
            //test.D = 14;

            //Console.WriteLine(test.A);
            //Console.WriteLine(test.B);
            //Console.WriteLine(test.C);
            //Console.WriteLine(test.D);

            Console.ReadKey();
        }
    }

}
