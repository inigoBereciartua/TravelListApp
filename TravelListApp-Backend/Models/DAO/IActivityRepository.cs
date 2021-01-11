using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models.DAO
{
    interface IActivityRepository
    {
        void addItem(Activity item);
        void removeItem(Activity item);
        List<Activity> getAllItems();
        void updateItem(Activity item);
        void SaveChanges();
    }
}
