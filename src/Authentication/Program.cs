using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Reflection;
using MediatR;
using AutoMapper;
using Authentication.RepositoryInterfaces;
using Authentication.RepositoryImplementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));


builder.Services.AddAuthorization();


var connectionString = builder.Configuration["DatabaseSettings:ConnectionString"];
builder.Services.AddScoped<ILoginEntityRepository>(provider => 
    new LoginEntityRepositoryMySql(connectionString));
// builder.Services.AddScoped<ICharEntityRepository, CharEntityRepositoryMySql>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
