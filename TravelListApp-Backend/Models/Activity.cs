﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models
{
    public class Activity
    {
        private string _description;
        private bool finished;


        public int Id { get; set; }

        public string Name
        {
            get { return this._description; }
            private set { this._description = value; }
        }


        public Activity()
        {
            finished = false;
        }


        public Activity(string description, DateTime start, DateTime end)
        {
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
    }
}