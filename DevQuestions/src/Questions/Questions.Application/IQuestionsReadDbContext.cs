using Questions.Domain;

namespace Questions.Application;

public interface IQuestionsReadDbContext
{
    IQueryable<Question> ReadQuestions { get; }
}