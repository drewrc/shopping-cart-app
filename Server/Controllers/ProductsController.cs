using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingCartApp.Shared;

namespace ShoppingCartApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        string fileName = Path.Combine("Data", "products.json");
        string jsonString = await System.IO.File.ReadAllTextAsync(fileName);
        var products = JsonConvert.DeserializeObject<List<Product>>(jsonString);
        return products;
    }

    }
}
