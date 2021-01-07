using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelListApp.Model
{
    public class Item
    {
        public string name { get; set; }
    }

    public class ItemsManager
    {
        public static List<Item> GetItems()
        {
            var items = new List<Item>();
            items.Add(new Item { name = "Ibi" });
            items.Add(new Item { name = "Ibi2" });
            items.Add(new Item { name = "Ibi3" });
            items.Add(new Item { name = "Ibi4" });
            items.Add(new Item { name = "Ibi5" });
            items.Add(new Item { name = "Ibi6" });

            return items;
       
        }
    }
}
