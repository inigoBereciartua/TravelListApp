using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelListApp.Model;

namespace TravelListApp.ViewModel
{
    class TravelDetailsViewModel
    {
        public Travel Travel { get; set; }
        public Item ItemToAdd { get; set; }
        public ObservableCollection<Item> ItemsNotInTravelList { get; set; }
        public ObservableCollection<Item> ItemsInTravelList { get; set; }
        public ObservableCollection<Model.Task> TasksNotInTravelList { get; set; }
        public ObservableCollection<Model.Task> TasksInTravelList { get; set; }
        public string Amount;        

        internal async void RemoveItemAsync(Item item)
        {
            var result = await Client.HttpClient.DeleteAsync("http://localhost:65177/api/Travel/" + Travel.id.ToString() + "/Item/"+item.Id);
            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ItemsInTravelList.Remove(item);
                ItemsNotInTravelList.Add(item);
            }            
        }

        internal async Task<bool> RemoveTaskAsync(Travel travel,Model.Task task)
        {

            var result = await Client.HttpClient.DeleteAsync("http://localhost:65177/api/Travel/" + travel.id.ToString() + "/Task/" + task.Id);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        internal async Task<bool> RemoveCategoryAsync(Travel travel,Category category)
        {
            var result = await Client.HttpClient.DeleteAsync("http://localhost:65177/api/Travel/" + travel.id.ToString() + "/Category/" + category.id);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        internal async Task<bool> CheckTaskAsync(Travel travel, Model.Task item)
        {
            bool completed = false;
            if(item.Checked == false)
            {
                completed = true;
                item.Checked = true;
            }
            else if(item.Checked == true)
            {
                completed = false;
                item.Checked = false;
            }
            var values = new Dictionary<string, string>
                {
                    { "TravelId", travel.id.ToString() },
                    { "TaskId", item.Id.ToString()},
                    { "Completed", completed.ToString()},
                };
            var content = new System.Net.Http.FormUrlEncodedContent(values);
            var result = await Client.HttpClient.PutAsync("http://localhost:65177/api/Travel/Task", content);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        internal async Task<bool> CheckItemAsync(Travel travel, Item item)
        {

            item.Check = !item.Check;
            var values = new Dictionary<string, string>
                {
                    { "TravelId", travel.id.ToString() },
                    { "ItemId", item.Id.ToString()},
                    { "Completed", item.Check.ToString()},
                };
            var content = new System.Net.Http.FormUrlEncodedContent(values);
            var result = await Client.HttpClient.PutAsync("http://localhost:65177/api/Travel/Item", content);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
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

        public void LoadData()
        {
            ItemsInTravelList = System.Threading.Tasks.Task.Run(() => GetTravelItems()).Result;
            ItemsNotInTravelList = System.Threading.Tasks.Task.Run(() => GetItems()).Result;
            ItemsNotInTravelList = new ObservableCollection<Item>(ItemsNotInTravelList.Where(e => !ItemsInTravelList.Contains(e)).ToList());

            TasksInTravelList = System.Threading.Tasks.Task.Run(() => GetTravelTasks()).Result;
            TasksNotInTravelList = System.Threading.Tasks.Task.Run(() => GetTasks()).Result;
            TasksNotInTravelList = new ObservableCollection<Model.Task>(TasksNotInTravelList.Where(e => !TasksInTravelList.Contains(e)).ToList());
            Console.WriteLine();
        }        
    }
}
