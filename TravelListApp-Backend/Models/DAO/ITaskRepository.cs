 using System;
using System.Collections.Generic;
using System.Linq;
using TravelListApp_Backend.Models;

namespace TravelListApp_Backend.Models.DAO
{
  public interface ITaskRepository
    {
        Task GetTask(int id);
        void AddTask(Task item);
        void RemoveTask(Task item);
        ICollection<Task> GetAllTask();
        void UpdateTask(Task item);
        void SaveChanges();
    }
}
