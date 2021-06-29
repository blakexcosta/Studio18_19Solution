using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter18Studio
{
    class MenuItem
    {
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime DateAdded { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MenuItem()
        {
            this.Price = 0;
            this.Description = "";
            this.Category = "";
            this.DateAdded = DateTime.Now;
        }

        /// <summary>
        /// Constructor we want to use
        /// </summary>
        /// <param name="itemPrice"></param>
        /// <param name="startingDescription"></param>
        /// <param name="itemCategory"></param>
        public MenuItem(double itemPrice, string startingDescription, string itemCategory)
        {
            this.Price = itemPrice;
            this.Description = startingDescription;
            this.Category = itemCategory;
            this.DateAdded = DateTime.Now;
        }
    }
}

