using DevQuestions.Application.Questions;
using DevQuestions.Domain.Questions;
using Microsoft.EntityFrameworkCore;

namespace DevQuestion.Infrastructure.Postgres.Questions;

public class QuestionsReadDbContext : DbContext, IQuestionsReadDbContext
{
    public DbSet<Question> Questions { get; set; }

    public IQueryable<Question> ReadQuestions => Questions.AsNoTracking().AsQueryable();
}