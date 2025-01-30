using Framework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Tags.Contracts.Dtos;
using Tags.Database;
using Tags.Domain;

namespace Tags.Features;

public sealed class Create
{
    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("tags", Handler);
        }
    }

    public static async Task<IResult> Handler(
        CreateTagDto dto,
        TagsDbContext tagsDbContext)
    {
        var tag = new Tag
        {
            Name = dto.Name,
        };

        await tagsDbContext.AddAsync(tag);

        return Results.Ok(tag.Id);
    }
}