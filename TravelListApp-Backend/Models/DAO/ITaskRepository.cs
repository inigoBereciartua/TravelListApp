 using System;
using System.Collections.Generic;
using System.Linq;
using TravelListApp_Backend.Models;

namespace TravelListApp_Backend.Models.DAO
{
    interface ITaskRepository
    {
        void addItem<Task>(Task item);
        void removeItem<Task>(int Id);
        List<Task> getAllItems<Task>();
        void updateItem<Task>(Task item);
        void SaveChanges();
    }
}
