using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
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
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var json = JsonConvert.SerializeObject(registerModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/registration/", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> LoginUser(string email, string password)
        {

            var loginModel = new LoginModel()
            {
                email = "matt@email.com",
                password = "password"
            };

            var httpClient = new HttpClient();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var json = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/auth/", content);
            var result = await response.Content.ReadAsStringAsync();
            Debug.WriteLine("API REsponse" + result);
            return response.IsSuccessStatusCode;
            
        }
    }
}
