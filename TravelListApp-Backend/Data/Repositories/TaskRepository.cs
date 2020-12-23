using System;
using System.Collections.Generic;
using System.Linq;
using TravelListApp_Backend.Models.DAO;

namespace TravelListApp_Backend.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public void addItem<Task>(Task item)
        {
            throw new NotImplementedException();
        }

        public List<Task> getAllItems<Task>()
        {
            throw new NotImplementedException();
        }

        public void removeItem<Task>(int Id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void updateItem<Task>(Task item)
        {
            throw new NotImplementedException();
        }
    }
}
