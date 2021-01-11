using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelListApp_Backend.Models;

namespace TravelListApp_Backend.Data
{
    public class DataInitializer
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        #endregion Fields
        #region Constructor
        public DataInitializer(ApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }
        #endregion Constructor

        #region Methodes
        public async System.Threading.Tasks.Task InitializeData()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {
                await CreateUsers();

                

                User user = new User("Osama", "Binladen", "osama@gmail.com");
                

                Item pet = new Item("Pet",user);
                Item shoes = new Item("Shoes",user);
                Item teddybear = new Item("Teddybear",user);

                Category testCategory1 = new Category("testCategory1", new List<Item> { pet, shoes });
                Category testCategory2 = new Category("testCategory2", new List<Item> { teddybear });

                //Category[] categories = new Category[] { testCategory1, testCategory2 };
                //this._context.Categorys.AddRange(categories);

                Place place1 = new Place("Afganistan");
                Place place2 = new Place("Iraq"); 

                Activity activity = new Activity("Go to where osama binladen died", DateTime.Now, DateTime.Now.AddDays(1.0));
                Models.Task task1 = new Models.Task("Pack my bag");

                Activity[] activities = new Activity[] { activity };
                //this._context.Activities.AddRange(activities);

                Travel travel = new Travel("Summer travel to Afganistan", new HashSet<Models.Task> { task1 }, new List<Activity>() { activity },new List<Place> {place1,place2 });

                user.addCategory(testCategory1);
                user.addCategory(testCategory2);
                user.addTravel(travel);

                this._context.People.Add(user);
                this._context.SaveChanges();

            }
        }


        private async System.Threading.Tasks.Task CreateUsers()
        {
            await System.Threading.Tasks.Task.CompletedTask;
        }

        #endregion Methodes
    }
}
