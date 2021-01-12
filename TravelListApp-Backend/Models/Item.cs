using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models
{
    public class Item
    {

        #region Properties
        private string _name;

        public int Id { get; set; }

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        private Traveler _owner;

        public Traveler Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        private List<Category> _categories;
        public List<Category> Categories {
            get { return _categories; }
            set { _categories = value; }
        }


        #endregion Properties

        #region Constructor
        public Item(string name,Traveler owner)
        {
            this.Name = name;
            this.Owner = owner;
        }

        public Item()
        {
            Categories = new List<Category>();
        }

        #endregion Constructor

    }
}