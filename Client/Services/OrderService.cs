// Required namespaces
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ShoppingCartApp.Shared;

namespace ShoppingCartApp.Client.Services
{
    public class OrderService
    {
        // A private field to store the file path where orders will be saved/loaded
        private readonly string _filePath;

        // Constructor for the OrderService class that takes a file path as a parameter
        public OrderService(string filePath)
        {
            // Assign the file path to the private field
            _filePath = filePath;
        }

        // Method to save a new order
        public void SaveOrder(Order order)
        {
            // Load existing orders from the file
            var orders = LoadOrders();
            
            // Add the new order to the list
            orders.Add(order);
            
            // Serialize the updated list of orders as a JSON string and save it to the file
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(orders));
        }

        // Method to load orders from the file
        public List<Order> LoadOrders()
        {
            // If the file doesn't exist, return an empty list of orders
            if (!File.Exists(_filePath))
            {
                return new List<Order>();
            }

            // Read the JSON string from the file
            var json = File.ReadAllText(_filePath);
            
            // Deserialize the JSON string into a List<Order> object and return it
            return JsonConvert.DeserializeObject<List<Order>>(json);
        }
        
        // Method to get all orders (it's an alias to LoadOrders)
        public List<Order> GetAllOrders()
        {
            return LoadOrders();
        }

    }
}
