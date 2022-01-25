using Game.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Game
{
    class GameScreen
    {
        public int width { get; set; }
        public int height { get; set; }
        private Hero hero; 
        private List<Enemy> enemies = new List<Enemy>();
        private List<Bullet> bullets = new List<Bullet>();

        public GameScreen(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

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

        public void AddEnemy(Enemy enemy)
        {
            enemies.Add(enemy);
        }

        public bool MoveAllEnemiesDown()
        {
            bool cityDamaged = false;
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].MoveDown();
                if (enemies[i].Y > height)
                {
                    enemies.Remove(enemies[i]);
                    cityDamaged = true;
                }
            }
            return cityDamaged;
        }

        public Enemy GetEnemyById (int id)
        {
            foreach (Enemy enemy in enemies)
            {
                if(enemy.GetId()==id)
                {
                    return enemy;
                }
            }
            return null;
        }
        public void Render()
        {
            //hero.PrintInfo();
            foreach (Enemy enemy in enemies)
            {
                //enemy.PrintInfo();
                    enemy.Render(enemy.X, enemy.Y, '&');
            }
            foreach (Bullet bullet in bullets)
            {
                bullet.Render(bullet.X, bullet.Y, '|');
            }
            hero.Render(hero.X, hero.Y, '@');
        }
        public void ClearEnemiesBullets()
        {
            enemies.Clear();
            bullets.Clear();
        }

        public bool GameOver()
        {
            bool gameOver = false;
            foreach (Enemy enemy in enemies)
            {
                if (hero.X == enemy.X & hero.Y == enemy.Y)
                {
                    gameOver = true;
                }
            }
            return gameOver;
        }
        public void AddBullet(Bullet bullet)
        {
            bullets.Add(bullet);
        }

        public void MoveAllBulletUp()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].MoveUp();
                if (bullets[i].Y <= 0)
                {
                    bullets.Remove(bullets[i]);
                }
            }
        }
        public int GetHeroHorizontalPosition()
        {
            return hero.X;
        }
        public int GetHeroVerticalPosition()
        {
            return hero.Y;
        }
        public bool DestroyEnemy()
        {
            bool enemyDestroyed = false;
            for (int z = 0; z < bullets.Count; z++)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i].X == bullets[z].X & enemies[i].Y >= bullets[z].Y)
                    {
                        enemies.Remove(enemies[i]);
                        bullets.Remove(bullets[z]);
                        enemyDestroyed = true;
                        //Needed to add fake bullet to solve error when bullets.Count = 0
                        Bullet fakeBullet = new Bullet(0, 0, "Fake Bullet");
                        AddBullet(fakeBullet);
                    }
                }
            }
            return enemyDestroyed;
        }
    }
}
