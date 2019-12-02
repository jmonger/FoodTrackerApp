using System;
using System.Collections.Generic;
using Xamarin.Forms;
using FoodTrackerApp.Services;

namespace FoodTrackerApp.Pages
{
    public partial class CreateAccountPage : ContentPage
    {
        private const string Cancel = "OK";
        String birthday = "";
        public CreateAccountPage()
        {
            InitializeComponent();

        }

        private void birth_date_DateSelected(object sender, DateChangedEventArgs e)
        {
            birthday = e.NewDate.ToString("yyyy-MM-dd");
           
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            ApiServices apiServices = new ApiServices();

            bool confirmPass = Password.Text == ConfirmPassword.Text;

            if(birthday != "" || confirmPass)
            {
                bool response = await apiServices.RegisterUserAsync(
                Email.Text,
                FirstName.Text,
                LastName.Text,
                Password.Text,
                Int32.Parse(Age.Text),
                Int32.Parse(Weight.Text),
                Int32.Parse(Height.Text),
                birthday
                );
                if (!response)
                {
                    await DisplayAlert("Alert", "Unable to Create User Account", Cancel);
                }
                else
                {
                    await DisplayAlert("Alert", "User Account Created", Cancel);
                    await Navigation.PopToRootAsync();
                }
            } else if (!confirmPass) {
                await DisplayAlert("Alert", "Passwords do not match!", Cancel);

            } else if (birthday == "")
            {
                await DisplayAlert("Alert", "Please Enter Birthday to Continue", Cancel);

            }




        }
    }
}
