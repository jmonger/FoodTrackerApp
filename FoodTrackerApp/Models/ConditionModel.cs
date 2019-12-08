using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTrackerApp.Models
{
    public class ConditionModel
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("next")]
        public object Next { get; set; }
        [JsonProperty("previous")]
        public object Previous { get; set; }
        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }


}
