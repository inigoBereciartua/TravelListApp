using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models
{
    public class TravelTask
    {
        private Task _task;
        private Travel travel;
        private bool _checked;

        public int Id { get; set; }

        public Task Task { get => _task; set => _task = value; }
        public Travel Travel { get => travel; set => travel = value; }

        public bool Checked { get => _checked; set => _checked = value; }

        public TravelTask(Travel travel, Task task)
        {
            this.Travel = travel;
            this.Task = task;
        }

        public TravelTask()
        {

        }

        public void Check()
        {
            Checked = true;
        }

        public void UnCheck()
        {
            Checked = false;
        }


    }
}
