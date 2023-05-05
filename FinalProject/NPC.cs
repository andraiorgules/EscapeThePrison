using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGameNavigation
{
    public class NPC
    {
        public string Name;
        public string Description;
        public Item NPCItem { get; set; }
        public Item RequiredItem { get; set; }
        public NPC(string name, string description, Item item, Item requiredItem)
        {
            Name = name;
            Description = description;
            //Items.Add(item);
            NPCItem = item;
            RequiredItem = requiredItem;
        }



    }
}
