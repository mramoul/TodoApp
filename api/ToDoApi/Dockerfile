# Use the official .NET 9 SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy everything from the project root to the container
COPY . .

# Restore dependencies
RUN dotnet restore

# Build the application in Release mode
RUN dotnet build -c Release -o /app/build

# Publish the application
RUN dotnet publish -c Release -o /app/publish

# Use the official .NET runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy the published files from the build stage
COPY --from=build /app/publish .

# Expose the application's port
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:5001 

# Start the application
ENTRYPOINT ["dotnet", "ToDoApi.dll"]