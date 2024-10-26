# Stage 1: Build the Blazor WebAssembly project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
WORKDIR ./Web
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Serve the Blazor WebAssembly app with a lightweight web server
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=build /app/publish/wwwroot .
COPY Web/nginx.conf /etc/nginx/nginx.conf

# Expose port 80 for serving the application
EXPOSE 80


# Start Nginx
CMD ["nginx", "-g", "daemon off;"]