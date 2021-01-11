using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models.DAO
{
  public  interface ICategoryRepository
    {
        Category getItem(int id);
        void addItem(Category item);
        void removeItem(Category item);
        List<Category> getAllItems();
        void updateItem(Category item);
        void SaveChanges();
    }
}
