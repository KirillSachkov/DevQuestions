namespace DevQuestion.Infrastructure.Postgres;

public interface ISeeder
{
    Task SeedAsync();
}