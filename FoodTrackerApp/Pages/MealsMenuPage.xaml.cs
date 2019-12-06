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
    public partial class MealsMenuPage : ContentPage
    {
        public MealsMenuPage()
        {
            InitializeComponent();
        }

        private void BtnSelectMeal_Clicked(object sender, EventArgs e)
        {

        }
    }
}