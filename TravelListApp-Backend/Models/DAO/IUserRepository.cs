using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelListApp_Backend.Models.DAO
{
    public interface IUserRepository
    {
        void addItem(User user);
        void removeItem(User user);
        List<User> getAllItems();
        void updateItem( User user);

        void SaveChanges();
    }
}
