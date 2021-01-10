using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Data
{
    public class DataInitializer
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        #endregion Fields
        #region Constructor
        public DataInitializer(ApplicationDbContext applicationDbContext, UserManager<IdentityUser> userManager)
        {
            this._context = applicationDbContext;
            this._userManager = userManager;
        }
        #endregion Constructor

        #region Methodes
        /*public async Task<bool> InitializeData()
        {
            _context.Database.EnsureDeleted();
        }


        private async Task CreateUsers()
        {

        }*/

        #endregion Methodes
    }
}
