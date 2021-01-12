using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelListApp_Backend.Models;
using TravelListApp_Backend.Models.DAO;

namespace TravelListApp_Backend.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Task> _tasks;

        public TaskRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._tasks = context.Tasks;
        }

        public void addItem(Task item)
        {
            this._tasks.Add(item);
        }

        public ICollection<Task> getAllItems()
        {
           return this._tasks.ToList();
        }

        public void removeItem(Task item)
        {
            this._tasks.Remove(item);
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void updateItem(Task item)
        {
            this._tasks.Update(item);
        }
    }
}
