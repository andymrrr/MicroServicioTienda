#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ServicioTienda.Api.CarritoCompra/ServicioTienda.Api.CarritoCompra.csproj", "ServicioTienda.Api.CarritoCompra/"]
RUN dotnet restore "./ServicioTienda.Api.CarritoCompra/./ServicioTienda.Api.CarritoCompra.csproj"
COPY . .
WORKDIR "/src/ServicioTienda.Api.CarritoCompra"
RUN dotnet build "./ServicioTienda.Api.CarritoCompra.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ServicioTienda.Api.CarritoCompra.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServicioTienda.Api.CarritoCompra.dll"]