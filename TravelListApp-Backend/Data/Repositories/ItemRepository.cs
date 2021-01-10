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

        public void addItem(Item item)
        {
            this._items.Add(item);
        }

        public List<Item> getAllItems()
        {
            return this._items.ToList();
        }

        public void removeItem(Item item)
        {
            this._items.Remove(item);
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void updateItem(Item item)
        {
            this._items.Update(item);
        }
    }
}
