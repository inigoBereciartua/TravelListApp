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
        
        public override bool Equals(object obj)
        {
            // Checked for null  
            if (ReferenceEquals(obj, null))
                return false;
            // Checked for same reference  
            if (ReferenceEquals(this, obj))
                return true;
            var task = (Task)obj;
            return this.Id == task.Id;
        }

        public override int GetHashCode()
        {
            return Id ^ 7;
        }
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
