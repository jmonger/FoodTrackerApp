using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodTrackerApp.Models;
using FoodTrackerApp.Services;


namespace FoodTrackerApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            ApiServices apiServices = new ApiServices();

            bool response = await apiServices.LoginUser(LoginEmail.Text, LoginPassword.Text);
            if(!response)
            {
                await DisplayAlert("Alert", "Unable to Authenticate User.", "Cancel");
            }
            else
            {
                await DisplayAlert("Alert", "Log Sucessful", "Cancel");
            }
        }

        private void TapRegister_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateAccountPage());
        }
    }
}