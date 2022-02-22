using HomeworkTask4.Game;
using HomeworkTask4.GUI;
using System;

namespace HomeworkTask4
{
    class Program
    {
        static void Main()
        {
            GuiController guiController = new GuiController();

            Console.CursorVisible = false;

            guiController.ShowMenu();
        }
    }
}
