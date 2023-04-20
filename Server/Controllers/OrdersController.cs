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
            Orders.Add(order);  // Add the incoming order to the list of orders
            var ordersJson = JsonConvert.SerializeObject(Orders);  // Serialize the list of orders to JSON
            var filePath = "/Users/roselie/Documents/ShoppingCartApp/Data/orders.json";  // Define the file path to the JSON file
            System.IO.File.WriteAllText(filePath, ordersJson);  // Write the JSON to the file
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);  // Return a 201 Created response with the newly created order
        }

        // GET: api/Orders
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Orders);  // Return a 200 OK response with the list of orders
        }

        // GET: api/Orders/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var order = Orders.Find(o => o.Id == id);  // Find the order with the specified ID in the list of orders

            if (order == null)  // If the order is not found, return a 404 Not Found response
            {
                return NotFound();
            }

            return Ok(order);  // Return a 200 OK response with the requested order
        }
    }
}
