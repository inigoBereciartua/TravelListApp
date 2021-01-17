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

                ApplicationUser user = this._context.Users.FirstOrDefault(e => e.UserName == "Clark_Kent");

                Traveler traveler = new Traveler(user);
                //Clothes
                Item pet = new Item("Pet",traveler);
                Item Tshirt = new Item("Nike", traveler);
                Item Chanel_jeans = new Item("Chanel jeans", traveler);
                Item Piergiorgio_Armani = new Item("Piergiorgio Armani", traveler);
                Item IAndI = new Item("Inigo && Inigo Jacket ", traveler);
                //Toys
                Item teddybear = new Item("Teddybear", traveler);
                Item cardgame = new Item("Cardgame", traveler);
                Item football = new Item("Football", traveler);
                Item bumerang = new Item("Bumerang", traveler);
                Item dinamite = new Item("Dinamite", traveler);

                //Shoes
                Item nike = new Item("Nike", traveler);
                Item addis = new Item("Addis", traveler);
                Item jordans = new Item("Jordans", traveler);
                Item blacklifemater  = new Item("Blacklifemater", traveler);

                //Wap toy
                Item Wap = new Item("Wap-CardiB-CD", traveler);

                Category toys = new Category("Toys") { Items = new List<Item> { teddybear, cardgame, football, bumerang, dinamite } };
                Category shoes = new Category("Shoes") { Items = new List<Item> { nike, addis, jordans, blacklifemater } };
                Category clothes = new Category("Clothes") { Items = new List<Item> { pet, Tshirt, Chanel_jeans, Piergiorgio_Armani, IAndI } };
                Category randomitems = new Category("Randome stuff") { Items = new List<Item> { Wap } };


                Activity activity = new Activity("Go to Airport", DateTime.Today.AddDays(1));
                Models.Task task1 = new Models.Task("Pack my bag");
                traveler.Tasks.Add(task1);

                Travel travel = new Travel("Summer travel to Giorgio") { Start = DateTime.Today , End= DateTime.Today.AddDays(90)};
                travel.Iternary.Add(activity);
                travel.Categories.Add(toys);
                travel.Categories.Add(shoes);
                travel.Categories.Add(clothes);
                travel.Categories.Add(randomitems);

                TravelItem travelItem1 = new TravelItem(travel, football, 2);
                TravelItem travelItem2 = new TravelItem(travel, bumerang, 3);
                TravelItem travelItem3 = new TravelItem(travel, dinamite, 4);

                this._context.TravelTasks.Add(new TravelTask(travel, task1));
                this._context.TravelItems.AddRange(new TravelItem[] {travelItem1, travelItem2, travelItem3 });
               

                traveler.Categories.Add(toys);
                traveler.Categories.Add(shoes);
                traveler.Categories.Add(clothes);
                traveler.Categories.Add(randomitems);
                traveler.Travels.Add(travel);
                this._context.Travelers.Add(traveler);

                this._context.SaveChanges();

            }
        }


        private async System.Threading.Tasks.Task CreateUsers()
        {
            ApplicationUser user = new ApplicationUser() { UserName = "Clark_Kent", Email = "Clark_Kent@gmail.com" };
            await this._userManager.CreateAsync(user, "P@ssword1");
        }

        #endregion Methodes
    }
}
