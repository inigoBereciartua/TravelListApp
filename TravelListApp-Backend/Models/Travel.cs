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
        private HashSet<Task> _tasks;
        private List<Activity> _iternary;
        #endregion Fields

        #region Properties
        public String Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name can't be empty");
                }
                else
                {
                    _name = value;
                }
            }
        }

        public HashSet<Task> Tasks
        {
            get { return _tasks; }
            private set{ _tasks = value; }
        }

        public List<Activity> Iternary
        {
            get { return _iternary; }
            private set { _iternary = value; }
        }
        #endregion Properties


        #region Constructor
        public Travel(string name, HashSet<Task> tasks, List<Activity>  iternary)
        {
            Name = name;
            Tasks = tasks;
            Iternary =  iternary
        }

        public void addTask(Task item)
        {
            Tasks.Add(item);
        }

        public void removeTask(Task item)
        {
            Tasks.Remove(item);
        }

        public void addActivity(Activity item)
        {
            Iternary.Add(item);
        }

        public void addRemove(Activity item)
        {
            Iternary.Add(item);
        }

        #endregion Constructor
    }
}