using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTrackerApp.Models
{
    class RegisterModel
    {
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string password { get; set; }
        public int age { get; set; }
        public int weight { get; set; }
        public int height { get; set; }
        public string birth_date { get; set; }
    }
}
