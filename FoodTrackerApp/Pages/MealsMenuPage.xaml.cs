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
        string selectedLogDate;
        string savedLogDate;
        string savedLogId;
        string selectedMeal;
        public MealsMenuPage()
        {
            InitializeComponent();
            savedLogDate = Settings.LogDate;
            savedLogId = Settings.LogId;

        }

        private void BtnSelectMeal_Clicked(object sender, EventArgs e)
        {
            if (selectedLogDate != savedLogDate)
            {
                savedLogDate = selectedLogDate;
            }

            //Console.WriteLine(savedLogDate);

        }

        private void SelectedLogDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            selectedLogDate = e.NewDate.ToString("yyyy-MM-dd");

        }

        private void MealsGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

                if (MealsGroup.SelectedIndex !=-1)
                {
                    selectedMeal = MealsGroup.Items[MealsGroup.SelectedIndex];
;                    Console.WriteLine(selectedMeal);
                }



        }
    }
}
