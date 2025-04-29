# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Stories/Stories.API/Stories.API.csproj", "Services/Stories/Stories.API/"]
COPY ["Services/Stories/Stories.Application/Stories.Application.csproj", "Services/Stories/Stories.Application/"]
COPY ["Services/Stories/Stories.Domain/Stories.Domain.csproj", "Services/Stories/Stories.Domain/"]
COPY ["Services/Stories/Stories.Infrastructure/Stories.Infrastructure.csproj", "Services/Stories/Stories.Infrastructure/"]
RUN dotnet restore "./Services/Stories/Stories.API/Stories.API.csproj"
RUN dotnet restore "./Services/Stories/Stories.Application/Stories.Application.csproj"
RUN dotnet restore "./Services/Stories/Stories.Domain/Stories.Domain.csproj"
RUN dotnet restore "./Services/Stories/Stories.Infrastructure/Stories.Infrastructure.csproj"
COPY . .
WORKDIR "/src/Services/Stories/Stories.API"
RUN dotnet build "./Stories.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Stories.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stories.API.dll"]