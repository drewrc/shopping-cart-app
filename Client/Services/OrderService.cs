using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ShoppingCartApp.Shared;

namespace ShoppingCartApp.Client.Services
{
    public class OrderService
    {
        private readonly string _filePath;

        public OrderService(string filePath)
        {
            _filePath = filePath;
        }

        public void SaveOrder(Order order)
        {
            var orders = LoadOrders();
            orders.Add(order);
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(orders));
        }

        public List<Order> LoadOrders()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Order>();
            }

            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Order>>(json);
        }
        public List<Order> GetAllOrders()
        {
            return LoadOrders();
        }

    }
}
