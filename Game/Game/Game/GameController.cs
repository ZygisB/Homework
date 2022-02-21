using Game.GUI;
using Game.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Game
{
    class GameController
    {
        
        GameScreen myGame = new GameScreen(100, 50);
        int score = 0;

        public void StartGame()
        {
            InitGame();
            StartGameLoop();
        }

        private void InitGame()
        {
            Hero newHero = new Hero("Tom", myGame.width/2, myGame.height);
            myGame.SetHero(newHero);
            myGame.ClearEnemiesBullets();

            Random rnd = new Random();

            for (int id = 0; id < 10; id++)
            {
                int x = rnd.Next(1, myGame.width - 1);
                int y = rnd.Next(1, 5); ;
                string name = "Enemy" + id;
                Enemy newEnemy = new Enemy(id, name, x, y);
                myGame.AddEnemy(newEnemy);
            }
        }

        private void EnemiesInLoop()
        {
            Random rnd = new Random();

            for (int id = 0; id < 7; id++)
            {
                int x = rnd.Next(1, myGame.width - 1);
                int y = rnd.Next(1, 5); ;
                string name = "Enemy" + id;
                Enemy newEnemy = new Enemy(id, name, x, y);
                myGame.AddEnemy(newEnemy);
            }
        }

        private void StartGameLoop()
        {
            int lives = 3;
            int counter = 0;
            Window gameBorders = new Window(0, 0, myGame.width+1, myGame.height+2, '*');
            bool needToRender = true;
            do
            {
                Console.Clear();
                gameBorders.Render();

                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    int hashCode = pressedChar.Key.GetHashCode();

                    switch (pressedChar.Key)
                    {
                        case ConsoleKey.Escape:
                            needToRender = false;
                            break;
                        case ConsoleKey.RightArrow:
                            if (myGame.GetHeroHorizontalPosition() == myGame.width-1)
                            {
                                break;
                            }
                            else
                            {
                                myGame.MoveHeroRight();
                                break;
                            }
                        case ConsoleKey.LeftArrow:
                            if (myGame.GetHeroHorizontalPosition() == 1)
                            {
                                break;
                            }
                            else
                            {
                                myGame.MoveHeroLeft();
                                break;
                            }
                        case ConsoleKey.Spacebar:
                            Bullet newBullet = new Bullet(myGame.GetHeroHorizontalPosition(), myGame.GetHeroVerticalPosition());
                            myGame.AddBullet(newBullet);
                            break;
                    }
                }

                ScoreWindow scoreWindow = new ScoreWindow(score, lives);
                counter++;
                myGame.Render();
                scoreWindow.Render();
                // Control enemy speed
                if (counter % 8 == 0)
                {
                    if (myGame.MoveAllEnemiesDown() == true)
                    {
                        lives--;
                    }

                }
                myGame.MoveAllBulletUp();
                if (myGame.DestroyEnemy())
                {
                    score++;
                }
                myGame.GameOver();
                // Cotrol how often new enemies appear
                if (counter % 50 == 0)
                {
                    EnemiesInLoop();
                }
                if (myGame.GameOver() == true)
                {
                    needToRender = false;
                    Console.Clear();
                    GuiController guiController = new GuiController(score,"You died");
                    guiController.GameOver();
                }
                if (lives <= 0)
                {
                    needToRender = false;
                    Console.Clear();
                    GuiController guiController = new GuiController(score, "The city was destroyed");
                    guiController.GameOver();
                }

                System.Threading.Thread.Sleep(200);
            } while (needToRender);
        }
    }
}
