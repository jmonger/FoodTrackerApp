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
using FoodTrackerApp.Tests;
//using Xamarin.Forms.PlatformConfiguration.Android.Support.V7.App;

namespace FoodTrackerApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogPage : ContentPage
    {
        public ObservableCollection<LogModelResult> Logs;
        string dateSelected;
        List<LogModelResult> logModelResults;

        public LogPage()
        {
            InitializeComponent();
            Logs = new ObservableCollection<LogModelResult>();

            logModelResults = new List<LogModelResult>()
            {
                new LogModelResult() {Id = 1, Date = "2019-01-01"},
                new LogModelResult() {Id = 2, Date = "2019-04-11"},
                new LogModelResult() {Id = 3, Date = "2018-02-03"}
            };

            FindAllLogs(logModelResults);


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

        private async void FindAllLogs(List<LogModelResult> logs)
        {

            foreach (var log in logs)
            {
                Logs.Add(log);

            }
            LvLogs.ItemsSource = Logs;
        }

        private async void LvLogs_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedLog = e.SelectedItem as LogModelResult;

            string action = await DisplayActionSheet("What would you like to do with this log?", "Cancel", null, "Update Meal","Update Ailment","Delete Log");

            if(action == "Delete Log")
            {
                bool answer = await DisplayAlert("Confirmation", "Are you sure you want to delete Log Entry " + selectedLog.Date, "Yes", "No");
                if(answer)
                {
                    Logs.Remove(selectedLog);
                    ApiServices apiServices = new ApiServices();
                    await apiServices.DeleteHealthLog(selectedLog.Id);
                }
                


            }
            if(action =="Update Meal")
            {

            }


        }
        
        private  void BtnAddLog_Clicked(object sender, EventArgs e)
        {
            //ApiServices apiServices = new ApiServices();
             //apiServices.CreateHealthLog(dateSelected);
            Logs.Add(new LogModelResult() { Id=23, Date = dateSelected });
            UpdateListView(LvLogs);

        }

        private void selected_log_date(object sender, DateChangedEventArgs e)
        {
            dateSelected = e.NewDate.ToString("yyyy-MM-dd");

        }

        void UpdateListView(ListView listView)
        {
            var itemsSource = listView.ItemsSource;
            listView.ItemsSource = null;
            listView.ItemsSource = itemsSource;
        }
    }
}