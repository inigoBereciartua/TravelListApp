using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelListApp.Model;

namespace TravelListApp.Persistence
{
    class ItemRepository : Repository<Item>
    {
        public void addItem<Item>(Item item)
        {
            throw new NotImplementedException();
        }

        public List<Item> getAllItems<Item>()
        {
            throw new NotImplementedException();
        }

        public void removeItem<Item>(int Id)
        {
            throw new NotImplementedException();
        }

        public void updateItem<Item>(int Id, Item newObject)
        {
            throw new NotImplementedException();
        }
    }
}
