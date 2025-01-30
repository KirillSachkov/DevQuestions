using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Questions.Application;
using Questions.Application.Fails;
using Questions.Application.Features.GetQuestionsWithFiltersQuery;
using Questions.Domain;
using Shared;

namespace Questions.Infrastructure.Postgres;

public class QuestionsEfCoreRepository : IQuestionsRepository
{
    private readonly QuestionsDbContext _dbContext;

    public QuestionsEfCoreRepository(QuestionsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> AddAsync(Question question, CancellationToken cancellationToken)
    {
        await _dbContext.Questions.AddAsync(question, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return question.Id;
    }

    public async Task<Guid> SaveAsync(Question question, CancellationToken cancellationToken)
    {
        _dbContext.Questions.Attach(question);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return question.Id;
    }

    public Task<Guid> DeleteAsync(Guid questionId, CancellationToken cancellationToken) => throw new NotImplementedException();

    public async Task<Result<Question, Failure>> GetByIdAsync(Guid questionId, CancellationToken cancellationToken)
    {
        var question = await _dbContext.Questions
            .Include(q => q.Answers)
            .Include(q => q.Solution)
            .FirstOrDefaultAsync(q => q.Id == questionId, cancellationToken);

        if (question is null)
        {
            return Errors.General.NotFound(questionId).ToFailure();
        }

        return question;
    }

    public Task<(IReadOnlyList<Question> Questions, long Count)> GetQuestionsWithFiltersAsync(GetQuestionsWithFiltersQuery query,
        CancellationToken cancellationToken) => throw new NotImplementedException();

    public Task<int> GetOpenUserQuestionsAsync(Guid userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}