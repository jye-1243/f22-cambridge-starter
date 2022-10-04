using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace WebAPIClient
{
    public record Article 
    {
        [JsonPropertyName("id")]
        public int Id {get; set;} 

        [JsonPropertyName("title")]
        public string ? Title { get; set; }
        
        [JsonPropertyName("author")]
        public string ? Author {get; set; }
        
        [JsonPropertyName("date")]
        public string ? Date {get; set;}
    }
}