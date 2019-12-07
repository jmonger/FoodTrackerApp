using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FoodTrackerApp.Models;
using Newtonsoft.Json;
using Xamarin.Essentials;

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
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
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
            //For TLS https support
            //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var json = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/auth/", content);
            var result = await response.Content.ReadAsStringAsync();
            
            try
            {
                await SecureStorage.SetAsync("token", result);
            } catch (Exception)
            {

            }        
            return response.IsSuccessStatusCode;           
        }

        public async Task<ConditionsModel> AllConditions()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", 
                //await SecureStorage.GetAsync("token")
                "dc7fdbb7c51275af932b2669ccb737fe91432018");
            var foodSafeApiUrl = "http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/conditions/";
            var json = await httpClient.GetStringAsync(foodSafeApiUrl);
            return JsonConvert.DeserializeObject<ConditionsModel>(json);
        }

    }
}
