using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelListApp_Backend.Models.DAO
{
    interface IUserRepository
    {
        void addItem<User>(User item);
        void removeItem<User>(int Id);
        List<User> getAllItems<User>();
        void updateItem<User>( User item);

        void SaveChanges();
    }
}
