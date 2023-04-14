using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp.Shared
{
public class ShoppingCart
{
    private readonly List<ShoppingCartItem> _items = new List<ShoppingCartItem>();

    public IReadOnlyList<ShoppingCartItem> Items => _items;

    public void AddItem(Product product, int quantity = 1)
    {
        var item = _items.FirstOrDefault(i => i.Product.Sku == product.Sku);
        if (item == null)
        {
            item = new ShoppingCartItem { Product = product, Quantity = quantity };
            _items.Add(item);
        }
        else
        {
            item.Quantity += quantity;
        }
    }

    public void RemoveItem(ShoppingCartItem item)
    {
        _items.Remove(item);
    }

    public decimal GetTotalPrice()
    {
        return _items.Sum(item => item.Product.Price * item.Quantity);
    }
}
}
