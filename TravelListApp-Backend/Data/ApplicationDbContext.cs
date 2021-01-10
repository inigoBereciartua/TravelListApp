using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelListApp_Backend.Data.Mappers;
using TravelListApp_Backend.Models;

namespace TravelListApp_Backend.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        #region Properties
        public DbSet<User> People { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Activity> Itinerarys { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Travel> Travels { get; set; }
        #endregion Properties

        #region Methodes
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ItemConfiguration());
            builder.ApplyConfiguration(new PlaceConfiguration());
            builder.ApplyConfiguration(new TaskConfiguration());
            builder.ApplyConfiguration(new TravelsConfiguration());
        }
        #endregion Methodes
    }
}
