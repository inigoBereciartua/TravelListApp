using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models
{
    public class Travel
    {
        #region Fields
        private String _name;
        private List<Activity> _iternary;
        private List<Category> _categories;
        #endregion Fields

        #region Properties
        public String Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Description can't be empty");
                }
                else
                {
                    _name = value;
                }
            }
        }

        public int Id { get; set; }

        public List<Activity> Iternary
        {
            get { return _iternary; }
             set { _iternary = value; }
        }

        public List<Category> Categories
        {
            get { return this._categories; }
            set { this._categories = value; }
        }


        public DateTime Start
        {
            get;
            set;
        }

        public DateTime End
        {
            get;
            set;
        }

        #endregion Properties

        #region Constructor
        public Travel(string name)
        {
            Name = name;
            Iternary = new List<Activity>();
            Categories = new List<Category>();
            Start = DateTime.Now;
            End = DateTime.Today.AddDays(10);
        }

        public Travel()
        {
            Iternary = new List<Activity>();
            Categories = new List<Category>();
            Start = DateTime.Now;
            End = DateTime.Today.AddDays(10);
        }

        #endregion Constructor
    }
}