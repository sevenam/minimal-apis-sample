using Microsoft.AspNetCore.Mvc;
using MinimalApisSample.Dtos;
using MinimalApisSample.Services;

namespace MinimalApisSample.Endpoints.StuffEndpoints
{
  public class AddStuffEndpoint : IEndpoint
  {
    public void MapEndpoint(WebApplication app)
    {
      app.MapPost("/stuff/", ([FromBody] Stuff stuff, [FromServices] IStuffService stuffService) =>
      {
        return stuffService.AddStuff(stuff);
      });
    }

  }
}
