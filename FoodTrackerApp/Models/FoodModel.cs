// Helpers/FoodModel.cs
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FoodTrackerApp.Models
{
    public class FoodModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("calories")]
        public int Calories { get; set; }

        [JsonProperty("protein")]
        public int Protein { get; set; }

        [JsonProperty("carbohydrates")]
        public int Carbohydrates { get; set; }
        
        [JsonProperty("fats")]
        public int Fats { get; set; }
    }

    public class AddAilmentFoodModelResponse
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("calories")]
        public int Calories { get; set; }

        [JsonProperty("protein")]
        public int Protein { get; set; }

        [JsonProperty("carbohydrates")]
        public int Carbohydrates { get; set; }

        [JsonProperty("fats")]
        public int Fats { get; set; }
    }

    public class FoodSearchModel
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("results")]
        public List<FoodModel> FoodModelResults { get; set; }
    }
}
