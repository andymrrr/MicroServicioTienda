#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ServicioTienda.Api.Libro/ServicioTienda.Api.Libro.csproj", "ServicioTienda.Api.Libro/"]
RUN dotnet restore "./ServicioTienda.Api.Libro/./ServicioTienda.Api.Libro.csproj"
COPY . .
WORKDIR "/src/ServicioTienda.Api.Libro"
RUN dotnet build "./ServicioTienda.Api.Libro.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ServicioTienda.Api.Libro.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServicioTienda.Api.Libro.dll"]