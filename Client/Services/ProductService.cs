using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShoppingCartApp.Shared;

namespace ShoppingCartApp.Client.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>?> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync("api/products");
            var content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);
            return products;
        }
    }
}
