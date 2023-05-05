using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGameNavigation
{
    public class Player
    {
        public List<string> Inventory;

        public Player()
        {
            Inventory = new List<string>();
        }
        public void InventoryAdd(string item)
        {
            Inventory.Add(item);
        }
        public void InventoryRemove(string item)
        {
            Inventory.Remove(item);
        }
        public void Trade(string item, string requiredItem)
        {
            InventoryAdd(item);
            InventoryRemove(requiredItem);
        }
        public bool SearchInventory(string word)
        {
            foreach (var i in Inventory)
            {
                if (i.Contains(word))
                {
                    return true;
                }
            }
            return false;
        }
    }
}