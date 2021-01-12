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
        public int Id { get; set; }

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

        private List<Task> _task;
        public List<Task> Task
        {
            get { return _task; }
            set { _task = value; }
        }

        private List<Travel> _travel;
        public List<Travel> Travel
        {
            get { return this._travel; }
            set { this._travel = value; }
        }


        #endregion Properties

        #region Construct
        public Category()
        {
            Items = new List<Item>();
            Task = new List<Task>();
            Travel = new List<Travel>();
        }

        public Category(string name)
        {
            Name = name;
            Items = new List<Item>();
            Task = new List<Task>();
            Travel = new List<Travel>();
        }

         public void removeItem(Item item)
        {
            Items.Remove(item);
        }

        public void addItem(Item item)
        {
            Items.Add(item);
        }

        public void removeTask(Task item)
        {
            Task.Remove(item);
        }

        public void addTask(Task item)
        {
            Task.Add(item);
        }

        public void removeTravel(Travel item)
        {
            Travel.Remove(item);
        }

        public void addTavel(Travel item)
        {
            Travel.Add(item);
        }

        #endregion Construct
    }
}