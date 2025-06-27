# Stage 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution file
COPY *.sln ./

# Copy project files for restore
COPY src/Rent2Deliver.Domain/*.csproj src/Rent2Deliver.Domain/
COPY src/Rent2Deliver.Infrastructure/*.csproj src/Rent2Deliver.Infrastructure/
COPY src/Rent2Deliver.Messaging/*.csproj src/Rent2Deliver.Messaging/
COPY src/Rent2Deliver.API/*.csproj src/Rent2Deliver.API/

# Restore dependencies for all projects
RUN dotnet restore

# Copy everything else and build
COPY src/Rent2Deliver.Domain/. src/Rent2Deliver.Domain/
COPY src/Rent2Deliver.Infrastructure/. src/Rent2Deliver.Infrastructure/
COPY src/Rent2Deliver.Messaging/. src/Rent2Deliver.Messaging/
COPY src/Rent2Deliver.API/. src/Rent2Deliver.API/

WORKDIR /src/src/Rent2Deliver.API
RUN dotnet publish -c Release -o /app/publish

# Stage 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "Rent2Deliver.API.dll"]