using FinalProject.Game;
using FinalProject.Level;
using System;

namespace FinalProject
{
    class Program
    {
        static void Main()
        {
            GameController gameController = new GameController();

            Console.CursorVisible = false;
            gameController.InitGame();
            gameController.StartGameLoop();
        }
    }
}
