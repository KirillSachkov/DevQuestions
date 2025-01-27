using System.Data;

namespace DevQuestions.Application.Database;

public interface ISqlConnectionFactory
{
    IDbConnection Create();
}