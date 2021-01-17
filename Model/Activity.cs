using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelListApp.Model
{
    public class Activity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Start { get; set; }        
    }
}
