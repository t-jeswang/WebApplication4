using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace WebApplication4.Models
{
    public class PostModel
    {
      
        public string Live { get; set; }
        [JsonProperty("NotificationItems")]
        public string NotificationItems { get; set; }

    }
}
