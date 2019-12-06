using System;

using Xamarin.Forms;

namespace FoodTrackerApp.Pages
{
    public class MealsPage : ContentPage
    {
        public MealsPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

