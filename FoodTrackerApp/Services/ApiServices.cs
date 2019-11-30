using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FoodTrackerApp.Models;
using Newtonsoft.Json;

namespace FoodTrackerApp.Services
{
    class ApiServices
    {
        public async Task<bool> RegisterUserAsync(string email, string first_name, string last_name, string password, int age,
                                 int weight,
                                 int height,
                                 string birth_date)
        {
            var registerModel = new RegisterModel()
            {
                email = email,
                first_name = first_name,
                last_name = last_name,
                password = password,
                age = age,
                weight = weight,
                height = height,
                birth_date = birth_date
            };

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(registerModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/registration/", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            var loginModel = new LoginModel()
            {
                email = email,
                password = password
            };

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/auth", content);
            return response.IsSuccessStatusCode;
        }
    }
}
