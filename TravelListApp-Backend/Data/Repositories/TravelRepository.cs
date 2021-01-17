using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelListApp_Backend.Models;
using TravelListApp_Backend.Models.DAO;

namespace TravelListApp_Backend.Data.Repositories
{
    public class TravelRepository : ITravelRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Travel> _travel;


        public TravelRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._travel = context.Travels;
        }
        public void addItem(Travel travel)
        {
            this._travel.Add(travel);
        }

        public ICollection<Travel> getAllItems()
        {
           return  this._travel.ToList();
        }

        public Travel GetTravel(int id)
        {
            return this._travel.Include(e => e.Categories).FirstOrDefault(e => e.Id == id);
        }

        public void removeItem(Travel travel)
        {
            this._travel.Remove(travel);
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void UpdateTravel(Travel travel)
        {
            this._travel.Update(travel);
        }
    }
}
