using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models.DAO
{
    interface ITravelRepository{
        void addItem<Travel>(Travel item);
        void removeItem<Travel>(int Id);
        List<Travel> getAllItems<Travel>();
        void updateItem<Travel>(Travel item);
        void SaveChanges();
    }
}
