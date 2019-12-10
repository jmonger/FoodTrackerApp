using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodTrackerApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void MealsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MealsMenuPage());
        }

        private void LogButton_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new LogPage());

        }
    }
}