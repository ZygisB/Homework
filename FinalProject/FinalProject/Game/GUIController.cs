using Game.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Game
{
    class GuiController
    {

        CreditWindow creditWindow;
        MenuWindow menuWindow;
        GameOverWindow gameOverWindow;
        GameController myGame = new GameController();

        public GuiController(int levelNuber = 0, int enemiesKilled = 0)
        {
            creditWindow = new CreditWindow();
            menuWindow = new MenuWindow();
            gameOverWindow = new GameOverWindow(levelNuber, enemiesKilled);
        }


        public void ShowMenu()
        {
            Console.Clear();
            menuWindow.Render();
            ChangeActiveKey();
        }

        private void ChangeActiveKey()
        {
            while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.RightArrow:
                        menuWindow.MoveActiveButtonRight();
                        menuWindow.Render();
                        break;
                    case ConsoleKey.LeftArrow:
                        menuWindow.MoveActiveButtonLeft();
                        menuWindow.Render();
                        break;
                    case ConsoleKey.Enter:
                        if (menuWindow.ActiveButtonPosition() == 0)
                        {
                            Console.Clear();
                            myGame.StartGame();
                            ShowMenu();
                        }
                        if (menuWindow.ActiveButtonPosition() == 1)
                        {
                            creditWindow.Render();
                            ExitCredits();
                            ShowMenu();
                        }
                        if (menuWindow.ActiveButtonPosition() == 2)
                        {
                            Environment.Exit(0);
                        }
                        break;
                }
            }
        }
        private void ExitCredits()
        {
            while (true)
            {
                var chCredits = Console.ReadKey(false).Key;
                switch (chCredits)
                {
                    case ConsoleKey.Escape:
                        Console.Clear();
                        menuWindow.Render();
                        //Needed to add this because the menu window would not render back properly when Esc was pressed
                        return;
                    case ConsoleKey.Enter:
                        return;
                }
            }
        }

        public void GameOver()
        {
            gameOverWindow.Render();
            while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.RightArrow:
                        gameOverWindow.MoveActiveButtonRight();
                        gameOverWindow.Render();
                        break;
                    case ConsoleKey.LeftArrow:
                        gameOverWindow.MoveActiveButtonLeft();
                        gameOverWindow.Render();
                        break;
                    case ConsoleKey.Enter:
                        if (gameOverWindow.ActiveButtonPosition() == 0)
                        {
                            Console.Clear();
                            myGame.StartGame();
                            ShowMenu();
                        }
                        if (gameOverWindow.ActiveButtonPosition() == 1)
                        {
                            Console.Clear();
                            ShowMenu();
                        }
                        break;
                }
            }
        }
    }
}
