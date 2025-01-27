using DevQuestions.Domain.Questions;
using Microsoft.EntityFrameworkCore;

namespace DevQuestion.Infrastructure.Postgres;

public class QuestionsDbContext : DbContext
{
    public DbSet<Question> Questions { get; set; }
}