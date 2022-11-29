using MinimalApisSample.Services;

namespace MinimalApisSample.Endpoints.StuffEndpoints
{
  public class GetAllTheStuffEndpoint : IEndpoint
  {
    public void MapEndpoint(WebApplication app)
    {
      app.MapGet("/stuff/", (IStuffService stuffService) =>
      {
        return stuffService.GetAllTheStuff();
      }).WithOpenApi(op => new(op) { Summary = "Stuff.GetAll" });
    }

  }
}
