using MinimalApisSample.Dtos;
using MinimalApisSample.Services;

namespace MinimalApisSample.Endpoints.StuffEndpoints
{
  public class AddStuffEndpoint : IEndpoint
  {
    private readonly IStuffService stuffService;

    public AddStuffEndpoint(IStuffService stuffService)
    {
      this.stuffService = stuffService;
    }

    public void MapEndpoint(WebApplication app)
    {
      app.MapPost("/stuff/", (Stuff stuff) =>
      {
        return stuffService.AddStuff(stuff);
      });
    }

  }
}
