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
        private HashSet<Task> _tasks;

        #endregion Fields

        #region Properties
        public int Id { get; set; }
        public HashSet<Travel> Travels
        {
            get { return _travels; }
            private set { _travels = value; }
        }


        public List<Category> Categories
        {
            get { return this._category; }
            private set { this._category = value; }
        }

        public ApplicationUser ApplicationUser
        {
            get { return this._applicationUser; }
            set { this._applicationUser = value; }
        }

        public HashSet<Task> Tasks
        {
            get { return this._tasks; }
            set { this._tasks = value; }
        }

        #endregion Properties

        #region Constructor
        public Traveler(ApplicationUser user)
        {
            ApplicationUser = user;
            Travels = new HashSet<Travel>();
            Categories = new List<Category>();
            Tasks = new HashSet<Task>();
        }

        public Traveler()
        {
            Travels = new HashSet<Travel>();
            Categories = new List<Category>();
            Tasks = new HashSet<Task>();
        }

        #endregion Constructor


    }
}
