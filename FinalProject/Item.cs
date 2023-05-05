using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGameNavigation
{
    public class Item
    {
        public string ID;

        public string Name;
        public string Description;
        public string ImagePath { get; set; }
        public Item(string id, string name, string description, string image)
        {
            ID = id;
            Name = name;
            Description = description;
            ImagePath = image;
        }

    }
}