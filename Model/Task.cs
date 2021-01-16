using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelListApp.Model
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }
    }

    public class TaskManager
    {
        public static List<Task> GetTasks()
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(new Task() { Description= "Ibi1"});
            tasks.Add(new Task() { Description= "Ibi2"});
            tasks.Add(new Task() { Description= "Ibi3"});
            tasks.Add(new Task() { Description= "Ibi4"});
            tasks.Add(new Task() { Description= "Ibi5"});
            return tasks;
        }
    }
}
