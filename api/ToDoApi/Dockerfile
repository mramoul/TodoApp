# -------------------------------
# Build Stage
# -------------------------------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution file and project files
COPY ../*.sln .
COPY *.csproj ./ 
COPY ./ ./

# Restore dependencies
RUN dotnet restore

# Build and publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# -------------------------------
# Runtime Stage
# -------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy published app
COPY --from=build /app/publish .

# Copy SQLite database
COPY ./todo.db ./

# Ensure database is writable
RUN chmod 666 todo.db

# Expose port
EXPOSE 5001
ENV ASPNETCORE_URLS=http://+:5001

# Start the application
ENTRYPOINT ["dotnet", "ToDoApi.dll"]
