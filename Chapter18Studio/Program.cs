using System;

namespace Chapter18Studio
{
    class Program
    {
        static void Main(string[] args)
        {


            // Create several items and add them to a menu
            Menu menu = new Menu("Bobs Restraunt Menu");
            menu.AddMenuItem(10.99, "Huge Meat Burger", "main course");
            menu.AddMenuItem(16.99, "Slappin' Honey Wine", "dessert");
            menu.AddMenuItem(8.99, "Bestest Calamari", "appetizer");

            // Print entire, updated menu to the screen
            menu.PrintMenuItems();

            // Print an individual menu item to the screen
            menu.PrintMenuItem("Slappin' Honey Wine");

            // Delete an item from a menu, then reprint
            menu.RemoveMenuItem("Bestest Calamari");
            menu.PrintMenuItems();




        }
    }
}
