using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;
using Shared;
using Shared.Abstractions;
using Shared.Extensions;

namespace Questions.Application.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, Result<TResponse, Failure>>
    where TRequest : ICommand<Result<TResponse, Failure>>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<Result<TResponse, Failure>> Handle(
        TRequest request,
        RequestHandlerDelegate<Result<TResponse, Failure>> next,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationFailures = await Task.WhenAll(
            _validators.Select(validator => validator.ValidateAsync(context, cancellationToken)));

        var errors = validationFailures
            .Where(result => !result.IsValid)
            .ToList();

        if (errors.Count != 0)
        {
            return errors.ToErrors();
        }

        var response = await next();

        return response;
    }
}