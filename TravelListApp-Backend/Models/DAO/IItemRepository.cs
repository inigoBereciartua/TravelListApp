using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models.DAO
{
    interface IItemRepository
    {
        void addItem(Item item);
        void removeItem(Item item);
        List<Item> getAllItems();
        void updateItem(Item item);
        void SaveChanges();
    }
}
