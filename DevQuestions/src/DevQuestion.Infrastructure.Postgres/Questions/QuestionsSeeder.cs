namespace DevQuestion.Infrastructure.Postgres.Questions;

public class QuestionsSeeder : ISeeder
{
    private readonly QuestionsReadDbContext _readDbContext;

    public QuestionsSeeder(QuestionsReadDbContext readDbContext)
    {
        _readDbContext = readDbContext;
    }

    public Task SeedAsync()
    {
        throw new NotImplementedException();
    }
}