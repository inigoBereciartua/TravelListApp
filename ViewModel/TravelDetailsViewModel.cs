using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelListApp.Model;

namespace TravelListApp.ViewModel
{
    class TravelDetailsViewModel
    {
        public TravelDetailsViewModel(){}

        internal async Task<bool> RemoveItemAsync(Travel travel,Item item)
        {
            var result = await Client.HttpClient.DeleteAsync("http://localhost:65177/api/Travel/" + travel.id.ToString() + "/Item/"+item.Id);
            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
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
            bool completed = false;
            if (item.Check == false)
            {
                completed = true;
                item.Check = true;
            }
            else if (item.Check == true)
            {
                completed = false;
                item.Check = false;
            }
            var values = new Dictionary<string, string>
                {
                    { "TravelId", travel.id.ToString() },
                    { "ItemId", item.Id.ToString()},
                    { "Completed", completed.ToString()},
                };
            var content = new System.Net.Http.FormUrlEncodedContent(values);
            var result = await Client.HttpClient.PutAsync("http://localhost:65177/api/Travel/Item", content);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
    }
}
