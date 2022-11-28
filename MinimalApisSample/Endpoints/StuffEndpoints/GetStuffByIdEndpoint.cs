using MinimalApisSample.Services;

namespace MinimalApisSample.Endpoints.StuffEndpoints
{
  public class GetStuffByIdEndpoint : IEndpoint
  {
    private readonly IStuffService stuffService;

    public GetStuffByIdEndpoint(IStuffService stuffService)
    {
      this.stuffService = stuffService;
    }

    public void MapEndpoint(WebApplication app)
    {
      app.MapGet("/stuff/{id}", (Guid id) =>
      {
        return stuffService.GetStuffById(id);
      });
    }

  }
}
