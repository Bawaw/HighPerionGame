using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HighPerionGame
{
    static class Player
    {
        private static int posX;
        private static int posY;

        private static List<Item> inventoryItems;
        private static int moves = 0;
        private static int weightCapacity = 6;

        #region properties
        public static int PosX
        {
            get { return posX; }
            set { posX = value; }

        }
        public static int PosY
        {
            get { return posY; }
            set { posY = value; }

        }

        public static int Moves
        {
            get { return moves; }
            set { moves = value; }

        }

        public static int WeightCapacity
        {
            get { return weightCapacity; }
            set { weightCapacity = value; }

        }
        public static int InventoryWeight
        {
            get 
            {
                int result = 0;
                foreach (Item item in inventoryItems)
                {
                    result += item.Weight;
                }
                return result;
            }
        }

        #endregion

        static Player()
        {
            inventoryItems = new List<Item>();
        }

        #region public methods

        public static void Move(string direction)
        {
            Room room = Player.GetCurrentRoom();

            if (!room.CanExit(direction))
            { 
                TextBuffer.Add("Invalid Direction");
                return;
            }
            Player.moves++;
            switch (direction)
            {
                case Direction.North:
                    posY--;
                    break;
                case Direction.South:
                    posY++;
                    break;
                case Direction.East:
                    posX++;
                    break;
                case Direction.West:
                    posX--;
                    break;
            }
            Player.GetCurrentRoom().Describe();
        }

        public static void PickUpItem(string ItemName)
        {
            Room room = Player.GetCurrentRoom();
            Item item = room.GetItem(ItemName);

            if (item != null)
            {
                if (Player.InventoryWeight + item.Weight > Player.WeightCapacity)
                {
                    TextBuffer.Add("You Can't Carry More!");
                    return;
                }
                room.Item.Remove(item);
                Player.inventoryItems.Add(item);
                TextBuffer.Add(item.PickupText);
            }
            else
                TextBuffer.Add("There is no " + ItemName + " in this room.");
        }

        public static void DropItem(string ItemName)
        {
            Room room = Player.GetCurrentRoom();
            Item item = GetInventoryItem(ItemName);

            if (item != null)
            {
                Player.inventoryItems.Remove(item);
                room.Item.Add(item);
                TextBuffer.Add("The " + ItemName + " Has been droped");
            }
            else
                TextBuffer.Add("You Don't Have an Item Named: " + ItemName);
        }

        public static void DisplayInventory()
        {
            string message = "Your inventory contains: ";
            string items = "";
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');

            if (inventoryItems.Count > 0)
            {
                foreach (Item item in inventoryItems)
                {
                    items += "\n[" + item.Title + "] Wt:" + item.Weight.ToString();
                }
            }
            else 
                items = "\n<No Items>" ; 

            items += "\n\nTotal Wt: " + Player.InventoryWeight + " / " + Player.WeightCapacity;
            TextBuffer.Add(message + "\n" + underline + items);
        }

        public static Room GetCurrentRoom()
        {
            return Level.Rooms[posX, posY];
        }

        public static Item GetInventoryItem(string ItemName)
        {
            foreach (Item item in inventoryItems)
            { 
                if (item.Title.ToLower() == ItemName.ToLower())
                {
                    return item;
                }
            }
            return null;
        }
        #endregion
    }
}
