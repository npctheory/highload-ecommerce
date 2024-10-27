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

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

if (builder.HostEnvironment.IsDevelopment())
{
    builder.Services.AddHttpClient("Catalogs", client => client.BaseAddress = new Uri("http://localhost:8082"));
    builder.Services.AddHttpClient("AuthenticationService", client => client.BaseAddress = new Uri("http://localhost:8084"));
    builder.Services.AddHttpClient("OrderService", client => client.BaseAddress = new Uri("http://localhost:8086"));
}
else
{
    builder.Services.AddHttpClient("Catalogs", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/catalogs/"));
}

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
await builder.Build().RunAsync();