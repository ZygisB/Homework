using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Unit
{
    class ItemFunctions
    {
        private List<Item> items = new List<Item>();
        private Item item;

        public void AddItem(Item item)
        {
            items.Add(item);
        }
        public void GeneratePotion(int x, int y)
        {
            Item newPotion = new Item("Potion", 0, x, y, 10, 0, 0);
            items.Add(newPotion);
        }
        public void GenerateSword(int x, int y)
        {
            Item newSword = new Item("Sword", 1, x, y, 0, 3, 0);
            items.Add(newSword);
        }
        public void GenerateArmor(int x, int y)
        {
            Item newArmor = new Item("Armor", 2, x, y, 0, 0, 10);
            items.Add(newArmor);
        }
        public void Render()
        {
            foreach (Item item in items)
            {
                if (item.type == 0)
                {
                    item.Render(item.X, item.Y, '+');
                }
                else if (item.type == 1)
                {
                    item.Render(item.X, item.Y, '|');
                }
                else if (item.type == 2)
                {
                    item.Render(item.X, item.Y, '~');
                }
            }
        }
        public void ClearItems()
        {
            items.Clear();
        }
        public Item GetItemByPosition(int x, int y)
        {
            foreach (Item item in items)
            {
                if (item.X == x && item.Y == y)
                {
                    return item;
                }
            }
            return null;
        }
        public void DeleteItem(Item item)
        {
            items.Remove(item);
        }
        public int GetItemHorizontalPosition(Item item)
        {
            return item.X;
        }
        public int GetItemVerticalPosition(Item item)
        {
            return item.Y;
        }
    }
}
