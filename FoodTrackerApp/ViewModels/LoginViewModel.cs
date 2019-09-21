using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;


namespace FoodTrackerApp.ViewModels
{
    public class LoginViewModel
    {
        public Action DisplayInvalidLoginPrompt;
        public Action DisplayAlert;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }
        public void OnSubmit()
        {
            if (email != "user" || password != "secret")
            {
                DisplayInvalidLoginPrompt();
            } else
            {
                DisplayAlert();
            }

        }


    }
}
