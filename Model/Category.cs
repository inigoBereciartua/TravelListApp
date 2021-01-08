using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelListApp.Model
{
    public class Category
    {
        public string name { get; set; }
        public Dictionary<Item, int> items { get; set; }

        public Category()
        {
            this.items = new Dictionary<Item, int>();
        }        
    }

    public class CategoriesManager
    {
        public static List<Category> GetCategories()
        {
            var categories = new List<Category>();
            categories.Add(new Category { name = "Ibi1" , items = new Dictionary<Item, int>()});
            categories.Add(new Category { name = "Ibi2" , items = new Dictionary<Item, int>()});
            categories.Add(new Category { name = "Ibi3" , items = new Dictionary<Item, int>()});
            categories.Add(new Category { name = "Ibi4" , items = new Dictionary<Item, int>()});
            categories.Add(new Category { name = "Ibi5" , items = new Dictionary<Item, int>()});
            categories.Add(new Category { name = "Ibi6" , items = new Dictionary<Item, int>()});
            

            return categories;

        }
    }
}
