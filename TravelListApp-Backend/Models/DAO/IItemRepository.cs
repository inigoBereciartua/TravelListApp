using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models.DAO
{
   public interface IItemRepository
    {
        Item getItem(int id);
        void addItem(Item item);
        void removeItem(Item item);
        ICollection<Item> getAllItems();
        void updateItem(Item item);
        void SaveChanges();
    }
}
