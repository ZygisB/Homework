using FinalProject.Level;
using FinalProject.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Game
{
    class GameController
    {
        HeroFunctions heroFunctions = new HeroFunctions();
        LevelFunctions levelFunctions = new LevelFunctions();
        EnemyFunctions enemyFunctions = new EnemyFunctions();
        ItemFunctions itemFunctions = new ItemFunctions();
        ArrowFunctions arrowFunctions = new ArrowFunctions();
        int heroBaseAttack = 5;
        int heroBaseHealth = 100;
        int counter = 0;
        int levelNumber = 0;

        public void StartGame()
        {
            enemyFunctions.ClearEnemies();
            itemFunctions.ClearItems();
            arrowFunctions.Cleararrows();
            InitHero();
            StartGameLoop();
        }
        public void InitHero()
        {
            Hero newHero = new Hero("Tom", 10, 5, heroBaseHealth, heroBaseAttack);
            heroFunctions.SetHero(newHero);
        }
        public void InitLevel(int levelNumber)
        {
            levelFunctions.SetLevel(levelNumber);
        }
        public void GenerateEnemies(int levelNumber)
        {
            Random rnd = new Random();

            int enemyCount = 0;

            do
            {
                int x = rnd.Next(0, 49);
                int y = rnd.Next(0, 39);
                if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), x, y) == 1)
                {
                    string name = "Enemy" + enemyCount;
                    Enemy newEnemy = new Enemy(enemyCount, name, x, y, 20, 4);
                    enemyFunctions.AddEnemy(newEnemy);
                    levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), x, y, 4);
                    enemyCount++;
                }
            } while (enemyCount < (10 + levelNumber));
        }
        public void GenerateItems(int levelNumber)
        {
            int potionCount = 0;
            int swordCount = 0;
            int armorCount = 0;
            int arrowsCount = 0;
            Random rnd = new Random();

            int rndPotion = rnd.Next(0, 100);
            int rndSword = rnd.Next(0, 100);
            int rndArmor = rnd.Next(0, 100);
            int rndArrows = rnd.Next(0, 100);

            if (rndPotion > 0)
            {
                do
                {
                    int x = rnd.Next(0, 49);
                    int y = rnd.Next(0, 39);
                    if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), x, y) == 1)
                    {
                        itemFunctions.GeneratePotion(x, y, 15);
                        potionCount++;
                        levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), x, y, 3);
                    }
                } while (potionCount < 1);
            }

            if (rndSword > 45)
            {
                do
                {
                    int x = rnd.Next(0, 49);
                    int y = rnd.Next(0, 39);
                    if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), x, y) == 1)
                    {
                        itemFunctions.GenerateSword(x, y, 3);
                        swordCount++;
                        levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), x, y, 3);
                    }
                } while (swordCount < 1);
            }
            if (rndArmor > 0)
            {
                do
                {
                    int x = rnd.Next(0, 49);
                    int y = rnd.Next(0, 39);
                    if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), x, y) == 1)
                    {
                        itemFunctions.GenerateArmor(x, y, 10);
                        armorCount++;
                        levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), x, y, 3);
                    }
                } while (armorCount < 1);
            }
            if (rndArrows > 0)
            {
                do
                {
                    int x = rnd.Next(0, 49);
                    int y = rnd.Next(0, 39);
                    if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), x, y) == 1)
                    {
                        itemFunctions.GenerateArrows(x, y, 5);
                        arrowsCount++;
                        levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), x, y, 3);
                    }
                } while (arrowsCount < 2);
            }
        }

        public void StartGameLoop()
        {
            Console.Clear();
            bool needToRender = true;

            InitLevel(levelNumber);
            heroFunctions.SetHeroPosition(levelFunctions.FirstEmptyX(levelFunctions.ReturnLevel()), levelFunctions.FirstEmptyY(levelFunctions.ReturnLevel()));
            levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), levelFunctions.FirstEmptyX(levelFunctions.ReturnLevel()), levelFunctions.FirstEmptyY(levelFunctions.ReturnLevel()), 2);
            GenerateEnemies(levelNumber);
            GenerateItems(levelNumber);
            Console.WriteLine(levelFunctions.GetLevelLength(levelFunctions.ReturnLevel()));

            do
            {
                levelFunctions.RenderLevel(levelFunctions.ReturnLevel());
                heroFunctions.Render();
                enemyFunctions.Render();
                itemFunctions.Render();

                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    int hashCode = pressedChar.Key.GetHashCode();

                    switch (pressedChar.Key)
                    {
                        case ConsoleKey.Escape:
                            levelFunctions.SetLevel(levelNumber);
                            needToRender = false;
                            break;
                        case ConsoleKey.RightArrow:
                            if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition() + 1, heroFunctions.GetHeroVerticalPosition()) == 4)
                            {
                                HeroStartsFight(enemyFunctions.GetEnemyByPosition(heroFunctions.GetHeroHorizontalPosition() + 1, heroFunctions.GetHeroVerticalPosition()));
                                heroFunctions.SetDirectionRight();
                                break;
                            }
                            else if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition() + 1, heroFunctions.GetHeroVerticalPosition()) == 3)
                            {
                                HeroPicksItem(itemFunctions.GetItemByPosition(heroFunctions.GetHeroHorizontalPosition() + 1, heroFunctions.GetHeroVerticalPosition()));
                                heroFunctions.ClearRender();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 1);
                                heroFunctions.MoveHeroRight();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 2);
                                heroFunctions.SetDirectionRight();
                                break;
                            }
                            else if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition() + 1, heroFunctions.GetHeroVerticalPosition()) == 0)
                            {
                                heroFunctions.SetDirectionRight();
                                break;
                            }
                            else if ((levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition())) == 5 && (heroFunctions.GetHeroHorizontalPosition() + 2  == levelFunctions.GetLevelLength(levelFunctions.ReturnLevel())))
                            {
                                StartNewLevel();
                                break;
                            }
                            else
                            {
                                heroFunctions.ClearRender();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 1);
                                heroFunctions.MoveHeroRight();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 2);
                                heroFunctions.SetDirectionRight();
                                break;
                            }
                        case ConsoleKey.LeftArrow:
                            if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition() - 1, heroFunctions.GetHeroVerticalPosition()) == 4)
                            {
                                HeroStartsFight(enemyFunctions.GetEnemyByPosition(heroFunctions.GetHeroHorizontalPosition() - 1, heroFunctions.GetHeroVerticalPosition()));
                                heroFunctions.SetDirectionLeft();
                                break;
                            }
                            else if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition() - 1, heroFunctions.GetHeroVerticalPosition()) == 3)
                            {
                                HeroPicksItem(itemFunctions.GetItemByPosition(heroFunctions.GetHeroHorizontalPosition() - 1, heroFunctions.GetHeroVerticalPosition()));
                                heroFunctions.ClearRender();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 1);
                                heroFunctions.MoveHeroLeft();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 2);
                                heroFunctions.SetDirectionLeft();
                                break;
                            }
                            else if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition() - 1, heroFunctions.GetHeroVerticalPosition()) == 0)
                            {
                                heroFunctions.SetDirectionLeft();
                                break;
                            }
                            else
                            {
                                heroFunctions.ClearRender();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 1);
                                heroFunctions.MoveHeroLeft();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 2);
                                heroFunctions.SetDirectionLeft();
                                break;
                            }
                        case ConsoleKey.UpArrow:
                            if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition() - 1) == 4)
                            {
                                HeroStartsFight(enemyFunctions.GetEnemyByPosition(heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition() - 1));
                                heroFunctions.SetDirectionUp();
                                break;
                            }
                            else if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition() - 1) == 3)
                            {
                                HeroPicksItem(itemFunctions.GetItemByPosition(heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition() - 1));
                                heroFunctions.ClearRender();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 1);
                                heroFunctions.MoveHeroUp();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 2);
                                heroFunctions.SetDirectionUp();
                                break;
                            }
                            else if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition() - 1) == 0)
                            {
                                heroFunctions.SetDirectionUp();
                                break;
                            }
                            else
                            {
                                heroFunctions.ClearRender();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 1);
                                heroFunctions.MoveHeroUp();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 2);
                                heroFunctions.SetDirectionUp();
                                break;
                            }
                        case ConsoleKey.DownArrow:
                            if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition() + 1) == 4)
                            {
                                HeroStartsFight(enemyFunctions.GetEnemyByPosition(heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition() + 1));
                                heroFunctions.SetDirectionDown();
                                break;
                            }
                            else if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition() + 1) == 3)
                            {
                                HeroPicksItem(itemFunctions.GetItemByPosition(heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition() + 1));
                                heroFunctions.ClearRender();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 1);
                                heroFunctions.MoveHeroDown();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 2);
                                heroFunctions.SetDirectionDown();
                                break;
                            }
                            else if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition() + 1) == 0)
                            {
                                heroFunctions.SetDirectionDown();
                                break;
                            }
                            else
                            {
                                heroFunctions.ClearRender();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 1);
                                heroFunctions.MoveHeroDown();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 2);
                                heroFunctions.SetDirectionDown();
                                break;
                            }
                        case ConsoleKey.Spacebar:
                            {
                                if (heroFunctions.GetHero().arrows > 0 && enemyFunctions.GetEnemiesCount() > 0)
                                {
                                    HeroShootsArrow();
                                    heroFunctions.GetHero().arrows--;
                                    break;
                                }
                                else
                                {
                                    break;
                                }

                            }
                    }

                }

                ClearDeadEnemies();

                if (counter % 5 == 0)
                {
                    EnemiesAttack();
                    MoveArrowUp();
                    MoveArrowRight();
                    MoveArrowDown();
                    MoveArrowLeft();
                }

                if (counter % 10 == 0)
                {
                    EnemiesAttack();
                }
                if (counter % 12 == 0)
                {
                    MoveEnemies();
                }

                System.Threading.Thread.Sleep(20);
                counter++;
                heroFunctions.WriteHeroHealthAndAttack();
                LogLevel(levelNumber);
                if (enemyFunctions.GetEnemiesCount()<1)
                {
                    levelFunctions.OpenDoors(levelFunctions.ReturnLevel());
                }
                //Game Over
                if (heroFunctions.GameOver())
                {
                    needToRender = false;
                    Console.Clear();
                    GuiController guiController = new GuiController(levelNumber+1,heroFunctions.GetHero().enemiesKilled);
                    guiController.GameOver();
                }
            } while (needToRender);
        }

        public void MoveEnemies()
        {
            foreach (var enemy in enemyFunctions.ReturnEnemies())
            {
                //Move Right and Down
                if (((heroFunctions.GetHeroHorizontalPosition() - enemyFunctions.GetEnemyHorizontalPosition(enemy) < 10) && (heroFunctions.GetHeroHorizontalPosition() - enemyFunctions.GetEnemyHorizontalPosition(enemy) >= 0)) && ((heroFunctions.GetHeroVerticalPosition() - enemyFunctions.GetEnemyVerticalPosition(enemy) < 10) && (heroFunctions.GetHeroVerticalPosition() - enemyFunctions.GetEnemyVerticalPosition(enemy) >= 0)))
                {
                    if ((heroFunctions.GetHeroHorizontalPosition() - enemyFunctions.GetEnemyHorizontalPosition(enemy)) > (heroFunctions.GetHeroVerticalPosition() - enemyFunctions.GetEnemyVerticalPosition(enemy)))
                    {
                        if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy) + 1, enemyFunctions.GetEnemyVerticalPosition(enemy)) != 1)
                        {
                            goto Done;
                        }
                        else
                        {
                            enemyFunctions.ClearRender(enemy);
                            levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy), enemyFunctions.GetEnemyVerticalPosition(enemy), 1);
                            enemyFunctions.MoveEnemyRight(enemy);
                            levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy), enemyFunctions.GetEnemyVerticalPosition(enemy), 4);
                            enemyFunctions.Render();
                            goto Done;
                        }
                    }
                    else
                    {
                        if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy), enemyFunctions.GetEnemyVerticalPosition(enemy) + 1) != 1)
                        {
                            goto Done;
                        }
                        else
                        {
                            enemyFunctions.ClearRender(enemy);
                            levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy), enemyFunctions.GetEnemyVerticalPosition(enemy), 1);
                            enemyFunctions.MoveEnemyDown(enemy);
                            levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy), enemyFunctions.GetEnemyVerticalPosition(enemy), 4);
                            enemyFunctions.Render();
                            goto Done;
                        }
                    }
                Done:
                    ;
                }
                //Move Left and Down
                else if (((enemyFunctions.GetEnemyHorizontalPosition(enemy) - heroFunctions.GetHeroHorizontalPosition() < 10) && (enemyFunctions.GetEnemyHorizontalPosition(enemy) - heroFunctions.GetHeroHorizontalPosition() >= 0)) && ((heroFunctions.GetHeroVerticalPosition() - enemyFunctions.GetEnemyVerticalPosition(enemy) < 10) && (heroFunctions.GetHeroVerticalPosition() - enemyFunctions.GetEnemyVerticalPosition(enemy) >= 0)))
                {
                    if ((enemyFunctions.GetEnemyHorizontalPosition(enemy) - heroFunctions.GetHeroHorizontalPosition()) > (heroFunctions.GetHeroVerticalPosition() - enemyFunctions.GetEnemyVerticalPosition(enemy)))
                    {
                        if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy) - 1, enemyFunctions.GetEnemyVerticalPosition(enemy)) != 1)
                        {
                            goto Done;
                        }
                        else
                        {
                            enemyFunctions.ClearRender(enemy);
                            levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy), enemyFunctions.GetEnemyVerticalPosition(enemy), 1);
                            enemyFunctions.MoveEnemyLeft(enemy);
                            levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy), enemyFunctions.GetEnemyVerticalPosition(enemy), 4);
                            enemyFunctions.Render();
                            goto Done;
                        }
                    }
                    else
                    {
                        if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy), enemyFunctions.GetEnemyVerticalPosition(enemy) + 1) != 1)
                        {
                            goto Done;
                        }
                        else
                        {
                            enemyFunctions.ClearRender(enemy);
                            levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy), enemyFunctions.GetEnemyVerticalPosition(enemy), 1);
                            enemyFunctions.MoveEnemyDown(enemy);
                            levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy), enemyFunctions.GetEnemyVerticalPosition(enemy), 4);
                            enemyFunctions.Render();
                            goto Done;
                        }
                    }
                Done:
                    ;
                }
                //Move Right and Up
                else if (((heroFunctions.GetHeroHorizontalPosition() - enemyFunctions.GetEnemyHorizontalPosition(enemy) < 10) && (heroFunctions.GetHeroHorizontalPosition() - enemyFunctions.GetEnemyHorizontalPosition(enemy) >= 0)) && ((enemyFunctions.GetEnemyVerticalPosition(enemy) - heroFunctions.GetHeroVerticalPosition() < 10) && (enemyFunctions.GetEnemyVerticalPosition(enemy) - heroFunctions.GetHeroVerticalPosition() >= 0)))
                {
                    if ((heroFunctions.GetHeroHorizontalPosition() - enemyFunctions.GetEnemyHorizontalPosition(enemy)) > (enemyFunctions.GetEnemyVerticalPosition(enemy) - heroFunctions.GetHeroVerticalPosition()))
                    {
                        if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy) + 1, enemyFunctions.GetEnemyVerticalPosition(enemy)) != 1)
                        {
                            goto Done;
                        }
                        else
                        {
                            enemyFunctions.ClearRender(enemy);
                            levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy), enemyFunctions.GetEnemyVerticalPosition(enemy), 1);
                            enemyFunctions.MoveEnemyRight(enemy);
                            levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy), enemyFunctions.GetEnemyVerticalPosition(enemy), 4);
                            enemyFunctions.Render();
                            goto Done;
                        }
                    }
                    else
                    {
                        if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy), enemyFunctions.GetEnemyVerticalPosition(enemy) - 1) != 1)
                        {
                            goto Done;
                        }
                        else
                        {
                            enemyFunctions.ClearRender(enemy);
                            levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy), enemyFunctions.GetEnemyVerticalPosition(enemy), 1);
                            enemyFunctions.MoveEnemyUp(enemy);
                            levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy), enemyFunctions.GetEnemyVerticalPosition(enemy), 4);
                            enemyFunctions.Render();
                            goto Done;
                        }
                    }
                Done:
                    ;
                }
                //Move Left and Up
                else if (((enemyFunctions.GetEnemyHorizontalPosition(enemy) - heroFunctions.GetHeroHorizontalPosition() < 10) && (enemyFunctions.GetEnemyHorizontalPosition(enemy) - heroFunctions.GetHeroHorizontalPosition() >= 0)) && ((enemyFunctions.GetEnemyVerticalPosition(enemy) - heroFunctions.GetHeroVerticalPosition() < 10) && (enemyFunctions.GetEnemyVerticalPosition(enemy) - heroFunctions.GetHeroVerticalPosition() >= 0)))
                {
                    if ((enemyFunctions.GetEnemyHorizontalPosition(enemy) - heroFunctions.GetHeroHorizontalPosition()) > (heroFunctions.GetHeroVerticalPosition() - enemyFunctions.GetEnemyVerticalPosition(enemy)))
                    {
                        if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy) - 1, enemyFunctions.GetEnemyVerticalPosition(enemy)) != 1)
                        {
                            goto Done;
                        }
                        else
                        {
                            enemyFunctions.ClearRender(enemy);
                            levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy), enemyFunctions.GetEnemyVerticalPosition(enemy), 1);
                            enemyFunctions.MoveEnemyLeft(enemy);
                            levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy), enemyFunctions.GetEnemyVerticalPosition(enemy), 4);
                            enemyFunctions.Render();
                            goto Done;
                        }
                    }
                    else
                    {
                        if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy), enemyFunctions.GetEnemyVerticalPosition(enemy) - 1) != 1)
                        {
                            goto Done;
                        }
                        else
                        {
                            enemyFunctions.ClearRender(enemy);
                            levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy), enemyFunctions.GetEnemyVerticalPosition(enemy), 1);
                            enemyFunctions.MoveEnemyUp(enemy);
                            levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemy), enemyFunctions.GetEnemyVerticalPosition(enemy), 4);
                            enemyFunctions.Render();
                            goto Done;
                        }
                    }
                Done:
                    ;
                }
            }
        }

        public void EnemiesAttack()
        {
            foreach (var enemy in enemyFunctions.ReturnEnemies())
            {
                Hero hero = heroFunctions.GetHero();
                //Attack Up
                if ((enemyFunctions.GetEnemyHorizontalPosition(enemy) == heroFunctions.GetHeroHorizontalPosition()) && (enemyFunctions.GetEnemyVerticalPosition(enemy) + 1 == heroFunctions.GetHeroVerticalPosition()))
                {
                    hero.Health = hero.Health - (enemy.Attack * (1 - (hero.defence / 100)));
                }
                //Attack Down
                if ((enemyFunctions.GetEnemyHorizontalPosition(enemy) == heroFunctions.GetHeroHorizontalPosition()) && (enemyFunctions.GetEnemyVerticalPosition(enemy) - 1 == heroFunctions.GetHeroVerticalPosition()))
                {
                    hero.Health = hero.Health - (enemy.Attack * (1 - (hero.defence / 100)));
                }
                //Attack Left
                if ((enemyFunctions.GetEnemyHorizontalPosition(enemy) + 1 == heroFunctions.GetHeroHorizontalPosition()) && (enemyFunctions.GetEnemyVerticalPosition(enemy) == heroFunctions.GetHeroVerticalPosition()))
                {
                    hero.Health = hero.Health - (enemy.Attack * (1 - (hero.defence / 100)));
                }
                //Attack Right
                if ((enemyFunctions.GetEnemyHorizontalPosition(enemy) - 1 == heroFunctions.GetHeroHorizontalPosition()) && (enemyFunctions.GetEnemyVerticalPosition(enemy) == heroFunctions.GetHeroVerticalPosition()))
                {
                    hero.Health = hero.Health - (enemy.Attack * (1 - (hero.defence / 100)));
                }
            }
        }

        public void HeroStartsFight(Enemy enemy)
        {
            Hero hero = heroFunctions.GetHero();

            enemy.Health = enemy.Health - hero.Attack;
        }
        public void ClearDeadEnemies()
        {
            Hero hero = heroFunctions.GetHero();
            List<Enemy> enemies = enemyFunctions.ReturnEnemies();
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].Health <= 0)
                {
                    levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), enemyFunctions.GetEnemyHorizontalPosition(enemies[i]), enemyFunctions.GetEnemyVerticalPosition(enemies[i]), 1);
                    enemyFunctions.ClearRender(enemies[i]);
                    enemyFunctions.DeleteEnemy(enemies[i]);
                    hero.enemiesKilled++;
                }
            }
        }
        public void StartNewLevel()
        {
            Hero hero = heroFunctions.GetHero();
            levelNumber++;
            if ((hero.Health + 20) >= heroBaseHealth)
            {
                hero.Health = heroBaseHealth;
            }
            else
            {
                hero.Health = hero.Health + 20;
            }
            hero.Attack = heroBaseAttack + levelNumber;
            enemyFunctions.ClearEnemies();
            itemFunctions.ClearItems();
            StartGameLoop();
        }
        public void LogLevel(int levelNumber)
        {
            Console.SetCursorPosition(60, 6);
            Console.WriteLine("                                ");
            Console.SetCursorPosition(60, 6);
            Console.WriteLine("Level " + (levelNumber+1));
        }
        public void HeroPicksItem(Item item)
        {
            Hero hero = heroFunctions.GetHero();
            double healthBefore = hero.Health;
            if (item.type == 0)
            {
                if ((hero.Health + item.Health) >= heroBaseHealth)
                {
                    hero.Health = heroBaseHealth;
                }
                else
                {
                    hero.Health = hero.Health + item.Health;
                }
                itemFunctions.DeleteItem(item);
                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), itemFunctions.GetItemHorizontalPosition(item), itemFunctions.GetItemVerticalPosition(item), 1);
                Console.SetCursorPosition(60, 7);
                Console.WriteLine("                                                                  ");
                Console.SetCursorPosition(60, 7);
                Console.WriteLine("You picked a " + item.Name + ". You gained " + Math.Ceiling((hero.Health - healthBefore)) + " health.");
            }
            else if (item.type == 1)
            {
                hero.Attack = heroBaseAttack + item.Attack;
                itemFunctions.DeleteItem(item);
                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), itemFunctions.GetItemHorizontalPosition(item), itemFunctions.GetItemVerticalPosition(item), 1);
                Console.SetCursorPosition(60, 7);
                Console.WriteLine("                                                                 ");
                Console.SetCursorPosition(60, 7);
                Console.WriteLine("You picked a " + item.Name + ". Your attack increased by " + Math.Ceiling(item.Attack) + ".");
            }
            else if (item.type == 2)
            {
                hero.defence = item.defence;
                itemFunctions.DeleteItem(item);
                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), itemFunctions.GetItemHorizontalPosition(item), itemFunctions.GetItemVerticalPosition(item), 1);
                Console.SetCursorPosition(60, 7);
                Console.WriteLine("                                                                ");
                Console.SetCursorPosition(60, 7);
                Console.WriteLine("You picked " + item.Name + ". Your defence increased by " + Math.Ceiling(item.defence) + ".");
            }
            else if (item.type == 3)
            {
                hero.arrows = hero.arrows + item.count;
                hero.arrowAttack = item.Attack;
                itemFunctions.DeleteItem(item);
                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), itemFunctions.GetItemHorizontalPosition(item), itemFunctions.GetItemVerticalPosition(item), 1);
                Console.SetCursorPosition(60, 7);
                Console.WriteLine("                                                               ");
                Console.SetCursorPosition(60, 7);
                Console.WriteLine("You picked up " + item.count + " arrows.");
            }
        }

        public void HeroShootsArrow()
        {
            Hero hero = heroFunctions.GetHero();
            // Shoot Up
            if (hero.direction == 0 )
            {
                Arrow newArrow = new Arrow("Arrow" + arrowFunctions.GetarrowsCount(),0, heroFunctions.GetHeroHorizontalPosition(),heroFunctions.GetHeroVerticalPosition()-1,0,2);
                arrowFunctions.AddArrow(newArrow);
            }
            // Shoot Right
            else if (hero.direction == 1)
            {
                Arrow newArrow = new Arrow("Arrow" + arrowFunctions.GetarrowsCount(), 1, heroFunctions.GetHeroHorizontalPosition() + 1, heroFunctions.GetHeroVerticalPosition(), 0, 2);
                arrowFunctions.AddArrow(newArrow);
            }
            // Shoot Up
            if (hero.direction == 2)
            {
                Arrow newArrow = new Arrow("Arrow" + arrowFunctions.GetarrowsCount(), 2, heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition() + 1, 0, 2);
                arrowFunctions.AddArrow(newArrow);
            }
            // Shoot Right
            else if (hero.direction == 3)
            {
                Arrow newArrow = new Arrow("Arrow" + arrowFunctions.GetarrowsCount(), 3, heroFunctions.GetHeroHorizontalPosition() - 1, heroFunctions.GetHeroVerticalPosition(), 0, 2);
                arrowFunctions.AddArrow(newArrow);
            }

        }
        public void MoveArrowUp()
        {
            List<Arrow> arrows = arrows = arrowFunctions.Returnarrows();
            for (int i = 0; i < arrows.Count; i++)
            {
                if (arrows[i].direction == 0)
                {
                    if ((levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]),arrowFunctions.GetArrowVerticalPosition(arrows[i]) - 1)) == 0)
                    {
                        arrowFunctions.ClearRender(arrows[i]);
                        levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]), 1);
                        arrowFunctions.DeleteArrow(arrows[i]);
                    }
                    else if ((levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]) - 1)) == 4)
                    {
                        arrowFunctions.ClearRender(arrows[i]);
                        enemyFunctions.GetEnemyByPosition(arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]) - 1).Health = enemyFunctions.GetEnemyByPosition(arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]) - 1).Health - heroFunctions.GetHero().arrowAttack;
                        levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]), 1);
                        arrowFunctions.DeleteArrow(arrows[i]);
                    }
                    else
                    {
                        arrowFunctions.ClearRender(arrows[i]);
                        levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]), 1);
                        arrowFunctions.MoveArrowUp(arrows[i]);
                        levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]), 6);
                        arrowFunctions.Render();
                    }
                }
            }
        }
        public void MoveArrowRight()
        {
            List<Arrow> arrows = arrows = arrowFunctions.Returnarrows();
            for (int i = 0; i < arrows.Count; i++)
            {
                if (arrows[i].direction == 1)
                {
                    if ((levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]) + 1, arrowFunctions.GetArrowVerticalPosition(arrows[i]))) == 0)
                    {
                        arrowFunctions.ClearRender(arrows[i]);
                        levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]), 1);
                        arrowFunctions.DeleteArrow(arrows[i]);
                    }
                    else if ((levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]) + 1, arrowFunctions.GetArrowVerticalPosition(arrows[i]))) == 4)
                    {
                        arrowFunctions.ClearRender(arrows[i]);
                        enemyFunctions.GetEnemyByPosition(arrowFunctions.GetArrowHorizontalPosition(arrows[i]) + 1, arrowFunctions.GetArrowVerticalPosition(arrows[i])).Health = enemyFunctions.GetEnemyByPosition(arrowFunctions.GetArrowHorizontalPosition(arrows[i]) + 1, arrowFunctions.GetArrowVerticalPosition(arrows[i])).Health - heroFunctions.GetHero().arrowAttack;
                        levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]), 1);
                        arrowFunctions.DeleteArrow(arrows[i]);
                    }
                    else
                    {
                        arrowFunctions.ClearRender(arrows[i]);
                        levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]), 1);
                        arrowFunctions.MoveArrowRight(arrows[i]);
                        levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]), 6);
                        arrowFunctions.Render();
                    }
                }
            }
        }
        public void MoveArrowDown()
        {
            List<Arrow> arrows = arrows = arrowFunctions.Returnarrows();
            for (int i = 0; i < arrows.Count; i++)
            {
                if (arrows[i].direction == 2)
                {
                    if ((levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]) + 1)) == 0)
                    {
                        arrowFunctions.ClearRender(arrows[i]);
                        levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]), 1);
                        arrowFunctions.DeleteArrow(arrows[i]);
                    }
                    else if ((levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]) + 1)) == 4)
                    {
                        arrowFunctions.ClearRender(arrows[i]);
                        enemyFunctions.GetEnemyByPosition(arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]) + 1).Health = enemyFunctions.GetEnemyByPosition(arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]) + 1).Health - heroFunctions.GetHero().arrowAttack;
                        levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]), 1);
                        arrowFunctions.DeleteArrow(arrows[i]);
                    }
                    else
                    {
                        arrowFunctions.ClearRender(arrows[i]);
                        levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]), 1);
                        arrowFunctions.MoveArrowDown(arrows[i]);
                        levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]), 6);
                        arrowFunctions.Render();
                    }
                }
            }
        }
        public void MoveArrowLeft()
        {
            List<Arrow> arrows = arrows = arrowFunctions.Returnarrows();
            for (int i = 0; i < arrows.Count; i++)
            {
                if (arrows[i].direction == 3)
                {
                    if ((levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]) - 1, arrowFunctions.GetArrowVerticalPosition(arrows[i]))) == 0)
                    {
                        arrowFunctions.ClearRender(arrows[i]);
                        levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]), 1);
                        arrowFunctions.DeleteArrow(arrows[i]);
                    }
                    else if ((levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]) - 1, arrowFunctions.GetArrowVerticalPosition(arrows[i]))) == 4)
                    {
                        arrowFunctions.ClearRender(arrows[i]);
                        enemyFunctions.GetEnemyByPosition(arrowFunctions.GetArrowHorizontalPosition(arrows[i]) - 1, arrowFunctions.GetArrowVerticalPosition(arrows[i])).Health = enemyFunctions.GetEnemyByPosition(arrowFunctions.GetArrowHorizontalPosition(arrows[i]) - 1, arrowFunctions.GetArrowVerticalPosition(arrows[i])).Health - heroFunctions.GetHero().arrowAttack;
                        levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]), 1);
                        arrowFunctions.DeleteArrow(arrows[i]);
                    }
                    else
                    {
                        arrowFunctions.ClearRender(arrows[i]);
                        levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]), 1);
                        arrowFunctions.MoveArrowLeft(arrows[i]);
                        levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), arrowFunctions.GetArrowHorizontalPosition(arrows[i]), arrowFunctions.GetArrowVerticalPosition(arrows[i]), 6);
                        arrowFunctions.Render();
                    }
                }
            }
        }
    }
}
