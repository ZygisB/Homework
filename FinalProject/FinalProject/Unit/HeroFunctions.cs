using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Unit
{
    class HeroFunctions
    {
        private Hero hero;

        public void SetHero(Hero hero)
        {
            this.hero = hero;
        }

        public Hero GetHero()
        {
            return hero;
        }

        public void MoveHeroRight()
        {
            hero.MoveRight();
        }

        public void MoveHeroLeft()
        {
            hero.MoveLeft();
        }

        public void MoveHeroUp()
        {
            hero.MoveUp();
        }

        public void MoveHeroDown()
        {
            hero.MoveDown();
        }
        public void Render()
        {
            hero.Render(hero.X, hero.Y, '@');
        }
        public void ClearRender()
        {
            hero.ClearRender(hero.X, hero.Y);
        }
        public int GetHeroHorizontalPosition()
        {
            return hero.X;
        }
        public int GetHeroVerticalPosition()
        {
            return hero.Y;
        }
        public void WriteHeroHealthAndAttack()
        {
            Console.SetCursorPosition(60, 0);
            Console.WriteLine("                                   ");
            Console.SetCursorPosition(60, 0);
            Console.WriteLine("Health: " + Math.Ceiling(hero.Health));
            Console.SetCursorPosition(60, 1);
            Console.WriteLine("                                   ");
            Console.SetCursorPosition(60, 1);
            Console.WriteLine("Attack: " + Math.Ceiling(hero.Attack));
            Console.SetCursorPosition(60, 2);
            Console.WriteLine("                                   ");
            Console.SetCursorPosition(60, 2);
            Console.WriteLine("Defence: " + Math.Ceiling(hero.defence));
            Console.SetCursorPosition(60, 4);
            Console.WriteLine("                                   ");
            Console.SetCursorPosition(60, 4);
            Console.WriteLine("Enemies killed: " + hero.enemiesKilled);
            Console.SetCursorPosition(60, 3);
            Console.WriteLine("                                   ");
            Console.SetCursorPosition(60, 3);
            Console.WriteLine("Arrows: " + hero.arrows);
        }
        public void SetHeroPosition(int x, int y)
        {
            hero.X = x;
            hero.Y = y;
        }
        public bool GameOver()
        {
            bool gameOver = false;

            if (hero.Health <=0)
            {
                gameOver = true;
            }
            return gameOver;
        }
        public void SetDirectionUp()
        {
            hero.direction = 0;
        }
        public void SetDirectionRight()
        {
             hero.direction = 1;
        }
        public void SetDirectionDown()
        {
            hero.direction = 2;
        }
        public void SetDirectionLeft()
        {
            hero.direction = 3;
        }
        public void ClearHero()
        {
        }
    }
}
