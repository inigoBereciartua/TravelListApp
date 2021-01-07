using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelListApp_Backend.Models.DAO;

namespace TravelListApp_Backend.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void addItem<User>(User item)
        {
            throw new NotImplementedException();
        }

        public List<User> getAllItems<User>()
        {
            throw new NotImplementedException();
        }

        public void removeItem<User>(int Id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void updateItem<User>(User item)
        {
            throw new NotImplementedException();
        }
    }
}
