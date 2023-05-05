using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGameNavigation
{
    public class Game
    {
        public Player player = new Player();
        public List<Item> Items = new List<Item>();

        public List<Room> Rooms = new List<Room>();
        public List<string> NPCInventory = new List<string>();
        public Room CurrentRoom { get; set; }
        public NPC CurrentNPC { get; set; }
        public Game()
        {
            // Creating items for the rooms to use
            Item blanket = new Item("BlanketImage", "Blanket", "A soft blanket that is still warm from sleeping with it.", "Media/Blanket.png");
            Item FluffyPillow = new Item("FlufflyPillowImage", "Fluffy Pillow", "A very soft and fluffly pillow that you lay your head in.", "Media/FlufflyPillow.png");
            Item BowlOfCereal = new Item("BowlofCerealImage", "Bowl of Cereal", "A bowl of your favorite cereal filled with milk.", "Media/BowlofCereal.png");
            Item Spoon = new Item("SpoonImage", "Spoon", "A spoon that you can use to scoop up and then eat your cereal with.", "Media/Spoon.png");
            Item TVRemote = new Item("TVRemoteImage", "TV Remote", "Just the thing you need to turn on the TV.", "Media/TVRemote.png");
            Item WeirdLetter = new Item("WeridLetterImage", "Roommate's Letter", "A weird letter found on the couch. Reading it further, it appears to be your roomate's. It's a love confession to someone?", "Media/Weirdletter.png");
            Item RocketLauncher = new Item("RocketLauncherImage", "Rocket Launcher", "Just have fun", "Media/RocketLauncher.png");
            Item AfternoonLunch = new Item("AfternoonLunchImage", "Afternoon lunch", "A nice stack of sandwiches that taste great", "Media/AfternoonLunch.png");
            Item SwitchController = new Item("SwitchControllerImage", "Second Switch Controller", "Lets you play games on the go.", "Media/SwitchController.png");

            Items = new List<Item>() { blanket, FluffyPillow, BowlOfCereal, Spoon, TVRemote, WeirdLetter, RocketLauncher, AfternoonLunch, SwitchController };

            // Creating NPCs
            NPC LivingRoomNPC = new NPC("Gerard", "Wears a black overcoat, a sound of metals hitting each other resonantes about.", RocketLauncher, blanket);
            NPC BedRoomNPC = new NPC("Sister", "Lying in bed, playing on the Switch.", SwitchController, WeirdLetter);
            NPC KitchenRoomNPC = new NPC("Mother", "Your mom. Cooking up a nice afternoon meal", AfternoonLunch, BowlOfCereal);

            Room Bedroom = new Room()
            {
                Name = "Bedroom",
                Description = "A room where beds are put so people can sleep comfortably.",
                Items = { blanket, FluffyPillow },

                ImagePath = "Media/bedroom.jpg",
                SouvenierNpc = BedRoomNPC
            };
            Rooms.Add(Bedroom);

            Room Kitchen = new Room()
            {
                Name = "Kitchen",
                Description = "The place where you cook your food or hide the candies from the kids.",
                Items = { BowlOfCereal, Spoon },
                ImagePath = "Media/kitchen.png",
                SouvenierNpc = KitchenRoomNPC
            };
            Rooms.Add(Kitchen);

            Room LivingRoom = new Room()
            {
                Name = "Living Room",
                Description = "Where you want to be: being lazy on a couch watching television programs.",
                Items = { TVRemote, WeirdLetter },
                ImagePath = "Media/livingroom.png",
                SouvenierNpc = LivingRoomNPC
            };
            Rooms.Add(LivingRoom);


        }
    }
}
