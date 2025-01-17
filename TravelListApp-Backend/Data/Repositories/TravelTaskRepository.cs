﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelListApp_Backend.Models;
using TravelListApp_Backend.Models.DAO;

namespace TravelListApp_Backend.Data.Repositories
{
    public class TravelTaskRepository : ITravelTaskRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TravelTask> _tavelTask;

        public TravelTaskRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._tavelTask = this._context.TravelTasks;
        }

        public void addTravelTask(TravelTask item)
        {
            this._tavelTask.Add(item);
        }

        public ICollection<TravelTask> getAllTravelTask()
        {
            return this._tavelTask.ToList();
        }

        public ICollection<TravelTask> getTravelTaskOnTravelId(int travelId)
        {
            return this._tavelTask.Include(e => e.Travel).Include(e => e.Task).Where(e => e.Travel.Id == travelId).ToList();
        }

        public void removeTravelTask(TravelTask item)
        {
            this._tavelTask.Remove(item);
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void updateTravelTask(TravelTask item)
        {
            this._tavelTask.Update(item);
        }
    }
}
