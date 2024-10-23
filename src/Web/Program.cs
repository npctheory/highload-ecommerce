using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Web;
using Web.ServiceImplementations;
using Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

if (builder.HostEnvironment.IsDevelopment())
{
    builder.Services.AddHttpClient("CatalogsService", client => client.BaseAddress = new Uri("http://localhost:8080"));
    builder.Services.AddHttpClient("AuthenticationService", client => client.BaseAddress = new Uri("http://localhost:8082"));
    builder.Services.AddHttpClient("OrderService", client => client.BaseAddress = new Uri("http://localhost:8084"));
}
else
{
    builder.Services.AddHttpClient("CatalogsService", client => client.BaseAddress = new Uri("http://catalogs:80"));
    builder.Services.AddHttpClient("AuthenticationService", client => client.BaseAddress = new Uri("http://authentication:80"));
    builder.Services.AddHttpClient("OrderService", client => client.BaseAddress = new Uri("http://orders:80"));
}

builder.Services.AddScoped<IProductService, ProductServiceMockUp>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

await builder.Build().RunAsync();