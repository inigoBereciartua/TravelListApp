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


        #endregion Properties

        #region Constructor
        public Item(string name)
        {
            this.Name = name;
        }
        #endregion Constructor

    }
}