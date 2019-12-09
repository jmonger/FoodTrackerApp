using System.Collections.Generic;
using Newtonsoft.Json;

namespace FoodTrackerApp.Models
{
    public class MealModel
    {
        [JsonProperty("log")]
        public int Log { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("food")]
        public int Food { get; set; }
    }

    public class CreateMealModelResponse
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("log")]
        public LogModel Log { get; set; }

        [JsonProperty("food")]
        public FoodModel Food { get; set; }
    }

    public class SearchMealModelResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("results")]
        public List<MealModel> MealModelResults { get; set; }
    }

    public class AddAilmentMealModelResponse
    {

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("food")]
        public AddAilmentFoodModelResponse FoodResult { get; set; }
    }
}
