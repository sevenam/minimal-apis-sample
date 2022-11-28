using MinimalApisSample.Services;

namespace MinimalApisSample.Endpoints.StuffEndpoints
{
  public class GetAllTheStuffEndpoint : IEndpoint
  {
    private readonly IStuffService stuffService;

    public GetAllTheStuffEndpoint(IStuffService stuffService)
    {
      this.stuffService = stuffService;
    }

    public void MapEndpoint(WebApplication app)
    {
      app.MapGet("/stuff/", () =>
      {
        return stuffService.GetAllTheStuff();
      });
    }

  }
}
