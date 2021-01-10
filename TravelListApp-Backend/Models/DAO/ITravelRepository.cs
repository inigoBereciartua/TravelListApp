using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models.DAO
{
    interface ITravelRepository{
        void addItem(Travel travel);
        void removeItem(Travel travel);
        List<Travel> getAllItems();
        void updateItem(Travel travel);
        void SaveChanges();
    }
}
