// Newtonsoft.Json library, which provides tools for working with JSON data in C#
using Newtonsoft.Json;

namespace ShoppingCartApp.Shared
{
    public class Product
    {
        [JsonProperty("sku")]
        public string? Sku { get; set; }  

        [JsonProperty("title")]
        public string? Title { get; set; }  

        [JsonProperty("price")]
        public decimal Price { get; set; } 
    }
}
