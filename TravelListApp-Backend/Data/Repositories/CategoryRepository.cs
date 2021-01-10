using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelListApp_Backend.Models;
using TravelListApp_Backend.Models.DAO;

namespace TravelListApp_Backend.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<User> _products;

        public void addItem<Category>(Category item)
        {
            throw new NotImplementedException();
        }

        public List<Category> getAllItems<Category>()
        {
            throw new NotImplementedException();
        }

        public void removeItem<Category>(int Id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void updateItem<Category>(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
