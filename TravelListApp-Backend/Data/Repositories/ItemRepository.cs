using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelListApp_Backend.Models;
using TravelListApp_Backend.Models.DAO;

namespace TravelListApp_Backend.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Item> _items;

        public ItemRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._items = context.Items;
        }

        public void AddItem(Item item)
        {
            this._items.Add(item);
        }

        public ICollection<Item> GetAllItems()
        {
            return this._items.ToList();
        }

        public Item GetItem(int id)
        {
           return this._items.FirstOrDefault(e => e.Id == id);
        }

        public ICollection<Item> getItemsOnTravelerId(int travelerId)
        {
            return this._items.Where(e => e.Owner.Id == travelerId).ToList();
        }

        public ICollection<Item> GetItemsOnUserId(int userId)
        {
            return this._items.Where(e => e.Owner.Id == userId).ToList();
        }

        public void RemoveItem(Item item)
        {
            this._items.Remove(item);
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void UpdateItem(Item item)
        {
            this._items.Update(item);
        }
    }
}
