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

            Console.ReadKey();
        }
    }

}
