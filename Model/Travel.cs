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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public Itinerary Itinerary { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();

        public String GetStringStartDate()
        {
            return StartDate.ToString("dd/MM/yyyy");
        }

        public String GetStringEndDate()
        {
            return EndDate.ToString("dd/MM/yyyy");
        }

        public override bool Equals(object obj)
        {
            // Check for null  
            if (ReferenceEquals(obj, null))
                return false;
            // Check for same reference  
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
                item.AmountOfItem = 1;
                item.Check = false;
            });
                        
            List<Travel> travelList = new List<Travel>();            
            travelList.Add(new Travel() { Name = "travel1" ,StartDate = new DateTime(), EndDate = new DateTime(), Items = items, Categories = CategoriesManager.GetCategories()});
            travelList.Add(new Travel() { Name = "travel2" ,StartDate = new DateTime(), EndDate = new DateTime(), Items = items, Categories = CategoriesManager.GetCategories()});
            travelList.Add(new Travel() { Name = "travel3" ,StartDate = new DateTime(), EndDate = new DateTime(), Items = items, Categories = CategoriesManager.GetCategories()});
            travelList.Add(new Travel() { Name = "travel4" ,StartDate = new DateTime(), EndDate = new DateTime(), Items = items, Categories = CategoriesManager.GetCategories()});
            travelList.Add(new Travel() { Name = "travel5" ,StartDate = new DateTime(), EndDate = new DateTime(), Items = items, Categories = CategoriesManager.GetCategories()});
            travelList.Add(new Travel() { Name = "travel6" ,StartDate = new DateTime(), EndDate = new DateTime(), Items = items, Categories = CategoriesManager.GetCategories()});
            travelList.Add(new Travel() { Name = "travel7" ,StartDate = new DateTime(), EndDate = new DateTime(), Items = items, Categories = CategoriesManager.GetCategories()});
            travelList.Add(new Travel() { Name = "travel8" ,StartDate = new DateTime(), EndDate = new DateTime(), Items = items, Categories = CategoriesManager.GetCategories()});
            return travelList;
        }
    }
}
