using HomeworkTask4.Game;
using HomeworkTask4.GUI;
using System;

namespace HomeworkTask4
{
    class Program
    {
        static void Main()
        {
            //MainMenu testMenu = new MainMenu();

            //PlayerMenu testPlayer = new PlayerMenu();

            //testMenu.Render();

            //testPlayer.Render();

            GuiController guiController = new GuiController();

            Console.CursorVisible = false;

            guiController.ShowMenu();
        }
    }
}
