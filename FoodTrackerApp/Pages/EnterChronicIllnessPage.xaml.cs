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
        public List<int> SelectedConditions;

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

        private async void chronBtn_Clicked(object sender, EventArgs e)
        {
            ApiServices apiServices = new ApiServices();
            await apiServices.AddConditionsToUser(SelectedConditions);


            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();

        }

        private void CheckBox_CheckChanged(object sender, EventArgs e)
        {
            SelectedConditions = new List<int>();

            for (int i =0;i<Conditions.Count; i++)
            {
                Result cond = Conditions[i];


                if (cond.ROWCHECK)
                {
                    SelectedConditions.Add(cond.Id);
                    Console.WriteLine("Condition Id: " + cond.Id);
                }
            }

        }
    }
}
