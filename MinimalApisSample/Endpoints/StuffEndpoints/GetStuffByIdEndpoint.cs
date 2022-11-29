﻿using MinimalApisSample.Services;

namespace MinimalApisSample.Endpoints.StuffEndpoints
{
  public class GetStuffByIdEndpoint : IEndpoint
  {
    public void MapEndpoint(WebApplication app)
    {
      app.MapGet("/stuff/{id}", (Guid id, IStuffService stuffService) =>
      {
        return stuffService.GetStuffById(id);
      });
    }

  }
}
