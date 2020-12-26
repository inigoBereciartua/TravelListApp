using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelListApp_Backend.Models
{
    public class Place
    {
        #region Fields
        private String _name;
        private bool _visited;
        #endregion Fields

        #region Constructor

        public Place(string name)
        {
            Name = name;
            Visited = false;
        }
        #endregion Constructor

        #region Properties
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool Visited
        {
            get { return _visited; }
            set { _visited = value; }
        }
        #endregion Properties

    }
}
