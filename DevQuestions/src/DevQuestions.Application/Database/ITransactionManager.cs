using System.Data;

namespace DevQuestions.Application.Database;

public interface ITransactionManager
{
    Task<IDbTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
}