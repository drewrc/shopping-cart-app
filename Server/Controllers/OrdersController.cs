using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Shared;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace ShoppingCartApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private static readonly List<Order> Orders = new List<Order>();

        // POST: api/Orders
        [HttpPost]
        public IActionResult Post(Order order)
        {
            Orders.Add(order);
            var ordersJson = JsonConvert.SerializeObject(Orders);
            var filePath = "/Users/roselie/Documents/ShoppingCartApp/Data/orders.json";
            System.IO.File.WriteAllText(filePath, ordersJson);
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }

        // GET: api/Orders
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Orders);
        }

        // GET: api/Orders/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var order = Orders.Find(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
    }
}
