using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelListApp.Model
{
    class User
    {
        public string Email { get; internal set; }
        public string Username { get; internal set; }
        public string Password { get; internal set; }
    }
}
