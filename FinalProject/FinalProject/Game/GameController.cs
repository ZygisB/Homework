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
        int heroBaseAttack = 5;
        int heroBaseHealth = 100;
        int counter = 0;
        int levelNumber = 0;

        public void StartGame()
        {
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
            Random rnd = new Random();

            int rndPotion = rnd.Next(0, 100);
            int rndSword = rnd.Next(0, 100);
            int rndArmor = rnd.Next(0, 100);

            if (rndPotion > 0)
            {
                do
                {
                    int x = rnd.Next(0, 49);
                    int y = rnd.Next(0, 39);
                    if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), x, y) == 1)
                    {
                        itemFunctions.GeneratePotion(x, y);
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
                        itemFunctions.GenerateSword(x, y);
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
                        itemFunctions.GenerateArmor(x, y);
                        armorCount++;
                        levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), x, y, 3);
                    }
                } while (armorCount < 1);
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
                            needToRender = false;
                            break;
                        case ConsoleKey.RightArrow:
                            if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition() + 1, heroFunctions.GetHeroVerticalPosition()) == 4)
                            {
                                HeroStartsFight(enemyFunctions.GetEnemyByPosition(heroFunctions.GetHeroHorizontalPosition() + 1, heroFunctions.GetHeroVerticalPosition()));
                                break;
                            }
                            else if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition() + 1, heroFunctions.GetHeroVerticalPosition()) == 3)
                            {
                                HeroPicksItem(itemFunctions.GetItemByPosition(heroFunctions.GetHeroHorizontalPosition() + 1, heroFunctions.GetHeroVerticalPosition()));
                                heroFunctions.ClearRender();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 1);
                                heroFunctions.MoveHeroRight();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 2);
                                break;
                            }
                            else if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition() + 1, heroFunctions.GetHeroVerticalPosition()) == 0)
                            {
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
                                break;
                            }
                        case ConsoleKey.LeftArrow:
                            if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition() - 1, heroFunctions.GetHeroVerticalPosition()) == 4)
                            {
                                HeroStartsFight(enemyFunctions.GetEnemyByPosition(heroFunctions.GetHeroHorizontalPosition() - 1, heroFunctions.GetHeroVerticalPosition()));
                                break;
                            }
                            else if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition() - 1, heroFunctions.GetHeroVerticalPosition()) == 3)
                            {
                                HeroPicksItem(itemFunctions.GetItemByPosition(heroFunctions.GetHeroHorizontalPosition() - 1, heroFunctions.GetHeroVerticalPosition()));
                                heroFunctions.ClearRender();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 1);
                                heroFunctions.MoveHeroLeft();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 2);
                                break;
                            }
                            else if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition() - 1, heroFunctions.GetHeroVerticalPosition()) == 0)
                            {
                                break;
                            }
                            else
                            {
                                heroFunctions.ClearRender();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 1);
                                heroFunctions.MoveHeroLeft();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 2);
                                break;
                            }
                        case ConsoleKey.UpArrow:
                            if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition() - 1) == 4)
                            {
                                HeroStartsFight(enemyFunctions.GetEnemyByPosition(heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition() - 1));
                                break;
                            }
                            else if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition() - 1) == 3)
                            {
                                HeroPicksItem(itemFunctions.GetItemByPosition(heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition() - 1));
                                heroFunctions.ClearRender();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 1);
                                heroFunctions.MoveHeroUp();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 2);
                                break;
                            }
                            else if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition() - 1) == 0)
                            {
                                break;
                            }
                            else
                            {
                                heroFunctions.ClearRender();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 1);
                                heroFunctions.MoveHeroUp();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 2);
                                break;
                            }
                        case ConsoleKey.DownArrow:
                            if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition() + 1) == 4)
                            {
                                HeroStartsFight(enemyFunctions.GetEnemyByPosition(heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition() + 1));
                                break;
                            }
                            else if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition() + 1) == 3)
                            {
                                HeroPicksItem(itemFunctions.GetItemByPosition(heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition() + 1));
                                heroFunctions.ClearRender();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 1);
                                heroFunctions.MoveHeroDown();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 2);
                                break;
                            }
                            else if (levelFunctions.GetCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition() + 1) == 0)
                            {
                                break;
                            }
                            else
                            {
                                heroFunctions.ClearRender();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 1);
                                heroFunctions.MoveHeroDown();
                                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), heroFunctions.GetHeroHorizontalPosition(), heroFunctions.GetHeroVerticalPosition(), 2);
                                break;
                            }
                    }

                }

                ClearDeadEnemies();

                if (counter % 10 == 0)
                {
                    EnemiesAttack();
                }
                if (counter % 15 == 0)
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
            Console.SetCursorPosition(60, 5);
            Console.WriteLine("                                ");
            Console.SetCursorPosition(60, 5);
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
                Console.SetCursorPosition(60, 6);
                Console.WriteLine("                                                     ");
                Console.SetCursorPosition(60, 6);
                Console.WriteLine("You picked a " + item.Name + ". You gained " + Math.Ceiling((hero.Health - healthBefore)) + " health.");
            }
            else if (item.type == 1)
            {
                hero.Attack = heroBaseAttack + item.Attack;
                itemFunctions.DeleteItem(item);
                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), itemFunctions.GetItemHorizontalPosition(item), itemFunctions.GetItemVerticalPosition(item), 1);
                Console.SetCursorPosition(60, 6);
                Console.WriteLine("                                                     ");
                Console.SetCursorPosition(60, 6);
                Console.WriteLine("You picked a " + item.Name + ". Your attack increased by " + Math.Ceiling(item.Attack) + ".");
            }
            else if (item.type == 2)
            {
                hero.defence = item.defence;
                itemFunctions.DeleteItem(item);
                levelFunctions.ChangeCellInfo(levelFunctions.ReturnLevel(), itemFunctions.GetItemHorizontalPosition(item), itemFunctions.GetItemVerticalPosition(item), 1);
                Console.SetCursorPosition(60, 6);
                Console.WriteLine("                                                    ");
                Console.SetCursorPosition(60, 6);
                Console.WriteLine("You picked " + item.Name + ". Your defence increased by " + Math.Ceiling(item.defence) + ".");
            }
        }
    }
}
