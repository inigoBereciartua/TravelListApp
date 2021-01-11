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

        private User _owner;

        public User Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        private Category _categories;
        public Category Categories {
            get { return _categories; }
            set { _categories = value; }
        }


        #endregion Properties

        #region Constructor
        public Item(string name,User owner)
        {
            this.Name = name;
            this.Owner = owner;
        }

        public Item()
        {}

        #endregion Constructor

    }
}