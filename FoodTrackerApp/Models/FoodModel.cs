using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTrackerApp.Models
{
    public class FoodModel
    {
        public string name { get; set; }
        public int calories { get; set; }
        public int protein { get; set; }
        public int carbohydrates { get; set; }
        public int fats { get; set; }
    }
}
