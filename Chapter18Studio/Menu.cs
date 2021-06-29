using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter18Studio
{
    class Menu
    {
        // Name of the menu
        public string MenuName{get;set;}
        // List of menuitems
        public List<MenuItem> MenuItems { get; }
        // hashset of the item categories
        public HashSet<string> itemCategories;
        // date the menu was updated
        public DateTime DateMenuUpdated { get; set; }
        
        // Add dateTime for when menu is updated. this will be adding, removing.
        
        public Menu(string _menuName)
        {

            this.MenuName = _menuName;
            this.MenuItems = new List<MenuItem>();
            this.itemCategories = new HashSet<string>() { "appetizer", "main course", "dessert" };
            this.DateMenuUpdated = DateTime.Now;
        }

        /// <summary>
        /// print out the menu item(s)
        /// </summary>
        public void PrintMenuItems()
        {
            Console.WriteLine("----------------------------");
            // display when menu last updated
            Console.WriteLine($"{this.MenuName} - LAST UPDATED: {DateMenuUpdated}");
            // iterate over the menu items and print them out
            foreach (MenuItem item in MenuItems)
            {
                DateTime dateAMonthAgo = DateTime.Now.AddMonths(-1);
                // check if the menu item is "new", new defined if been in last month 
                if (item.DateAdded.CompareTo(dateAMonthAgo) >= 0) // if < 0 then it is earlier and not new
                {
                    // printing in new format
                    Console.WriteLine($"*NEW*: {item.Description} - ${item.Price}");
                }
                else
                {
                    // otherwise it will be 0, or 1 and hence it is new
                    Console.WriteLine($"     {item.Description} - ${item.Price}");
                }
            }
            Console.WriteLine("----------------------------");
        }

        /// <summary>
        /// Print a singular menu item
        /// </summary>
        /// <param name="description"></param>
        public void PrintMenuItem(string description)
        {
            Console.WriteLine("----------------------------");
            foreach (MenuItem item in MenuItems)
            {
                DateTime dateAMonthAgo = DateTime.Now.AddMonths(-1);
                // check if the menu item is "new", new defined if been in last month 
                if (item.DateAdded.CompareTo(dateAMonthAgo) >= 0) // if < 0 then it is earlier and not new
                {
                    if (item.Description.Equals(description))
                    {
                        // printing in new format
                        Console.WriteLine($"*NEW*: {item.Description} - ${item.Price}");
                    }
                }
                else
                {
                    if (item.Description.Equals(description))
                    {
                        // otherwise it will be 0, or 1 and hence it is new
                        Console.WriteLine($"     {item.Description} - ${item.Price}");
                    }
                }
            }
            Console.WriteLine("----------------------------");

        }

        /// <summary>
        /// add a menu item
        /// </summary>
        /// <param name="price"></param>
        /// <param name="description"></param>
        /// <param name="category"></param>
        public void AddMenuItem(double price, string description, string category)
        {
            try
            {
                // check that it is in a specific category
                if (itemCategories.Contains(category))
                {
                    // Adding a new item to the MenuItems collection
                    //check for duplicate
                    bool isDuped = DoesItemExist(description);
                    if (isDuped)
                    {
                        throw new Exception("Item already exists!");
                    }
                    else
                    {
                        MenuItem newItem = new MenuItem(price, description, category);
                        MenuItems.Add(newItem);
                    }
                    
                }
                else
                {
                    throw new Exception("Item category does not exist!");
                }
                // update the date that the menu has been... well.. updated
                this.DateMenuUpdated = DateTime.Now;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        // Remove MenuItem from the Menu
        public void RemoveMenuItem(string description)
        {
            try
            {
                int listIndex = 0;
                foreach (MenuItem item in MenuItems)
                {
                    // check if the removed item is equal to the description we want to remove
                    if (item.Description.Equals(description))
                    {
                        // remove the item
                        MenuItems.RemoveAt(listIndex);
                        // update the date that the menu has been... well.. updated
                        this.DateMenuUpdated = DateTime.Now;
                        break;
                    }
                    listIndex++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        // determine whether two menu items are equal. Could be used to check for duplicates, will be helper method for AddMenuItem)
        private bool DoesItemExist(string description)
        {
            foreach(MenuItem item in MenuItems)
            {
                if (item.Description.Equals(description))
                {
                    return true;
                }
            }
            return false;
        }



    }
}
