using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelListApp.Model;

namespace TravelListApp.ViewModel
{
    class TravelDetailsViewModel
    {
        public DateTimeOffset NewActivityStart;        
        public string NewActivityDescription;

        public Travel Travel { get; set; }
        public Item ItemToAdd { get; set; }
        public Model.Task TaskToAdd { get; set; }
        public ObservableCollection<Activity> ActivitiesList { get; set; }
        public ObservableCollection<Item> ItemsNotInTravelList { get; set; }
        public ObservableCollection<Item> ItemsInTravelList { get; set; }
        public ObservableCollection<Model.Task> TasksNotInTravelList { get; set; }
        public ObservableCollection<Model.Task> TasksInTravelList { get; set; }
        public string Amount;
        internal async void RemoveActivityAsync(Activity activity)
        {
            var result = await Client.HttpClient.DeleteAsync("http://localhost:65177/api/Travel/" + Travel.id.ToString() + "/Activity/" + activity.Id);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ActivitiesList.Remove(activity);
            }
        }
        internal async void RemoveItemAsync(Item item)
        {
            var result = await Client.HttpClient.DeleteAsync("http://localhost:65177/api/Travel/" + Travel.id.ToString() + "/Item/"+item.Id);
            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ItemsInTravelList.Remove(item);
                ItemsNotInTravelList.Add(item);
            }            
        }
        internal async void RemoveTaskAsync(Model.Task task)
        {

            var result = await Client.HttpClient.DeleteAsync("http://localhost:65177/api/Travel/" + Travel.id.ToString() + "/Task/" + task.Id);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TasksInTravelList.Remove(task);
                TasksNotInTravelList.Add(task);
            }
            
        }
        internal async Task<bool> RemoveCategoryAsync(Travel travel,Category category)
        {
            var result = await Client.HttpClient.DeleteAsync("http://localhost:65177/api/Travel/" + travel.id.ToString() + "/Category/" + category.Id);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
        internal async void CheckTaskAsync(Model.Task item)
        {            
            item.Checked = !item.Checked;
            var values = new Dictionary<string, string>
            {
                { "TravelId", Travel.id.ToString() },
                { "TaskId", item.Id.ToString()},
                { "Completed", item.Checked.ToString()},
            };
            var content = new System.Net.Http.FormUrlEncodedContent(values);
            var result = await Client.HttpClient.PutAsync("http://localhost:65177/api/Travel/Task", content);            
        }
        internal async void CheckItemAsync(Item item)
        {
            item.Checked = !item.Checked;
            var values = new Dictionary<string, string>
                {
                    { "TravelId", Travel.id.ToString() },
                    { "ItemId", item.Id.ToString()},
                    { "Completed", item.Checked.ToString()},
                };
            var content = new System.Net.Http.FormUrlEncodedContent(values);
            var result = await Client.HttpClient.PutAsync("http://localhost:65177/api/Travel/Item", content);            
        }    
        private async Task<ObservableCollection<Activity>> GetActivities()
        {
            var result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Travel/" + Travel.id + "/Activity");
            var callRes = JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync());
            return new ObservableCollection<Activity>(JsonConvert.DeserializeObject<List<Activity>>(await result.Content.ReadAsStringAsync()));
        }
        private async Task<ObservableCollection<Item>> GetTravelItems()
        {
            var result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Travel/" + Travel.id + "/Items");
            var callRes = JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync());
            return new ObservableCollection<Item>(JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync()));
        }
        private async Task<ObservableCollection<Item>> GetItems()
        {
            var result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Item");
            var callRes = JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync());
            return new ObservableCollection<Item>(JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync()));
        }
        private async Task<ObservableCollection<Model.Task>> GetTravelTasks()
        {
            var result = await Client.HttpClient.GetAsync("http://localhost:65177/api/travel/" + Travel.id + "/Tasks");
            var callRes = JsonConvert.DeserializeObject<List<Model.Task>>(await result.Content.ReadAsStringAsync());
            return new ObservableCollection<Model.Task>(JsonConvert.DeserializeObject<List<Model.Task>>(await result.Content.ReadAsStringAsync()));
        }
        private async Task<ObservableCollection<Model.Task>> GetTasks()
        {
            var result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Task");
            var callRes = JsonConvert.DeserializeObject<List<Model.Task>>(await result.Content.ReadAsStringAsync());
            return new ObservableCollection<Model.Task>(JsonConvert.DeserializeObject<List<Model.Task>>(await result.Content.ReadAsStringAsync()));
        }
        
        internal async System.Threading.Tasks.Task<string> AddItemAsync()
        {
            if (ItemToAdd == null)
            {
                return "Please selected an item to add";
            }
            else if (Amount =="")
            {
                return "Please fill in item's amount";
            }
            try
            {
                ItemToAdd.Count = int.Parse(Amount);
                ItemToAdd.Checked = false;
                if(ItemToAdd.Count < 1)
                {
                    return "The amount of the item must be a number higher than 0";
                }
                var values = new Dictionary<string, string>
                {
                    { "TravelId", Travel.id.ToString() },
                    { "ItemId", ItemToAdd.Id.ToString() },
                    { "Count", Amount }
                };
                var content = new FormUrlEncodedContent(values);
                var result = await Client.HttpClient.PostAsync("http://localhost:65177/api/Travel/Item", content);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    ItemsInTravelList.Add(ItemToAdd);
                    ItemsNotInTravelList.Remove(ItemToAdd);
                    return "";
                }
                return "An error occurred while adding item to travel";
            }
            catch( Exception e)
            {
                return "The amount of the item must be a number higher than 0";  
            }
        }
        internal async System.Threading.Tasks.Task<string> AddTaskAsync()
        { 
            if(TaskToAdd != null)
            {
                var values = new Dictionary<string, string>
                {
                    { "TravelId", Travel.id.ToString() },
                    { "TaskId", TaskToAdd.Id.ToString() },                    
                };
                var content = new FormUrlEncodedContent(values);
                var result = await Client.HttpClient.PostAsync("http://localhost:65177/api/Travel/Task", content);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    TaskToAdd.Checked = false;
                    TasksInTravelList.Add(TaskToAdd);
                    TasksNotInTravelList.Remove(TaskToAdd);
                    return "";
                }
            }            
            return "An error has occurred while adding the task to the travel";           
        }        
        internal async System.Threading.Tasks.Task<string> AddActivity()
        {
            if (NewActivityDescription == "")
            {
                return "Activity's description can't be empty";
            }else if (NewActivityStart == null)
            {
                return "Activity's daycan't be empty";
            }else if (NewActivityStart < Travel.Start || NewActivityStart > Travel.End)
            {
                return "The activity day has to be one day between the end date and the start date of the travel";
            }
            else
            {
                var values = new Dictionary<string, string>
                    {
                        { "TravelId", Travel.id.ToString() },
                        { "Description", NewActivityDescription },
                        { "Start", NewActivityStart.TimeOfDay.ToString() }                    
                    };
                var content = new FormUrlEncodedContent(values);
                var result = await Client.HttpClient.PostAsync("http://localhost:65177/api/Travel/Activity", content);
                if(result.StatusCode == HttpStatusCode.OK)
                {
                    Activity newActivity = new Activity() { Description = NewActivityDescription, Start = NewActivityStart.Date };
                    ActivitiesList.Add(newActivity);
                    return "";
                }
                return "An error occurred when adding the activity to the itinerary";
            }

        }
        public void LoadData()
        {
            ActivitiesList = System.Threading.Tasks.Task.Run(() => GetActivities()).Result;

            ItemsInTravelList = System.Threading.Tasks.Task.Run(() => GetTravelItems()).Result;
            ItemsNotInTravelList = System.Threading.Tasks.Task.Run(() => GetItems()).Result;
            ItemsNotInTravelList = new ObservableCollection<Item>(ItemsNotInTravelList.Where(e => !ItemsInTravelList.Contains(e)).ToList());

            TasksInTravelList = System.Threading.Tasks.Task.Run(() => GetTravelTasks()).Result;
            TasksNotInTravelList = System.Threading.Tasks.Task.Run(() => GetTasks()).Result;
            TasksNotInTravelList = new ObservableCollection<Model.Task>(TasksNotInTravelList.Where(e => !TasksInTravelList.Contains(e)).ToList());            
        }        
    }
}
