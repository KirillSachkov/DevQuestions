using System.Data;

namespace Shared.Database;

public interface ITransactionManager
{
    Task<IDbTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
}