using System;
using Newtonsoft.Json;

namespace FoodTrackerApp.Models
{
    public class TicketModel
    {

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class TicketModelResponse
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("created_on")]
        public DateTime CreatedOn { get; set; }
    }
}
