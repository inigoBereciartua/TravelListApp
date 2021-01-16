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

namespace TravelListApp.ViewModel
{
    class TravelsViewModel
    {
        public CreateTravelCommand CreateTravelCommand { get; set; }
        public RemoveTravelCommand RemoveTravelCommand { get; set; }
        public RemoveTravelCommand NavigateToTravelDetailCommand { get; set; }
        public ObservableCollection<Travel> TravelList { get; set; }
        public string NewTravelName { get; set; }
        public string NewTravelsStartDate { get; set; }
        public string NewTravelsEndDate { get; set; }
        private string _errormessage;
        public string ErrorMessage
        {
            get { return _errormessage; }
            set
            {
                if (value != _errormessage)
                {
                    _errormessage = value;
                    NotifyPropertyChanged("ErrorMessage");
                }
            }
        }

        public TravelsViewModel()
        {
            CreateTravelCommand = new CreateTravelCommand(this);
            RemoveTravelCommand = new RemoveTravelCommand(this);
            NavigateToTravelDetailCommand = new RemoveTravelCommand(this);
            ErrorMessage = "";
            NewTravelName = "";
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

        internal void CreateTravel()
        {
            DateTime startDate;
            DateTime endDate;

            ErrorMessage = "";
            if (NewTravelName == "")
            {
                ErrorMessage  = "Travel's name can't be empty";
            }
            else if (NameOfTravelIsInUse())
            {
                ErrorMessage = "That travel name is already in use";
            }
            else if (!DateTime.TryParseExact(NewTravelsStartDate, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
            {
                ErrorMessage = "Start date format is not correct, it should be dd/MM/yyyy";
            }
            else if (!DateTime.TryParseExact(NewTravelsEndDate, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
            {
                ErrorMessage= "End date format is not correct, it should be a valid dd/MM/yyyy";
            }
            else if (startDate > endDate)
            {
                ErrorMessage = "Start date can't be greater than end date";
            }
            else
            {
                Travel newTravel = new Travel() { Name = NewTravelName, StartDate = startDate, EndDate = endDate };
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
