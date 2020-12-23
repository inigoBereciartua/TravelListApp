using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models.DAO
{
    interface IItineraryRepository
    {
        void addItem<Itineraty>(Itineraty item);
        void removeItem<Itineraty>(int Id);
        List<Itineraty> getAllItems<Itineraty>();
        void updateItem<Itineraty>(Itineraty item);
        void SaveChanges();
    }
}