using DevQuestions.Domain.Questions;

namespace DevQuestions.Application.FulltextSeatch;

public interface ISearchProvider
{
    Task<List<Guid>> SearchAsync(string query);

    Task IndexQuesionAsync(Question question);
}