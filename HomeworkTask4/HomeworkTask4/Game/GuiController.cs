using HomeworkTask4.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTask4.Game
{
    class GuiController
    {
        MainMenu mainMenu;
        PlayerMenu playerMenu;
        DiceMenu diceMenu;
        GameController gameController;
        GameOverWindow gameOverWindow;

        public GuiController()
        {
            mainMenu = new MainMenu();
            playerMenu = new PlayerMenu();
            diceMenu = new DiceMenu();
            gameController = new GameController();
        }
        public void ShowMenu()
        {
            Console.Clear();
            mainMenu.Render();

            while (true)
            {
                var ch = Console.ReadKey(true).Key;
                switch (ch)
                {
                    case ConsoleKey.P:
                        ChangePlayerCount();
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private void ChangePlayerCount()
        {
            Console.Clear();
            playerMenu.Render();
            while (true)
            {
                var ch = Console.ReadKey(true).Key;
                switch (ch)
                {
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.RightArrow:
                        playerMenu.MoveActiveButtonRight();
                        playerMenu.Render();
                        break;
                    case ConsoleKey.LeftArrow:
                        playerMenu.MoveActiveButtonLeft();
                        playerMenu.Render();
                        break;
                    case ConsoleKey.DownArrow:
                        playerMenu.MoveActiveButtonDown();
                        playerMenu.Render();
                        break;
                    case ConsoleKey.UpArrow:
                        playerMenu.MoveActiveButtonUp();
                        playerMenu.Render();
                        break;
                    case ConsoleKey.Enter:
                        if (playerMenu.ActiveButtonPosition() == 0)
                        {
                            GameInformation.PlayerCount = 2;
                            Console.Clear();
                            ChangeDiceCount();
                        }
                        if (playerMenu.ActiveButtonPosition() == 1)
                        {
                            GameInformation.PlayerCount = 3;
                            Console.Clear();
                            ChangeDiceCount();
                        }
                        if (playerMenu.ActiveButtonPosition() == 2)
                        {
                            GameInformation.PlayerCount = 4;
                            Console.Clear();
                            ChangeDiceCount();
                        }
                        if (playerMenu.ActiveButtonPosition() == 3)
                        {
                            GameInformation.PlayerCount = 5;
                            Console.Clear();
                            ChangeDiceCount();
                        }
                        if (playerMenu.ActiveButtonPosition() == 4)
                        {
                            GameInformation.PlayerCount = 6;
                            Console.Clear();
                            ChangeDiceCount();
                        }
                        if (playerMenu.ActiveButtonPosition() == 5)
                        {
                            GameInformation.PlayerCount = 7;
                            Console.Clear();
                            ChangeDiceCount();
                        }
                        break;
                }
            }
        }
        private void ChangeDiceCount()
        {
            Console.Clear();
            GameInformation.DiceCount = 3;
            diceMenu.Render();
            while (true)
            {
                var ch = Console.ReadKey(true).Key;
                switch (ch)
                {
                    case ConsoleKey.OemPlus:
                        GameInformation.DiceCount++;
                        diceMenu.Render();
                        break;
                    case ConsoleKey.OemMinus:
                        if (GameInformation.DiceCount>1)
                        {
                            GameInformation.DiceCount--;
                            diceMenu.Render();
                            break;
                        }
                        else
                        {
                            diceMenu.Render();
                            break;
                        }
                    case ConsoleKey.Enter:
                        gameController.PlayGame();
                        GameOverMenu();
                        break;
                }
            }
        }
        private void GameOver()
        {
            GameOverMenu();
        }
        private void GameOverMenu()
        {
            Console.WriteLine("Please press Enter to continue");

            while (true)
            {
                var ch = Console.ReadKey(true).Key;
                switch (ch)
                {
                    case ConsoleKey.Enter:
                        Console.Clear();
                        gameOverWindow = new GameOverWindow(gameController.ReturnWinner(), gameController.ReturnWinnerScore());
                        gameOverWindow.Render();
                        while (true)
                        {
                            var c = Console.ReadKey(true).Key;
                            switch (c)
                            {
                                case ConsoleKey.R:
                                    gameController.PlayGame();
                                    GameOver();
                                    break;
                                case ConsoleKey.M:
                                    ShowMenu();
                                    break;
                                case ConsoleKey.Q:
                                    Environment.Exit(0);
                                    break;
                            }
                        }
                }
            }
        }
    }
}
