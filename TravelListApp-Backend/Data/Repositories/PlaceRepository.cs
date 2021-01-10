using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelListApp_Backend.Models;
using TravelListApp_Backend.Models.DAO;

namespace TravelListApp_Backend.Data.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Place> _places;

        public PlaceRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._places = context.Places;
        }

        public void addItem(Place item)
        {
            this._places.Add(item);
        }

        public List<Place> getAllItems()
        {
           return this._places.ToList();
        }

        public void removeItem(Place item)
        {
            this._places.Remove(item);
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void updateItem(Place item)
        {
            this._places.Remove(item);
        }
    }
}
