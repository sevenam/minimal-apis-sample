using MinimalApisSample.Endpoints.StuffEndpoints;
using MinimalApisSample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AddStuffEndpoint>();
builder.Services.AddScoped<GetAllTheStuffEndpoint>();
builder.Services.AddScoped<DeleteStuffEndpoint>();
builder.Services.AddScoped<GetStuffByIdEndpoint>();
builder.Services.AddScoped<IStuffService, StuffService>();

var app = builder.Build();
app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
  scope.ServiceProvider.GetService<AddStuffEndpoint>()?.MapEndpoint(app);
  scope.ServiceProvider.GetService<GetAllTheStuffEndpoint>()?.MapEndpoint(app);
  scope.ServiceProvider.GetService<DeleteStuffEndpoint>()?.MapEndpoint(app);
  scope.ServiceProvider.GetService<GetStuffByIdEndpoint>()?.MapEndpoint(app);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");


app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}