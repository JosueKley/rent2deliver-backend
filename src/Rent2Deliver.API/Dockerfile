# Stage 1: build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy everything and restore only the Api project
COPY . .
RUN dotnet restore Rent2Deliver.Api/Rent2Deliver.Api.csproj

# Build and publish
RUN dotnet publish Rent2Deliver.Api/Rent2Deliver.Api.csproj \
    -c Release \
    -o /app/publish

# Stage 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copy published files from build stage
COPY --from=build /app/publish .

# Expose port 80
EXPOSE 80

# Entry point
ENTRYPOINT ["dotnet", "Rent2Deliver.Api.dll"]