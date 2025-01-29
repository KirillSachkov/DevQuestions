using DevQuestions.Domain.Questions;

namespace DevQuestions.Application.Questions;

public interface IQuestionsReadDbContext
{
    IQueryable<Question> ReadQuestions { get; }
}