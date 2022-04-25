using FinalProject.Game;
using FinalProject.Level;
using System;

namespace FinalProject
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
