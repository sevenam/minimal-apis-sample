using MinimalApisSample.Dtos;
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
builder.Services.AddSingleton<IStuffService, StuffService>();

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

// Standard minimal apis:
app.MapPost("/stuffystuff/", (Stuff stuff, IStuffService stuffService) => { return stuffService.AddStuff(stuff); });
app.MapGet("/stuffystuff/{id}", (Guid id, IStuffService stuffService) => { return stuffService.GetStuffById(id); });
app.MapDelete("/stuffystuff/{id}", (Guid id, IStuffService stuffService) => { return stuffService.RemoveStuff(id); });
app.MapGet("/stuffystuff/", (IStuffService stuffService) => { return stuffService.GetAllTheStuff(); });

app.Run();
