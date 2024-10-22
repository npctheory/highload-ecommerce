```bash
dotnet new sln -o HighloadItemShop
mv HighloadItemShop src

dotnet new webapi -o src/Authentication
dotnet new webapi -o src/Catalogs
dotnet new webapi -o src/Orders
dotnet new classlib -o src/Shared
dotnet new blazorwasm -o src/Web

dotnet sln src/HighloadItemShop.sln add src/Authentication/
dotnet sln src/HighloadItemShop.sln add src/Catalogs/
dotnet sln src/HighloadItemShop.sln add src/Orders/
dotnet sln src/HighloadItemShop.sln add src/Shared/
dotnet sln src/HighloadItemShop.sln add src/Web/

rm src/Authentication/Authentication.http
rm src/Catalogs/Catalogs.http
rm src/Orders/Orders.http
rm src/Shared/Class1.cs



dotnet add src/Authentication/ reference src/Shared/
dotnet add src/Catalogs/ reference src/Shared/
dotnet add src/Orders/ reference src/Shared/
dotnet add src/Web/ reference src/Shared/

mkdir -p src/Shared/Events/
mkdir -p src/Shared/DTO/

mkdir -p src/Authentication/Configuration/
mkdir -p src/Authentication/Entities/
mkdir -p src/Authentication/RepositoryInterfaces/
mkdir -p src/Authentication/Queries/
mkdir -p src/Authentication/Commands/
mkdir -p src/Authentication/ServiceInterfaces/
mkdir -p src/Authentication/RepositoryImplementations/
mkdir -p src/Authentication/ServiceImplementations/
mkdir -p src/Authentication/Controllers/

mkdir -p src/Catalogs/Configuration/
mkdir -p src/Catalogs/Entities/
mkdir -p src/Catalogs/RepositoryInterfaces/
mkdir -p src/Catalogs/Queries/
mkdir -p src/Catalogs/Commands/
mkdir -p src/Catalogs/ServiceInterfaces/
mkdir -p src/Catalogs/RepositoryImplementations/
mkdir -p src/Catalogs/ServiceImplementations/
mkdir -p src/Catalogs/Controllers/

mkdir -p src/Orders/Configuration/
mkdir -p src/Orders/Entities/
mkdir -p src/Orders/RepositoryInterfaces/
mkdir -p src/Orders/Queries/
mkdir -p src/Orders/Commands/
mkdir -p src/Orders/ServiceInterfaces/
mkdir -p src/Orders/RepositoryImplementations/
mkdir -p src/Orders/ServiceImplementations/
mkdir -p src/Orders/Controllers/





touch src/Authentication/Dockerfile
touch src/Catalogs/Dockerfile
touch src/Orders/Dockerfile
touch src/Web/Dockerfile


mkdir -p src/Shared/DTO/Catalogs/
mkdir -p src/Shared/DTO/Orders/
mkdir -p src/Shared/DTO/Authentication/

touch src/Shared/DTO/Catalogs/CategoryDTO.cs
touch src/Shared/DTO/Catalogs/ProductDTO.cs

mkdir -p src/Web/Shared/

touch src/Web/Shared/ProductListViewModel.razor
touch src/Web/Pages/ProductDetails.razor

mkdir -p src/Web/Services/
mkdir -p src/Web/ServiceImplementations/

touch src/Web/Services/IProductService.cs
touch src/Web/ServiceImplementations/ProductServiceImplementation.cs
touch src/Web/Services/ICategoryService.cs
touch src/Web/ServiceImplementations/CategoryServiceMockUp.cs





dotnet add src/Authentication package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add src/Authentication package Microsoft.Extensions.Options
dotnet add src/Authentication package Microsoft.Extensions.Options.ConfigurationExtensions
dotnet add src/Authentication package AutoMapper
dotnet add src/Authentication package Microsoft.Extensions.Configuration
dotnet add src/Authentication package Microsoft.IdentityModel.Tokens
dotnet add src/Authentication package System.IdentityModel.Tokens.Jwt
dotnet add src/Authentication package Bogus
dotnet add src/Authentication package Npgsql
dotnet add src/Authentication package MassTransit.RabbitMQ

dotnet add src/Catalogs package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add src/Catalogs package Microsoft.Extensions.Options
dotnet add src/Catalogs package Microsoft.Extensions.Options.ConfigurationExtensions
dotnet add src/Catalogs package AutoMapper
dotnet add src/Catalogs package Microsoft.Extensions.Configuration
dotnet add src/Catalogs package Microsoft.IdentityModel.Tokens
dotnet add src/Catalogs package Npgsql
dotnet add src/Catalogs package MassTransit.RabbitMQ

dotnet add src/Orders package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add src/Orders package Microsoft.Extensions.Options
dotnet add src/Orders package Microsoft.Extensions.Options.ConfigurationExtensions
dotnet add src/Orders package AutoMapper
dotnet add src/Orders package Microsoft.Extensions.Configuration
dotnet add src/Orders package Microsoft.IdentityModel.Tokens
dotnet add src/Orders package Npgsql
dotnet add src/Orders package MassTransit.RabbitMQ


```
