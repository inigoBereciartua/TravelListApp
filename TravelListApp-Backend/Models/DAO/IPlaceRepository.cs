using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelListApp_Backend.Models.DAO
{
  public  interface IPlaceRepository
    {
        void addItem(Place item);
        void removeItem(Place item);
        List<Place> getAllItems();
        void updateItem(Place item);
        void SaveChanges();
    }
}
