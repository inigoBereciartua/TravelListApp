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
        private readonly DbSet<User> _products;

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

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void updateItem<Item>(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
