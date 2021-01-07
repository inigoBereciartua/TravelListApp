using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models.DAO
{
    interface ICategoryRepository
    {
        void addItem<Category>(Category item);
        void removeItem<Category>(int Id);
        List<Category> getAllItems<Category>();
        void updateItem<Category>(Category item);
        void SaveChanges();
    }
}
