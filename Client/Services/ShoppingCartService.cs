using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCartApp.Shared;

namespace ShoppingCartApp.Client.Services
{
   public class ShoppingCartService
{
    private readonly ShoppingCart _cart = new ShoppingCart();
    public event Action OnCartUpdated;

    public void AddItemToCart(Product product, int quantity = 1)
    {
        _cart.AddItem(product, quantity);
        OnCartUpdated?.Invoke();
        Console.WriteLine($"Item added to cart: {product.Title}");
        Console.WriteLine($"Cart total: {_cart.GetTotalPrice():C}");
        Console.WriteLine("Cart items:");
        foreach (var cartItem in _cart.Items)
        {
            Console.WriteLine($"- {cartItem.Product.Title} ({cartItem.Quantity})");
        }
    }


    public bool IsCartEmpty()
    {
        return _cart.Items.Count == 0;
    }


    public void RemoveItemFromCart(ShoppingCartItem item)
    {
        _cart.RemoveItem(item);
        OnCartUpdated?.Invoke();
    }

    public IReadOnlyList<ShoppingCartItem> GetCartItems()
    {
        return _cart.Items;
    }

    public decimal GetTotalPrice()
    {
        return _cart.GetTotalPrice();
    }
}
}
