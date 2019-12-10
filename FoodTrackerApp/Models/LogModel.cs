using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace FoodTrackerApp.Models
{
    public class LogModelResult 
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

    }

    public class LogModel
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public object Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public List<LogModelResult> LogModelResult { get; set; }
    }

    public class CreateLogModel
    {
        [JsonProperty("date")]
        public string Date { get; set; }
    }

    public class SearchLogModel
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("results")]
        public List<LogModelResult> LogModelResult { get; set; }
    }
}
