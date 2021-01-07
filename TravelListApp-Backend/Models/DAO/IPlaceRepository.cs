using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelListApp_Backend.Models.DAO
{
    interface IPlaceRepository
    {
        void addItem<Place>(Place item);
        void removeItem<Place>(int Id);
        List<Place> getAllItems<Place>();
        void updateItem<Place>(Place item);
        void SaveChanges();
    }
}
