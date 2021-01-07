using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelListApp.Model;

namespace TravelListApp.Persistence
{
    class ItineraryRepository : Repository<Itinerary>
    {
        public void addItem<Itinerary>(Itinerary item)
        {
            throw new NotImplementedException();
        }

        public List<Itinerary> getAllItems<Itinerary>()
        {
            throw new NotImplementedException();
        }

        public void removeItem<Itinerary>(int Id)
        {
            throw new NotImplementedException();
        }

        public void updateItem<Itinerary>(int Id, Itinerary newObject)
        {
            throw new NotImplementedException();
        }
    }
}
