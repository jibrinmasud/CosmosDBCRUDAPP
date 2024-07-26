using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ComosCrud.Models
{
    public class Driver
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int DriverNumber { get; set; }
        [JsonProperty(PropertyName = "team")]
        public string Team { get; set; } = string.Empty;
    }
}