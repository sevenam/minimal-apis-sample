using MinimalApisSample.Services;

namespace MinimalApisSample.Endpoints.StuffEndpoints
{
  public class DeleteStuffEndpoint : IEndpoint
  {
    public void MapEndpoint(WebApplication app)
    {
      app.MapDelete("/stuff/{id}", (Guid id, IStuffService stuffService) =>
      {
        return stuffService.RemoveStuff(id);
      });
    }
  }
}
