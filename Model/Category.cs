using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelListApp.Model
{
    public class Category
    {
        public string Name { get; set; }
        public Dictionary<Item, int> Items { get; set; }

        public Category()
        {
            this.Items = new Dictionary<Item, int>();
        }        
    }

    public class CategoriesManager
    {
        public static List<Category> GetCategories()
        {
            var categories = new List<Category>();
            categories.Add(new Category { Name = "Ibi1" , Items = new Dictionary<Item, int>()});
            categories.Add(new Category { Name = "Ibi2" , Items = new Dictionary<Item, int>()});
            categories.Add(new Category { Name = "Ibi3" , Items = new Dictionary<Item, int>()});
            categories.Add(new Category { Name = "Ibi4" , Items = new Dictionary<Item, int>()});
            categories.Add(new Category { Name = "Ibi5" , Items = new Dictionary<Item, int>()});
            categories.Add(new Category { Name = "Ibi6" , Items = new Dictionary<Item, int>()});
            

            return categories;

        }
    }
}
