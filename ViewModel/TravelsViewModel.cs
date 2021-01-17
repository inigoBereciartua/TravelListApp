using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using TravelListApp.Command;
using TravelListApp.Model;
using Task = TravelListApp.Model.Task;
using System.Net.Http;

namespace TravelListApp.ViewModel
{
    class TravelsViewModel
    {
        public CreateTravelCommand CreateTravelCommand { get; set; }
        public RemoveTravelCommand RemoveTravelCommand { get; set; }
        public RemoveTravelCommand NavigateToTravelDetailCommand { get; set; }
        public ObservableCollection<Travel> TravelList { get; set; }
        public string NewTravelName { get; set; }
        public DateTimeOffset NewTravelsStartDate { get; set; }
        public DateTimeOffset NewTravelsEndDate { get; set; }
        private string _errormessage;
        public string ErrorMessage
        {
            get { return _errormessage; }
            set
            {
                if (value != _errormessage)
                {
                    _errormessage = value;
                    OnPropertyChanged("ErrorMessage");
                }
            }
        }

        public TravelsViewModel()
        {
            CreateTravelCommand = new CreateTravelCommand(this);
            RemoveTravelCommand = new RemoveTravelCommand(this);
            NavigateToTravelDetailCommand = new RemoveTravelCommand(this);
            ErrorMessage = "a";
            NewTravelName = "";
            NewTravelsStartDate = DateTime.Today;
            NewTravelsEndDate = DateTime.Today.AddDays(1);
            TravelList = System.Threading.Tasks.Task.Run(()=> GetTravels()).Result;
        }

        private async Task<ObservableCollection<Travel>> GetTravels()
        {
            var result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Travel");

            List<Travel> tmp = JsonConvert.DeserializeObject<List<Travel>>(await result.Content.ReadAsStringAsync());
            foreach (var item in tmp)
            {
                result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Travel/" + item.id.ToString() + "/Categories");
                List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(await result.Content.ReadAsStringAsync());
                result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Travel/" + item.id.ToString() + "/Items");
                List<Item> items  = JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync());
                result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Travel/" + item.id.ToString() + "/Tasks");
                List<Task> tasks = JsonConvert.DeserializeObject<List<Task>>(await result.Content.ReadAsStringAsync());

                item.Categories = categories;
                item.Tasks = tasks;
                item.Items = items;
            }
            return new ObservableCollection<Travel>(tmp);
        }

        internal async void CreateTravel()
        {

            ErrorMessage = "";
            if (NewTravelName == "")
            {
                ErrorMessage  = "Travel's name can't be empty";
            }
            else if (NewTravelsStartDate.Date == null || NewTravelsEndDate.Date == null)
            {
                ErrorMessage = "Please select a start date and an end date";
            }
            else if (NameOfTravelIsInUse())
            {
                ErrorMessage = "That travel name is already in use";
            }            
            else if ( NewTravelsStartDate.Date > NewTravelsEndDate.Date)
            {
                ErrorMessage = "Start date can't be greater than end date";
            }
            else
            {
                Travel newTravel = new Travel() { Name = NewTravelName, Start = NewTravelsStartDate.Date, End = NewTravelsEndDate.Date };
                var values = new Dictionary<string, string>
                {
                    { "Name", NewTravelName},
                    { "Start", NewTravelsStartDate.Date.ToString() },
                    { "End", NewTravelsEndDate.Date.ToString() }                    
                };
                var content = new FormUrlEncodedContent(values);
                var result = await Client.HttpClient.PostAsync("http://localhost:65177/api/Travel", content);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    TravelList.Add(newTravel);
                }
            }            

        }

        private bool NameOfTravelIsInUse()
        {
            foreach(Travel travel in TravelList)
            {
                if(travel.Name == NewTravelName)
                {
                    return true;
                }
            }
            return false;
        }

        internal void RemoveTravel(Travel parameter)
        {
            throw new NotImplementedException();
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }


        public event PropertyChangedEventHandler PropertyChanged;        
    }
}
