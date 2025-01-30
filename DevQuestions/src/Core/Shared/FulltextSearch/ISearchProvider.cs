using CSharpFunctionalExtensions;

namespace Shared.FulltextSearch;

public interface ISearchProvider
{
    Task<List<Guid>> SearchAsync(string query);

    Task<UnitResult<Failure>> IndexQuestionAsync<TEntity>(TEntity entity, string indexName);
}