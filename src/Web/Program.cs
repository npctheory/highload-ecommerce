using System.Collections.Immutable;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Web;
using Web.ServiceImplementations;
using Web.Services;
using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<CustomAuthorizationMessageHandler>();

if (builder.HostEnvironment.IsDevelopment())
{
    builder.Services.AddHttpClient("Catalogs", client => 
        client.BaseAddress = new Uri("http://localhost:8082"))
        .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
        
    builder.Services.AddHttpClient("AuthenticationService", client => 
        client.BaseAddress = new Uri("http://localhost:8084"))
        .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
        
    builder.Services.AddHttpClient("OrderService", client => 
        client.BaseAddress = new Uri("http://localhost:8086"))
        .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
        
    builder.Services.AddHttpClient("PaymentService", client => 
        client.BaseAddress = new Uri("http://localhost:8088"))
        .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
}
else
{
    builder.Services.AddHttpClient("Catalogs", client => 
        client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/catalogs/"))
        .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
        
    builder.Services.AddHttpClient("AuthenticationService", client => 
        client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/authentication/"))
        .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
        
    builder.Services.AddHttpClient("OrderService", client => 
        client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/orders/"))
        .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
        
    builder.Services.AddHttpClient("PaymentService", client => 
        client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/payments/"))
        .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
}

builder.Services.AddScoped<JwtSecurityTokenHandler>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
await builder.Build().RunAsync();