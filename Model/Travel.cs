using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelListApp.Model
{
    public class Travel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public Activity Itinerary { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();

        public String GetStringStartDate()
        {
            return Start.ToString("dd/MM/yyyy");
        }

        public String GetStringEndDate()
        {
            return End.ToString("dd/MM/yyyy");
        }

        public override bool Equals(object obj)
        {
            // Checked for null  
            if (ReferenceEquals(obj, null))
                return false;
            // Checked for same reference  
            if (ReferenceEquals(this, obj))
                return true;
            var travel = (Travel)obj;
            return this.id == travel.id;
        }

        public override int GetHashCode()
        {
            return id ^ 7;
        }
    }

    public class TravelsManager
    {
        public static List<Travel> GetTravels()
        {
            List<Item> items = new List<Item>();

            items.ForEach(delegate(Item item){
                item.Count = 1;
                item.Checked = false;
            });
                        
            List<Travel> travelList = new List<Travel>();            
            travelList.Add(new Travel() { Name = "travel1" ,Start = new DateTime(), End = new DateTime(), Items = items, Categories = CategoriesManager.GetCategories()});
            travelList.Add(new Travel() { Name = "travel2" ,Start = new DateTime(), End = new DateTime(), Items = items, Categories = CategoriesManager.GetCategories()});
            travelList.Add(new Travel() { Name = "travel3" ,Start = new DateTime(), End = new DateTime(), Items = items, Categories = CategoriesManager.GetCategories()});
            travelList.Add(new Travel() { Name = "travel4" ,Start = new DateTime(), End = new DateTime(), Items = items, Categories = CategoriesManager.GetCategories()});
            travelList.Add(new Travel() { Name = "travel5" ,Start = new DateTime(), End = new DateTime(), Items = items, Categories = CategoriesManager.GetCategories()});
            travelList.Add(new Travel() { Name = "travel6" ,Start = new DateTime(), End = new DateTime(), Items = items, Categories = CategoriesManager.GetCategories()});
            travelList.Add(new Travel() { Name = "travel7" ,Start = new DateTime(), End = new DateTime(), Items = items, Categories = CategoriesManager.GetCategories()});
            travelList.Add(new Travel() { Name = "travel8" ,Start = new DateTime(), End = new DateTime(), Items = items, Categories = CategoriesManager.GetCategories()});
            return travelList;
        }
    }
}
