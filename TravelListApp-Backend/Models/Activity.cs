using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models
{
    public class Activity
    {
        private string _description;
        private bool _finished;


        public int Id { get; set; }

        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }


        public Activity()
        {
            Finished = false;
        }


        public Activity(string description, DateTime start, DateTime end)
        {
            Description = description;
            Start = start;
            End = end;
        }

        private DateTime _dateTime;

        public DateTime Start
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        public DateTime End
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        public bool Finished { get => _finished; set => _finished = value; }
    }
}
