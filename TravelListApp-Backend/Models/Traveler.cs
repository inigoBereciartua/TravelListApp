using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models
{
    public class Traveler
    {
        #region Fields
        private ApplicationUser _applicationUser;
        private HashSet<Travel> _travels;
        private List<Category> _category;

        #endregion Fields

        #region Properties
        public int Id { get; set; }
        public HashSet<Travel> Travels
        {
            get { return _travels; }
            private set { _travels = value; }
        }


        public List<Category> Category
        {
            get { return this._category; }
            private set { this._category = value; }
        }

        public ApplicationUser ApplicationUser
        {
            get { return this._applicationUser; }
            set { this._applicationUser = value; }
        }

        #endregion Properties

        #region Constructor
        public Traveler(ApplicationUser user)
        {
            ApplicationUser = user;
            Travels = new HashSet<Travel>();
            Category = new List<Category>();
        }

        public Traveler()
        {
            Travels = new HashSet<Travel>();
            Category = new List<Category>();
        }

        #endregion Constructor

        public void addTravel(Travel item)
        {
            Travels.Add(item);
        }


        public void removeTravel(Travel item)
        {
            Travels.Remove(item);
        }

        public void addCategory(Category item)
        {
            Category.Add(item);
        }

        public void removeCategory(Category item)
        {
            Category.Remove(item);
        }
    }
}
