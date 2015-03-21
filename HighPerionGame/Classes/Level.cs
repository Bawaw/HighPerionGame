using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HighPerionGame
{
    static class Level
    {
        private static Room[,] rooms;

        #region properties

        public static Room[,] Rooms
        {
            get { return rooms; }
        }

        #endregion

        public static void Initialize()
        {
            BuildLevel();
        }

        private static void BuildLevel()
        {
            rooms = new Room[2, 2];

            Room room;
            Item item;


            ////////////////////////////////////////////////////////////////////////////////////////

            // Create red room
            room = new Room();

            // Assign this room to location 0,0
            rooms[0, 0] = room;

            // setup the room
            room.Title = "Red Room";
            room.Description = "you have entered the Red room, there is a locked door to the South.";
            room.AddExit(Direction.East);
            
            //create a new item
            item = new Item();

            // setup the item

            item.Title = "Blue Ball";
            item.PickupText = "You've picked up a funny looking Blue Ball!";
            item.Weight = 1;

            //add item to room
            room.Item.Add(item);


            ////////////////////////////////////////////////////////////////////////////////////////

            // Create blue room
            room = new Room();

            // Assign this room to location 1,0
            rooms[1, 0] = room;

            // setup the room
            room.Title = "Blue Room";
            room.Description = "you have entered the blue room";
            room.AddExit(Direction.West);
            room.AddExit(Direction.South);

            item = new Item();
            item.Title = "Anvil";
            item.PickupText = "You Strugle To Pickup The Anvil";
            item.Weight = 6;
            room.Item.Add(item);

            item = new Item();
            item.Title = "Green Ball";
            item.PickupText = "You've picked up a funny looking Green Ball!";
            item.Weight = 1;
            room.Item.Add(item);

            item = new Item();
            item.Title = "Golden Key";
            item.PickupText = "You've picked up a key";
            item.Weight = 1;
            room.Item.Add(item);

          

            ////////////////////////////////////////////////////////////////////////////////////////

            // Create yellow room
            room = new Room();

            // Assign this room to location 1,1
            rooms[1, 1] = room;

            // setup the room
            room.Title = "Yellow Room";
            room.Description = "you have entered the Yellow room";
            room.AddExit(Direction.West);
            room.AddExit(Direction.North);

            item = new Item();
            item.Title = "Red Ball";
            item.PickupText = "You've picked up a funny looking Red Ball!";
            item.Weight = 1;
            room.Item.Add(item);

            ////////////////////////////////////////////////////////////////////////////////////////

            // Create green room
            room = new Room();

            // Assign this room to location 1,0
            rooms[0, 1] = room;

            // setup the room
            room.Title = "Green Room";
            room.Description = "you have entered the Green room, there is a Locked door to the North.";
            room.AddExit(Direction.East);

            //create a new item
            item = new Item();
            item.Title = "Yellow Ball";
            item.PickupText = "You've picked up a funny looking Yellow Ball!";
            item.Weight = 1;
            room.Item.Add(item);

            //Place the Player in th starting room
            Player.PosX = 0;
            Player.PosY = 0;
        }
    }
}
