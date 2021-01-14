using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models.DAO
{
  public interface IActivityRepository
    {
        void addItem(Activity item);
        void removeItem(Activity item);
        ICollection<Activity> getAllItems();
        void UpdateActivity(Activity item);
        void SaveChanges();
    }
}
