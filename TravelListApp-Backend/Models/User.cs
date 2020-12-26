using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models
{
    public class User
    {
        #region Fields
        private String _name;
        private String _lastName;
        private String _email;
        private HashSet<Travel> _travels;
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

        public String Lastname
        {
            get { return _lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name can't be empty");
                }
                else
                {
                    _lastName = value;
                }
            }
        }

        public String Email
        {
            get { return _email; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) && !value.Contains('@') && !value.Contains('.'))
                {
                    throw new ArgumentException("Email has to have an @ charachter and a .");
                }
                else
                {
                    _name = value;
                }
            }
        }

        public HashSet<Travel> Travels
        {
            get { return _travels; }
            private set { _travels = value; }
        }
        #endregion Properties


        #region Constructor
        public User(string name, string lastname,string email)
        {
            Name = name;
            Lastname = lastname;
            Email = email;
        }

        public void addTravel(Travel item)
        {
            Travels.Add(item);
        }

        public void removeTravel(Travel item)
        {
            Travels.Remove(item);
        }

        #endregion Constructor

    }
}