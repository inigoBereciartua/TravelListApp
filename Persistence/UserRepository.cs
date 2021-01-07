using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelListApp.Model;

namespace TravelListApp.Persistence
{
    class UserRepository:Repository<User>
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

        public void updateItem<User>(int Id, User newObject)
        {
            throw new NotImplementedException();
        }
    }
}
