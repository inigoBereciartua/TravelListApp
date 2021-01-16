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
using TravelListApp.Command;
using TravelListApp.Model;

namespace TravelListApp.ViewModel
{
    class TasksViewModel
    {
        public CreateTaskCommand CreateTaskCommand { get; set; }
        public RemoveTaskCommand RemoveTaskCommand { get; set; }
        public ObservableCollection<Model.Task> TasksList { get; set; }
        public string NewTaskName { get; set; }
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

        internal async System.Threading.Tasks.Task CreateTaskAsync()
        {
            if (NewTaskName == "")
            {
                ErrorMessage = "Please enter the new task's name";
            }
            else if (TaskNameIsInUse())
            {
                ErrorMessage = "That task name is already in use";
            }
            else
            {
                var values = new Dictionary<string, string>
                {
                    { "description", NewTaskName}
                };
                var content = new FormUrlEncodedContent(values);
                var result = await Client.HttpClient.PostAsync("http://localhost:65177/api/Task/" + NewTaskName, content);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    Model.Task newTask = new Model.Task() { Description = NewTaskName};
                    TasksList.Add(newTask);
                    TasksList = System.Threading.Tasks.Task.Run(() => GetTasks()).Result;
                }
            }
        }

        public TasksViewModel()
        {
            RemoveTaskCommand = new RemoveTaskCommand(this);
            CreateTaskCommand = new CreateTaskCommand(this);
            ErrorMessage = "";
            NewTaskName = "";
            TasksList = System.Threading.Tasks.Task.Run(() => this.GetTasks()).Result;
        }

        private async Task<ObservableCollection<Model.Task>> GetTasks()
        {            
            var result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Task");
            var callRes = JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync());
            return new ObservableCollection<Model.Task>(JsonConvert.DeserializeObject<List<Model.Task>>(await result.Content.ReadAsStringAsync()));
        }

        private bool TaskNameIsInUse()
        {
            foreach(Model.Task task in TasksList)
            {
                if(task.Description == NewTaskName)
                {
                    return true;
                }
            }
            return false;
        }

        internal void RemoveTask(Model.Task task)
        {
            TasksList.Remove(task);
            //TODO Backend implementation
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
