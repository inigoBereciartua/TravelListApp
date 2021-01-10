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

        public void addItem<Travel>(Travel item)
        {
            throw new NotImplementedException();
        }

        public List<Travel> getAllItems<Travel>()
        {
            throw new NotImplementedException();
        }

        public void removeItem<Travel>(int Id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void updateItem<Travel>(Travel item)
        {
            throw new NotImplementedException();
        }
    }
}
