using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models.DAO
{
   public interface IItemRepository
    {
        Item GetItem(int id);
        void AddItem(Item item);
        void RemoveItem(Item item);
        ICollection<Item> GetItemsOnUserId(int userId);
        ICollection<Item> GetAllItems();
        void UpdateItem(Item item);
        void SaveChanges();
    }
}
