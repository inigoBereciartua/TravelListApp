using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelListApp.Model;

namespace TravelListApp.Persistence
{
    class TravelListRepository : Repository<Travel>
    {
        public void addItem<TravelList>(TravelList item)
        {
            throw new NotImplementedException();
        }

        public List<TravelList> getAllItems<TravelList>()
        {
            throw new NotImplementedException();
        }

        public void removeItem<TravelList>(int Id)
        {
            throw new NotImplementedException();
        }

        public void updateItem<TravelList>(int Id, TravelList newObject)
        {
            throw new NotImplementedException();
        }
    }
}
