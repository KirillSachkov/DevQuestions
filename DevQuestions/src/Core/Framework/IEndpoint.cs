using Microsoft.AspNetCore.Routing;

namespace Framework;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}