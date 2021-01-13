using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelListApp.Model
{
    public class Item
    {
        public string Name { get; set; }
        public int AmountOfItem { get; set; }
        public bool Check { get; set; }
    }

    public class ItemsManager
    {
        public static List<Item> GetItems()
        {
            var items = new List<Item>();
            items.Add(new Item { Name = "Ibi" });
            items.Add(new Item { Name = "Ibi2" });
            items.Add(new Item { Name = "Ibi3" });
            items.Add(new Item { Name = "Ibi4" });
            items.Add(new Item { Name = "Ibi5" });
            items.Add(new Item { Name = "Ibi6" });

            return items;
       
        }
    }
}
