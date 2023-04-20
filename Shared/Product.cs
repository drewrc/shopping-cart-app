using Newtonsoft.Json;

namespace ShoppingCartApp.Shared
{
    public class Product
    {
        [JsonProperty("sku")]
        public string? Sku { get; set; }  // The SKU of the product

        [JsonProperty("title")]
        public string? Title { get; set; }  // The title of the product

        [JsonProperty("price")]
        public decimal Price { get; set; }  // The price of the product
    }
}
