using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models.DAO
{
   public interface ITravelTaskRepository
    {
        void addTravelTask(TravelTask item);
        void removeTravelTask(TravelTask item);
        ICollection<TravelTask> getAllTravelTask();
        ICollection<TravelTask> getTravelTaskOnTravelId(int travelId);
        void updateTravelTask(TravelTask item);
        void SaveChanges();
    }
}
