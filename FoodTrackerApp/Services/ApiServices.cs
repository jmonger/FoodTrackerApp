using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FoodTrackerApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;

namespace FoodTrackerApp.Services
{
    class ApiServices
    {
        HttpClient _client;

        public ApiServices()
        {
            _client = new HttpClient();
        }

        /***AUTHENTICATION***/

        //User Login
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
            var json = JsonConvert.SerializeObject(registerModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/registration/", content);
            var result = await response.Content.ReadAsStringAsync();
            JObject jObject = JsonConvert.DeserializeObject<dynamic>(result);
            var token = jObject.Value<string>("token");
            Console.WriteLine(token);
            Settings.AccessToken = token;
            return response.IsSuccessStatusCode;
        }

        //Register User
        public async Task<bool> LoginUser(string email, string password)
        {
            var loginModel = new LoginModel()
            {
                email = email,
                password = password
            };
            var json = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/auth/", content);
            var result = await response.Content.ReadAsStringAsync();
            JObject jObject = JsonConvert.DeserializeObject<dynamic>(result);
            var token = jObject.Value<string>("token");

            Settings.AccessToken = token;
            Console.WriteLine(Settings.AccessToken);

            return response.IsSuccessStatusCode;
        }

        //***CHRONIC CONDITION***

        //Get All Conditions
        public async Task<List<Result>> GetAllChronicConditions()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", Settings.AccessToken);

            var json = await _client.GetStringAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/conditions/");
            var chronicConditions = JsonConvert.DeserializeObject<ConditionModel>(json);
            return chronicConditions.Results;
        }

        //Add Conditions to User
        public async Task<bool> AddConditionsToUser(List<int> conditionsIntCollection)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", Settings.AccessToken);
            var method = new HttpMethod("PATCH");

            var conditionPatch = new PatchResult();
            conditionPatch.conditions = conditionsIntCollection;

            var request = new HttpRequestMessage(method, "http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/users/me/")
            //var request = new HttpRequestMessage(method, "https://foodsafe.requestcatcher.com/test/")

            {
                Content = new StringContent(
                    JsonConvert.SerializeObject(conditionPatch),
                    Encoding.UTF8, "application/json")
            };
            var response = await _client.SendAsync(request);
            return response.IsSuccessStatusCode;
        }




        /***FOOD***/

        //Create Food




        //Retrieve Food

        //Search Food




        //***MEALS***



        //***HEALTH LOG***

        //***TEMPORARY AILMENT***

        //***CLIENT INFO***

        //***TICKET***

        //***REPORTS***



    }

}
