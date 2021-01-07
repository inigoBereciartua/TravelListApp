using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models.DAO
{
    interface IItemRepository
    {
        void addItem<Item>(Item item);
        void removeItem<Item>(int Id);
        List<Item> getAllItems<Item>();
        void updateItem<Item>(Item item);
        void SaveChanges();
    }
}
