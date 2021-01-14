using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models.DAO
{
   public interface ITravelRepository{
        void addItem(Travel travel);
        void removeItem(Travel travel);
        ICollection<Travel> getAllItems();
        void UpdateTravel(Travel travel);
        void SaveChanges();
    }
}
