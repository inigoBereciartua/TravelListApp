using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelListApp_Backend.Models;
using TravelListApp_Backend.Models.DAO;

namespace TravelListApp_Backend.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<User> _users;


        public UserRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._users = this._context.People;
        }

        public void addItem(User user)
        {
            this._users.Add(user);
        }

        public List<User> getAllItems()
        {

            return this._context.People.ToList();
        }

        public void removeItem(User user)
        {
            this._users.Remove(user);
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void updateItem(User user)
        {
            this._users.Update(user);
        }
    }
}
