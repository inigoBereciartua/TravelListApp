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
        private readonly DbSet<Category> _category;

        public CategoryRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._category = this._context.Categorys;
        }

        public void addItem(Category item)
        {
            this._category.Add(item);
        }

        public ICollection<Category> getAllItems()
        {
           return this._category.ToList();
        }

        public Category getItem(int id)
        {
            return this._category.Include(e => e.Items).FirstOrDefault(e => e.Id == id);
        }

        public void removeItem(Category item)
        {
            this._category.Remove(item);
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void updateItem(Category item)
        {
            this._category.Update(item);
        }

        
    }
}
