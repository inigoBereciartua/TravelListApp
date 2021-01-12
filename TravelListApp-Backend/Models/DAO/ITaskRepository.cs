 using System;
using System.Collections.Generic;
using System.Linq;
using TravelListApp_Backend.Models;

namespace TravelListApp_Backend.Models.DAO
{
  public interface ITaskRepository
    {
        void addItem(Task item);
        void removeItem(Task item);
        ICollection<Task> getAllItems();
        void updateItem(Task item);
        void SaveChanges();
    }
}
