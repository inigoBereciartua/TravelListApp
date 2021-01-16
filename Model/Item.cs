using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelListApp.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AmountOfItem { get; set; }
        public bool Check { get; set; }

        public override bool Equals(object obj)
        {
            // Check for null  
            if (ReferenceEquals(obj, null))
                return false;
            // Check for same reference  
            if (ReferenceEquals(this, obj))
                return true;
            var item = (Item)obj;
            return this.Id == item.Id;
        }

        public override int GetHashCode()
        {
            return Id ^ 7;
        }
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
