﻿using Microsoft.EntityFrameworkCore;
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

        public void addItem(Travel travel)
        {
            this._travel.Add(travel);
        }

        public List<Travel> getAllItems()
        {
           return  this._travel.ToList();
        }

        public void removeItem(Travel travel)
        {
            this._travel.Remove(travel);
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void updateItem(Travel travel)
        {
            this._travel.Update(travel);
        }
    }
}
