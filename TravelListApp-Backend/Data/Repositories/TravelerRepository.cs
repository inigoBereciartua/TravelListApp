using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelListApp_Backend.Models;
using TravelListApp_Backend.Models.DAO;

namespace TravelListApp_Backend.Data.Repositories
{
    public class TravelerRepository : ITravelerRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Traveler> _traveler;


        public TravelerRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._traveler = this._context.Travelers;
        }

        public void addItem(Traveler user)
        {
            this._traveler.Add(user);
        }

        public ICollection<Traveler> getAllItems()
        {

            return this._context.Travelers.ToList();
        }

        public Traveler getTraveler(ApplicationUser applicationUser)
        {
            return this._context.Travelers
                .Include(e => e.Categories)
                .ThenInclude(e => e.Items)
                .Include(e => e.Tasks)
                .ThenInclude(e => e.Categories)
                .Include(e => e.Travels)
                .ThenInclude(e => e.Iternary)
                .FirstOrDefault(e => e.ApplicationUser == applicationUser);
        }

        public void removeItem(Traveler user)
        {
            this._traveler.Remove(user);
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void updateItem(Traveler user)
        {
            this._traveler.Update(user);
        }
    }
}
