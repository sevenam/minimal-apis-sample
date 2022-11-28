using MinimalApisSample.Services;

namespace MinimalApisSample.Endpoints.StuffEndpoints
{
  public class DeleteStuffEndpoint : IEndpoint
  {
    private readonly IStuffService stuffService;

    public DeleteStuffEndpoint(IStuffService stuffService)
    {
      this.stuffService = stuffService;
    }

    public void MapEndpoint(WebApplication app)
    {
      app.MapDelete("/stuff/{id}", (Guid id) =>
      {
        return stuffService.RemoveStuff(id);
      });
    }
  }
}
