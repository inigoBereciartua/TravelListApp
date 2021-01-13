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
        public List<Item> Items { get; set; }

        public List<Task> Tasks { get; set; }

        public Category()
        {
            this.Items = new List<Item>();
            this.Tasks = new List<Task>();
        }        
    }

    public class CategoriesManager
    {
        public static List<Category> GetCategories()
        {
            var categories = new List<Category>();
            categories.Add(new Category { Name = "Ibi1" , Items = new List<Item>()});
            categories.Add(new Category { Name = "Ibi2" , Items = new List<Item>()});
            categories.Add(new Category { Name = "Ibi3" , Items = new List<Item>()});
            categories.Add(new Category { Name = "Ibi4" , Items = new List<Item>()});
            categories.Add(new Category { Name = "Ibi5" , Items = new List<Item>()});
            categories.Add(new Category { Name = "Ibi6" , Items = new List<Item>()});
            categories.Add(new Category { Name = "Ibi7" , Items = new List<Item>()});            

            return categories;

        }
    }
}
