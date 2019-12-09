using System.Collections.Generic;
using Newtonsoft.Json;

namespace FoodTrackerApp.Models
{
    public class TemporaryAilmentModel
    {

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class CreateTemporaryAilmentModelResponse
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class AddAilmentToHealthLogModel
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("calories")]
        public int Calories { get; set; }

        [JsonProperty("protein")]
        public int Protein { get; set; }

        [JsonProperty("carbohydrates")]
        public int Carbohydrates { get; set; }

        [JsonProperty("fats")]
        public int Fats { get; set; }

        [JsonProperty("ailments")]
        public List<CreateTemporaryAilmentModelResponse> AilmentsResults { get; set; }

        [JsonProperty("meals")]
        public List<AddAilmentMealModelResponse> MealResults { get; set; }
    }

    public class AilmentPatch
    {
        public List<int> ailments { get; set; }
    }


}
