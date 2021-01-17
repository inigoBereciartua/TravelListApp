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
    class CategoriesViewModel
    {
        public string NewCategoryName;        

        public CreateCategoryCommand CreateCategoryCommand { get; set; }
        public RemoveCategoryCommand RemoveCategoryCommand { get; set; }
        //public NavigateToCategoryCommand NavigateToCategoryCommand { get; set; }
        public ObservableCollection<Category> CategoriesList { get; set; }
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
        
        public CategoriesViewModel()
        {
            CreateCategoryCommand = new CreateCategoryCommand(this);
            RemoveCategoryCommand = new RemoveCategoryCommand(this);
            CategoriesList = System.Threading.Tasks.Task.Run(() => GetCategories()).Result;
            ErrorMessage = "";
        }
        private async Task<ObservableCollection<Category>> GetCategories()
        {
            var result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Category");
            var callRes = JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync());
            return new ObservableCollection<Category>(JsonConvert.DeserializeObject<List<Category>>(await result.Content.ReadAsStringAsync()));
        }

        internal async System.Threading.Tasks.Task CreateCategoryAsync()
        {
            if (NewCategoryName == "")
            {
                ErrorMessage = "Please enter the new category's name";
            }
            else if (CategoryNameIsInUse())
            {
                ErrorMessage = "That category name is already in use";
            }
            else
            {
                var values = new Dictionary<string, string>
                {
                    { "categoryName", NewCategoryName}
                };
                var content = new FormUrlEncodedContent(values);
                var result = await Client.HttpClient.PostAsync("http://localhost:65177/api/Category", content);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    CategoriesList.Add(new Category() { Name = NewCategoryName});
                    CategoriesList = System.Threading.Tasks.Task.Run(() => GetCategories()).Result;
                }
            }
        }

        private bool CategoryNameIsInUse()
        {
            foreach (var category in CategoriesList)
            {
                if (category.Name == NewCategoryName)
                {
                    return true;
                }
            }
            return false;
        }

        internal async System.Threading.Tasks.Task RemoveCategoryAsync(Category category)
        {
            var result = await Client.HttpClient.DeleteAsync("http://localhost:65177/api/Category/"+category.id);
            if (result.IsSuccessStatusCode)
            {
                CategoriesList.Remove(category);
            }
            //TODO: Call backend to delete Item
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
