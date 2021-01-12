using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelListApp_Backend.Data.Mappers;
using TravelListApp_Backend.Models;

namespace TravelListApp_Backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Properties
        public DbSet<Traveler> Travelers { get; set; }
        public DbSet<TravelItem> TravelItems { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Activity> Itinerarys { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<TravelTask> TravelTasks { get; set; }
        #endregion Properties

        #region Methodes
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new TravelItemConfiguration());
            builder.ApplyConfiguration(new TravelerConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ItemConfiguration());
            builder.ApplyConfiguration(new TaskConfiguration());
            builder.ApplyConfiguration(new TravelsConfiguration());
            builder.ApplyConfiguration(new ActivityConfiguration());
        }
        #endregion Methodes

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){
            
        }
    }
}
