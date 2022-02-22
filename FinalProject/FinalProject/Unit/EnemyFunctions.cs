using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Unit
{
    class EnemyFunctions
    {
        private List<Enemy> enemies = new List<Enemy>();
        private Enemy enemy;

        public void AddEnemy(Enemy enemy)
        {
            enemies.Add(enemy);
        }
        public Enemy GetEnemyByPosition(int x, int y)
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.X == x && enemy.Y == y)
                {
                    return enemy;
                }
            }
            return null;
        }
        public void Render()
        {
            foreach (Enemy enemy in enemies)
            {

                enemy.Render(enemy.X, enemy.Y, '&');
            }
        }
        public List<Enemy> ReturnEnemies()
        {
            return enemies;
        }
        public void MoveEnemyRight(Enemy enemy)
        {
            enemy.MoveRight();
        }

        public void MoveEnemyLeft(Enemy enemy)
        {
            enemy.MoveLeft();
        }

        public void MoveEnemyUp(Enemy enemy)
        {
            enemy.MoveUp();
        }

        public void MoveEnemyDown(Enemy enemy)
        {
            enemy.MoveDown();
        }
        public int GetEnemyHorizontalPosition(Enemy enemy)
        {
            return enemy.X;
        }
        public int GetEnemyVerticalPosition(Enemy enemy)
        {
            return enemy.Y;
        }
        public void ClearRender(Enemy enemy)
        {
            enemy.ClearRender(enemy.X, enemy.Y);
        }
        public void DeleteEnemy(Enemy enemy)
        {
            enemies.Remove(enemy);
        }
        public int GetEnemiesCount()
        {
            int enemiesCount = enemies.Count;
            return enemiesCount;
        }
        public void ClearEnemies()
        {
            enemies.Clear();
        }
    }
}
