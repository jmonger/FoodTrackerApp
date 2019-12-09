using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodTrackerApp.Models;
using System.Collections.ObjectModel;
using FoodTrackerApp.Services;
using Android.Support.V7.App;

namespace FoodTrackerApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogPage : ContentPage
    {
        public ObservableCollection<LogModelResult> Logs;

        public LogPage()
        {
            InitializeComponent();
            Logs = new ObservableCollection<LogModelResult>();

            FindAllLogs();
        }

        private async void FindAllLogs()
        {
            ApiServices apiServices = new ApiServices();
            var logs = await apiServices.GetAllHealthLogs();
            foreach (var log in logs)
            {
                Logs.Add(log);

            }
            LvLogs.ItemsSource = Logs;
        }

        private async void LvLogs_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedLog = e.SelectedItem as LogModelResult;

            string action = await DisplayActionSheet("What would you like to do to this log?", "Cancel", null, "View","Update","Delete");

            if(action == "Delete")
            {
                bool answer = await DisplayAlert("Confirmation", "Are you sure you want to delete Log Entry " + selectedLog.Date, "Yes", "No");
                if(answer)
                {
                    Logs.Remove(selectedLog);
                    ApiServices apiServices = new ApiServices();
                    await apiServices.DeleteHealthLog(selectedLog.Id);


                }


            }


        }


    }
}