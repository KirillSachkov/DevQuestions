using MediatR;

namespace Shared.Abstractions;

public interface IQuery<out TResponse> : IRequest<TResponse>;

public interface IQueryHandler<TResponse, in TQuery> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>;