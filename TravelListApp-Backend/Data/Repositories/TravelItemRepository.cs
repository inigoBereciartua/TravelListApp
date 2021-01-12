using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelListApp_Backend.Models;
using TravelListApp_Backend.Models.DAO;

namespace TravelListApp_Backend.Data.Repositories
{
    public class TravelItemRepository : ITravelItem
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TravelItem> _travelItems;

        public TravelItemRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._travelItems = this._context.TravelItems;
        }

        public void addItem(TravelItem item)
        {
            this._travelItems.Add(item);
        }

        public ICollection<TravelItem> getAllItems()
        {
            return this._travelItems.ToList();
        }

        public void removeItem(TravelItem item)
        {
            this._travelItems.Remove(item);
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void updateItem(TravelItem item)
        {
            this._travelItems.Update(item);
        }
    }
}
