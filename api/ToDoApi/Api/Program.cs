using ToDoApi.Infrastructure;
using ToDoApi.Application;
using ToDoApi.Infrastructure.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Api;

var builder = WebApplication.CreateBuilder(args);

// Add infrastructure services.
builder.AddInfrastructureServices();

// Add application services.
builder.AddApplicationServices();

// Build the app
var app = builder.Build();

// Add Middlewares
app.UseMiddlewares();

// Add API endpoints
app.UseApiEndpoints();

// Swagger Activation
app.UseSwagger();
app.UseSwaggerUI(op =>
{
    // Remove schemas gen.
    op.DefaultModelsExpandDepth(-1);
    op.EnableTryItOutByDefault();
});

// Force Migration for production
if (app.Environment.IsProduction())
{
    var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

// Use CORS
app.UseCors("AllowAngularDev");

// Run the app
app.Run();