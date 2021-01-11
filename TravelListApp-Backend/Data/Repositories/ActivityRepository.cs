using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelListApp_Backend.Models;
using TravelListApp_Backend.Models.DAO;

namespace TravelListApp_Backend.Data.Repositories
{
    public class ActivityRepository : IActivityRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Activity> _activity;

        public ActivityRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._activity = this._context.Activities;
        }

        public void addItem(Activity item)
        {
            this._activity.Add(item);
        }

        public List<Activity> getAllItems()
        {
            return this._activity.ToList();
        }

        public void removeItem(Activity item)
        {
            this._activity.Remove(item);
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void updateItem(Activity item)
        {
            this._activity.Update(item);
        }
    }
}
