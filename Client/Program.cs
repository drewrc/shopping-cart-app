using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShoppingCartApp.Client;
using ShoppingCartApp.Client.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ShoppingCartService>();
// builder.Services.AddSingleton<ShoppingCartService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddSingleton(x => new OrderService("orders.json"));

await builder.Build().RunAsync();
