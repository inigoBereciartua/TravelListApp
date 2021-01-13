using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models
{
    public class Task
    {
        #region Fields

        private String _description;
        private bool _checked;

        #endregion Fields

        #region Constructor
        public Task(String description)
        {
            Description = description;
            Checked = false;
        }


        public Task()
        {

        }
        #endregion Constructor

        #region Properties

        private List<Category> _categories;
        public List<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }

        public int Id { get; set; }

        public String Description { 
            get { return _description; } 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Description can't be empty");
                }
                else
                {
                    _description = value;
                }
            }
        }
        public bool Checked { get { return _checked; } set { _checked = value; } }

        #endregion Properties

    }
}
