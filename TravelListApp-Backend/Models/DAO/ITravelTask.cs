using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models.DAO
{
    interface ITravelTask
    {
        void addItem(TravelTask item);
        void removeItem(TravelTask item);
        ICollection<TravelTask> getAllItems();
        void updateItem(TravelTask item);
        void SaveChanges();
    }
}
