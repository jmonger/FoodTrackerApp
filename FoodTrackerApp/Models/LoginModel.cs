using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrackerApp.Models
{
    class LoginModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public Func<Task> DisplayInvalidLoginPrompt { get; internal set; }
        public Func<Task> DisplayAlert { get; internal set; }
    }
}
