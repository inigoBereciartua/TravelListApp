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

        public void addItem<Place>(Place item)
        {
            throw new NotImplementedException();
        }

        public List<Place> getAllItems<Place>()
        {
            throw new NotImplementedException();
        }

        public void removeItem<Place>(int Id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void updateItem<Place>(Place item)
        {
            throw new NotImplementedException();
        }
    }
}
