using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Unit
{
    class ArrowFunctions
    {
        private List<Arrow> arrows = new List<Arrow>();

        public void AddArrow(Arrow arrow)
        {
            arrows.Add(arrow);
        }
        public Arrow GetArrowByPosition(int x, int y)
        {
            foreach (Arrow arrow in arrows)
            {
                if (arrow.X == x && arrow.Y == y)
                {
                    return arrow;
                }
            }
            return null;
        }
        public void Render()
        {
            foreach (Arrow arrow in arrows)
            {
                if (arrow.direction == 0 || arrow.direction == 2)
                {
                    arrow.Render(arrow.X, arrow.Y, '|');
                }
                else
                {
                    arrow.Render(arrow.X, arrow.Y, '-');
                }
            }
        }
        public List<Arrow> Returnarrows()
        {
            return arrows;
        }
        public void MoveArrowRight(Arrow arrow)
        {
            arrow.MoveRight();
        }

        public void MoveArrowLeft(Arrow arrow)
        {
            arrow.MoveLeft();
        }

        public void MoveArrowUp(Arrow arrow)
        {
            arrow.MoveUp();
        }

        public void MoveArrowDown(Arrow arrow)
        {
            arrow.MoveDown();
        }
        public int GetArrowHorizontalPosition(Arrow arrow)
        {
            return arrow.X;
        }
        public int GetArrowVerticalPosition(Arrow arrow)
        {
            return arrow.Y;
        }
        public void ClearRender(Arrow arrow)
        {
            arrow.ClearRender(arrow.X, arrow.Y);
        }
        public void DeleteArrow(Arrow arrow)
        {
            arrows.Remove(arrow);
        }
        public int GetarrowsCount()
        {
            int arrowsCount = arrows.Count;
            return arrowsCount;
        }
        public void Cleararrows()
        {
            arrows.Clear();
        }
    }
}
