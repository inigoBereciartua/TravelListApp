using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelListApp.Persistence
{
    interface Repository<T>
    {
        void addItem<T>(T item);
        void removeItem<T>(int Id);
        List<T> getAllItems<T>();
        void updateItem<T>(int Id, T newObject);
    }
}
