﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelListApp_Backend.Models;
using TravelListApp_Backend.Models.DAO;

namespace TravelListApp_Backend.Data.Repositories
{
    public class ItineraryRepository : IItineraryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<User> _products;


        public void addItem<Itineraty>(Itineraty item)
        {
            throw new NotImplementedException();
        }

        public List<Itineraty> getAllItems<Itineraty>()
        {
            throw new NotImplementedException();
        }

        public void removeItem<Itineraty>(int Id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void updateItem<Itineraty>(Itineraty item)
        {
            throw new NotImplementedException();
        }
    }
}
