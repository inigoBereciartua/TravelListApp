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
        private readonly UserManager<ApplicationUser> _userManager;
        #endregion Fields
        #region Constructor
        public DataInitializer(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
        {
            this._context = applicationDbContext;
            this._userManager = userManager;
        }
        #endregion Constructor

        #region Methodes
        public async System.Threading.Tasks.Task InitializeData()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {
                await CreateUsers();

                ApplicationUser user = this._context.Users.FirstOrDefault(e => e.UserName == "Binladen");

                Traveler traveler = new Traveler(user);

                Item pet = new Item("Pet",traveler);
                Item shoes = new Item("Shoes", traveler);
                Item teddybear = new Item("Teddybear", traveler);

                Category testCategory1 = new Category("testCategory1") { Items = new List<Item> { pet, shoes } };
                Category testCategory2 = new Category("testCategory2") { Items = new List<Item> { teddybear } };


                Activity activity = new Activity("Go to where osama binladen died", DateTime.Now, DateTime.Now.AddDays(1.0));
                Models.Task task1 = new Models.Task("Pack my bag");;

                Travel travel = new Travel("Summer travel to Afganistan");
                travel.addActivity(activity);
                travel.Categories.Add(testCategory1);
                travel.Categories.Add(testCategory2);

                TravelItem travelItem1 = new TravelItem(travel, pet, 2);
                TravelItem travelItem2 = new TravelItem(travel, shoes, 3);
                TravelItem travelItem3 = new TravelItem(travel, teddybear, 4);

                this._context.TravelTasks.Add(new TravelTask(travel, task1));
                this._context.TravelItems.AddRange(new TravelItem[] {travelItem1, travelItem2, travelItem3 });
               

                traveler.addCategory(testCategory1);
                traveler.addCategory(testCategory2);
                traveler.addTravel(travel);
                this._context.Travelers.Add(traveler);

                this._context.SaveChanges();

            }
        }


        private async System.Threading.Tasks.Task CreateUsers()
        {
            ApplicationUser user = new ApplicationUser() { UserName = "Binladen", Email = "osama@gmail.com" };
            await this._userManager.CreateAsync(user, "P@ssword1");
        }

        #endregion Methodes
    }
}
