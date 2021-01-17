using System;

namespace TravelListApp_Backend.Models
{
    public class Activity
    {
        private string _description;        


        public int Id { get; set; }

        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }


        public Activity()
        {            
        }


        public Activity(string description, DateTime start)
        {
            Description = description;
            Start = start;            
        }

        private DateTime _dateTime;

        public DateTime Start
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }                
    }
}
