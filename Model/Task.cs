using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelListApp.Model
{
    public class Task
    {
        public int id { get; set; }
        public string Name { get; set; }
    }

    public class TaskManager
    {
        public static List<Task> GetTasks()
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(new Task() { Name= "Ibi1"});
            tasks.Add(new Task() { Name= "Ibi2"});
            tasks.Add(new Task() { Name= "Ibi3"});
            tasks.Add(new Task() { Name= "Ibi4"});
            tasks.Add(new Task() { Name= "Ibi5"});
            return tasks;
        }
    }
}
