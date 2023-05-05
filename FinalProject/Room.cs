using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGameNavigation
{
    public class Room
    {

        public string Name;
        public string Description;

        public NPC SouvenierNpc { get; set; }
        public List<Item> Items = new List<Item>();
        public string ImagePath { get; set; }

        public bool Visited = false;
    }
}
