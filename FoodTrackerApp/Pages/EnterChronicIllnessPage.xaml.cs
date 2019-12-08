using FoodTrackerApp.Models;
using FoodTrackerApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FoodTrackerApp.Pages
{
    public partial class EnterChronicIllnessPage : ContentPage
    {
        public ObservableCollection <Result> Conditions;
        public EnterChronicIllnessPage()
        {
            InitializeComponent();
            Conditions = new ObservableCollection<Result>();
            FindAllConditions();
            
        }

        private async void FindAllConditions()
        {
            ApiServices apiServices = new ApiServices();
            var chronConditions = await apiServices.GetAllChronicConditions();
            foreach(var condition in chronConditions)
            {
                Conditions.Add(condition);

            }
            LvChronicConditions.ItemsSource = Conditions;
        }
    }
}
