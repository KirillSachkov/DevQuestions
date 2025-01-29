using CSharpFunctionalExtensions;
using Shared;

namespace DevQuestions.Application.Communication;

public interface IUsersCommunicationService
{
    Task<Result<long, Failure>> GetUserRatingAsync(Guid userId, CancellationToken cancellationToken = default);
}