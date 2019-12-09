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
        public async Task<FoodModel> CreateFood(FoodModel foodModel)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "dc7fdbb7c51275af932b2669ccb737fe91432018");
            var json = JsonConvert.SerializeObject(foodModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/foods/", content);
            var result = await response.Content.ReadAsStringAsync();
            var food = JsonConvert.DeserializeObject<FoodModel>(result);          
            return food;
        }

        //Retrieve Food
        public async Task<FoodModel> RetrieveFoodById(int id)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "dc7fdbb7c51275af932b2669ccb737fe91432018");
            var json = await _client.GetStringAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/foods/" + id);
            var food = JsonConvert.DeserializeObject<FoodModel>(json);
            return food;
        }

        //Search Food by name
        public async Task<FoodModel> RetrieveFoodByName(string name)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "dc7fdbb7c51275af932b2669ccb737fe91432018");
            var json = await _client.GetStringAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/foods/" + name);
            var food = JsonConvert.DeserializeObject<FoodModel>(json);
            return food;
        }

        //***MEALS***
        //Create Meal
        public async Task<CreateMealModelResponse> CreateMeal(MealModel mealModel)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "dc7fdbb7c51275af932b2669ccb737fe91432018");
            var json = JsonConvert.SerializeObject(mealModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/meals/", content);
            var result = await response.Content.ReadAsStringAsync();
            var meal = JsonConvert.DeserializeObject<CreateMealModelResponse>(result);
            return meal;
        }

        //Retrieve Meal
        public async Task<CreateMealModelResponse> RetrieveMealById(int id)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "dc7fdbb7c51275af932b2669ccb737fe91432018");
            var json = await _client.GetStringAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/meals/" + id);
            var meal = JsonConvert.DeserializeObject<CreateMealModelResponse>(json);
            return meal;
        }

        //Update Meal
        public async Task<CreateMealModelResponse> UpdateMeal(MealModel mealModel)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "dc7fdbb7c51275af932b2669ccb737fe91432018");
            var json = JsonConvert.SerializeObject(mealModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/meals/", content);
            var result = await response.Content.ReadAsStringAsync();
            var meal = JsonConvert.DeserializeObject<CreateMealModelResponse>(result);
            return meal;
        }

        //Delete Meal
        public async Task<bool> DeleteMeal(int id)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "dc7fdbb7c51275af932b2669ccb737fe91432018");
            var response = await _client.DeleteAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/meals/" + id);
            //var response = await _client.DeleteAsync("https://foodsafe.requestcatcher.com/test/" +id);
            Console.WriteLine(response.IsSuccessStatusCode);
            return response.IsSuccessStatusCode;
        }

        //Search Meals by Date Range
        public async Task<IList<MealModel>> GetHMealsByDateRange(string before, string after)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "dc7fdbb7c51275af932b2669ccb737fe91432018");
            _client.DefaultRequestHeaders.Add("before", before);
            _client.DefaultRequestHeaders.Add("after", after);
            var json = await _client.GetStringAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/meals/");
            var meals = JsonConvert.DeserializeObject<SearchMealModelResponse>(json);
            return meals.MealModelResults;
        }


        //***HEALTH LOG***/
        //Get All Health Logs
        public async Task<List<LogModelResult>> GetAllHealthLogs()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "dc7fdbb7c51275af932b2669ccb737fe91432018");
            var json = await _client.GetStringAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/logs/");
            var logs = JsonConvert.DeserializeObject<LogModel>(json);
            Console.WriteLine(json);
            return logs.LogModelResult;
        }

        //Delete Health Log by Id
        public async Task<bool> DeleteHealthLog(int id)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "dc7fdbb7c51275af932b2669ccb737fe91432018");
            var response = await _client.DeleteAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/logs/" + id);
            //var response = await _client.DeleteAsync("https://foodsafe.requestcatcher.com/test/" +id);
            Console.WriteLine(response.IsSuccessStatusCode);
            return response.IsSuccessStatusCode;
        }

        //Retrieve Health Log by Id
        public async Task<LogModel> GetHealthLogById(int id)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "dc7fdbb7c51275af932b2669ccb737fe91432018");

            var json = await _client.GetStringAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/logs/" + id);

            var logs = JsonConvert.DeserializeObject<LogModel>(json);
            Console.WriteLine(json);
            return logs;
        }

        //Create Health Log
        public async Task<bool> CreateHealthLog(string date)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "dc7fdbb7c51275af932b2669ccb737fe91432018");

            var createLogModel = new CreateLogModel()
            {
                Date = date
            };
            var json = JsonConvert.SerializeObject(createLogModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/logs/", content);
            var result = await response.Content.ReadAsStringAsync();
            JObject jObject = JsonConvert.DeserializeObject<dynamic>(result);
            var token = jObject.Value<string>("token");

            Settings.AccessToken = token;
            Console.WriteLine(Settings.AccessToken);

            return response.IsSuccessStatusCode;
        }

        //Search Health Log
        public async Task<List<LogModelResult>> GetHealthLogsByDateRange(string before, string after)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "dc7fdbb7c51275af932b2669ccb737fe91432018");
            _client.DefaultRequestHeaders.Add("before", before);
            _client.DefaultRequestHeaders.Add("after", after);

            var json = await _client.GetStringAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/logs/");
            var logs = JsonConvert.DeserializeObject<LogModel>(json);

            return logs.LogModelResult;
        }


        //***TEMPORARY AILMENT***
        //Create Temp Ailment
        public async Task<CreateTemporaryAilmentModelResponse> CreateTemporaryAilment(TemporaryAilmentModel temporaryAilmentModel)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "dc7fdbb7c51275af932b2669ccb737fe91432018");
            var json = JsonConvert.SerializeObject(temporaryAilmentModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/ailments/", content);
            var result = await response.Content.ReadAsStringAsync();
            var ailment = JsonConvert.DeserializeObject<CreateTemporaryAilmentModelResponse>(result);
            return ailment;
        }

        //RetrieveTemporary Ailment
        public async Task<CreateTemporaryAilmentModelResponse> RetrieveAilmentById(int id)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "dc7fdbb7c51275af932b2669ccb737fe91432018");
            var json = await _client.GetStringAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/ailments/" + id);
            var ailment = JsonConvert.DeserializeObject<CreateTemporaryAilmentModelResponse>(json);
            return ailment;
        }

        //Search Ailment By Name
        public async Task<CreateTemporaryAilmentModelResponse> RetrieveAilmentByName(string name)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "dc7fdbb7c51275af932b2669ccb737fe91432018");
            var json = await _client.GetStringAsync("http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/ailments/" + name);
            var ailment = JsonConvert.DeserializeObject<CreateTemporaryAilmentModelResponse>(json);
            return ailment;
        }

        //Add Ailment to Health Log
        public async Task<bool> AddAilmentToLog(List<int> ailmentsIntCollection, int logId)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", Settings.AccessToken);
            var method = new HttpMethod("PATCH");

            var ailmentPatch = new AilmentPatch();
            ailmentPatch.ailments = ailmentsIntCollection;

            var request = new HttpRequestMessage(method, "http://healthlog-deployment.dbmvyepwfm.us-east-1.elasticbeanstalk.com/api/logs/" +logId)
            //var request = new HttpRequestMessage(method, "https://foodsafe.requestcatcher.com/test/")

            {
                Content = new StringContent(
                    JsonConvert.SerializeObject(ailmentPatch),
                    Encoding.UTF8, "application/json")
            };
            var response = await _client.SendAsync(request);
            return response.IsSuccessStatusCode;
        }

        //***CLIENT INFO***

        //***TICKET***


        //***REPORTS***



    }

}
