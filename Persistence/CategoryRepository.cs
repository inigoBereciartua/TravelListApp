using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelListApp.Model;

namespace TravelListApp.Persistence
{
    class CategoryRepository : Repository<Category>
    {
        public void addItem<Category>(Category item)
        {
            throw new NotImplementedException();
        }

        public List<Category> getAllItems<Category>()
        {
            throw new NotImplementedException();
        }

        public void removeItem<Category>(int Id)
        {
            throw new NotImplementedException();
        }

        public void updateItem<Category>(int Id, Category newObject)
        {
            throw new NotImplementedException();
        }
    }
}
