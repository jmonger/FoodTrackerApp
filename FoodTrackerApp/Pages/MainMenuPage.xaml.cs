using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodTrackerApp.Pages;

namespace FoodTrackerApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private async void meals_btn_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MealsMenu());


            
        }
    }
}