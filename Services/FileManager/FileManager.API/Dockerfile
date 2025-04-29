# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
 


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/FileManager/FileManager.API/FileManager.API.csproj", "Services/FileManager/FileManager.API/"]
COPY ["Services/FileManager/FileManager.Application/FileManager.Application.csproj", "Services/FileManager/FileManager.Application/"]
COPY ["Services/FileManager/FileManager.Domain/FileManager.Domain.csproj", "Services/FileManager/FileManager.Domain/"]
COPY ["Services/FileManager/FileManager.Infrastructure/FileManager.Infrastructure.csproj", "Services/FileManager/FileManager.Infrastructure/"]
RUN dotnet restore "./Services/FileManager/FileManager.API/FileManager.API.csproj"
RUN dotnet restore "./Services/FileManager/FileManager.Application/FileManager.Application.csproj"
RUN dotnet restore "./Services/FileManager/FileManager.Domain/FileManager.Domain.csproj"
RUN dotnet restore "./Services/FileManager/FileManager.Infrastructure/FileManager.Infrastructure.csproj"
COPY . .
WORKDIR "/src/Services/FileManager/FileManager.API"
RUN dotnet build "./FileManager.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FileManager.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FileManager.API.dll"]