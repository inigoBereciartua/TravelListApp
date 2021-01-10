using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models
{
    public class Category
    {
        #region Properties
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private List<Item> _items;

        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public object CategoryID { get; internal set; }

        #endregion Properties

        #region Construct
        public Category()
        {
            Items = new List<Item>();
        }

        Category(string name, List<Item> items)
        {
            Name = name;
            Items = items;
        }

         public void removeItem(Item item)
        {
            Items.Remove(item);
        }

        public void addItem(Item item)
        {
            Items.Add(item);
        }


        #endregion Construct
    }
}