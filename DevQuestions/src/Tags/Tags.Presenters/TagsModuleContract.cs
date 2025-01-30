using Shared.Abstractions;
using Tags.Contracts;
using Tags.Contracts.Dtos;
using Tags.Database;
using Tags.Features;

namespace Tags.Presenters;

public class TagsModuleContract : ITagsContract
{
    private readonly IQueryHandler<IReadOnlyList<TagDto>, GetByIds.GetByIdsQuery> _handler;
    private readonly TagsDbContext _tagsDbContext;

    public TagsModuleContract(
        IQueryHandler<IReadOnlyList<TagDto>, GetByIds.GetByIdsQuery> handler,
        TagsDbContext tagsDbContext)
    {
        _handler = handler;
        _tagsDbContext = tagsDbContext;
    }

    public async Task CreateTag(CreateTagDto dto)
    {
        await Create.Handler(dto, _tagsDbContext);
    }

    public async Task<IReadOnlyList<TagDto>> GetByIds(GetByIdsDto dto)
    {
        return await _handler.Handle(new GetByIds.GetByIdsQuery(dto));
    }
}