using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelListApp.Persistence
{
    class TaskRepository : Repository<Task>
    {
        public void addItem<Task>(Task item)
        {
            throw new NotImplementedException();
        }

        public List<Task> getAllItems<Task>()
        {
            throw new NotImplementedException();
        }

        public void removeItem<Task>(int Id)
        {
            throw new NotImplementedException();
        }

        public void updateItem<Task>(int Id, Task newObject)
        {
            throw new NotImplementedException();
        }
    }
}
