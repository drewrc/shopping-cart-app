using System.Collections.Generic; // import the System.Collections.Generic namespace
using System.Linq; // import the System.Linq namespace

namespace ShoppingCartApp.Shared // define a namespace for the class
{
    public class ShoppingCart // define a C# class called "ShoppingCart"
    {
        private readonly List<ShoppingCartItem> _items = new List<ShoppingCartItem>(); // declare a private list of ShoppingCartItem objects called "_items"
             //private fields are typically named with an underscore prefix to differentiate them from public properties or methods

        public IReadOnlyList<ShoppingCartItem> Items => _items; // define a public read-only property called "Items" that returns the list of ShoppingCartItem objects

   

        public void AddItem(Product product, int quantity = 1) // define a public method called "AddItem" that takes a Product object and an optional quantity value as arguments
        {
            var item = _items.FirstOrDefault(i => i.Product.Sku == product.Sku); // find the ShoppingCartItem object in the list that corresponds to the specified Product object
            if (item == null) // if the ShoppingCartItem object doesn't exist in the list
            {
                item = new ShoppingCartItem { Product = product, Quantity = quantity }; // create a new ShoppingCartItem object with the specified Product object and quantity value
                _items.Add(item); // add the new ShoppingCartItem object to the list
            }
            else // if the ShoppingCartItem object already exists in the list
            {
                item.Quantity += quantity; // add the specified quantity value to the ShoppingCartItem object's Quantity property
            }
        }

        public void RemoveItem(ShoppingCartItem item) // define a public method called "RemoveItem" that takes a ShoppingCartItem object as an argument
        {
            _items.Remove(item); // remove the specified ShoppingCartItem object from the list
        }

        public decimal GetTotalPrice() // define a public method called "GetTotalPrice" that returns the total price of all items in the shopping cart
        {
            return _items.Sum(item => item.Product.Price * item.Quantity); // use LINQ to sum the total price of all ShoppingCartItem objects in the list
        }
    }
}
