using Polly;

var builder = WebApplication.CreateBuilder(args);

// Configure the Polly and the Circuit-Breaker Policy

var productApiEndpointAddress = new
    Uri("http://localhost:14552");

builder.Services.AddHttpClient("ProductApi", c =>
{
    c.BaseAddress = productApiEndpointAddress;
})
.AddTransientHttpErrorPolicy(p => p.
CircuitBreakerAsync(2, TimeSpan.FromMinutes(1)));

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
