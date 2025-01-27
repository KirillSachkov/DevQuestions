using DevQuestions.Application.FulltextSeatch;
using DevQuestions.Domain.Questions;

namespace DevQuestion.Infrastructure.ElasticSearch;

public class ElasticSearchProvider : ISearchProvider
{
    public Task<List<Guid>> SearchAsync(string query) => throw new NotImplementedException();
    public Task IndexQuesionAsync(Question question) => throw new NotImplementedException();
}