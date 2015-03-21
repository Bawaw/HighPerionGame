using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HighPerionGame
{
    class Room
    {
        private string title;
        private string description;
       
        private List<string> exits;
        private List<Item> item;

        #region propeties

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        public List<Item> Item
        {
            get {return item;}
            set {item = value;}
        }
        #endregion

        public Room()
        {
            exits = new List<string>();
            item = new List<Item>();
        }

        #region publicmethods
        //Public Methods

        public void Describe()
        {
            TextBuffer.Add(this.description);
            TextBuffer.Add(this.getItemList());
            TextBuffer.Add(this.getExitList());
        }

        public void ShowTitle()
        {
            TextBuffer.Add(this.Title);
        }

        public Item GetItem(string itemName)
        {
            foreach (Item item in this.item)
            {
                if (item.Title.ToLower() == itemName.ToLower())
                return item;
            }
            return null;
        }

        public void AddExit(string direction)
        {
            if (this.exits.IndexOf(direction) == -1)
                this.exits.Add(direction);
        }

        public void RemoveExit(string direction)
        {
            if (this.exits.IndexOf(direction) != -1)
                this.exits.Remove(direction);
        }

        public bool CanExit(string direction)
        {
            foreach (string validExit in this.exits)
            {
                if (direction == validExit)
                    return true;
            }
            return false;
        }
        #endregion

        #region private methods

        //Private Methods

        private string getItemList()
        {
            string itemString = "";
            string message = "items in room:";
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');

            if (this.item.Count > 0)
            {
                foreach (Item item in this.item)
                {
                    itemString += "\n[" + item.Title + "]";
                }
            }
            else
            {
                itemString = "\n<none>";
            }

            return "\n"+ message + "\n" + underline + itemString;
        }

        private string getExitList()
        {
            string exitString = "";
            string message = "Possible Directions:";
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');

            if (this.exits.Count > 0)
            {
                foreach (string exitDirection in this.exits)
                {
                    exitString += "\n[" + exitDirection+ "]";
                }
            }
            else
            {
                exitString = "\n <none>";
            }

            return "\n" + message + "\n" + underline + exitString + "\n";
        }

        private string getCoordinates()
        {
            for (int y = 0; y < Level.Rooms.GetLength(1); y++)
            {
                for (int x = 0; x < Level.Rooms.GetLength(0); x++)
                {
                    if (this == Level.Rooms[x, y])
                        return "[" + x.ToString() + "," + y.ToString() + "]";
                }
            }
            return "This room is not within the room grid";
        }
        #endregion

    }
}
