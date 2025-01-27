using CSharpFunctionalExtensions;
using DevQuestions.Domain.Questions;
using Shared;

namespace DevQuestions.Application.FulltextSearch;

public interface ISearchProvider
{
    Task<List<Guid>> SearchAsync(string query);

    Task<UnitResult<Failure>> IndexQuesionAsync(Question question);
}