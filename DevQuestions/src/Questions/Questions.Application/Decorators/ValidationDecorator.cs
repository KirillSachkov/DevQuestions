using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Shared;
using Shared.Abstractions;
using Shared.Extensions;

namespace Questions.Application.Decorators;

public class Test2CommandHandler : ICommandHandler<Guid, Test2Command>
{
    public Task<Result<Guid, Failure>> Handle(Test2Command command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class TestCommandHandler : ICommandHandler<Guid, TestCommand>
{
    public Task<Result<Guid, Failure>> Handle(TestCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public record TestCommand : ITest, IMetrics;

public record Test2Command : ICommand;

public interface ITest : ICommand;
public interface IMetrics : ICommand;

public class MetricsDecorator<TResponse, TCommand> : ICommandHandler<TResponse, TCommand>
    where TCommand : IMetrics
{
    private readonly ICommandHandler<TResponse, TCommand> _inner;
    private readonly ILogger<MetricsDecorator<TResponse, TCommand>> _logger;

    public MetricsDecorator(ICommandHandler<TResponse, TCommand> inner, ILogger<MetricsDecorator<TResponse, TCommand>> logger)
    {
        _inner = inner;
        _logger = logger;
    }

    public async Task<Result<TResponse, Failure>> Handle(
        TCommand command,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Metrics");
        return await _inner.Handle(command, cancellationToken);
    }
}


public class TestDecorator<TResponse, TCommand> : ICommandHandler<TResponse, TCommand>
    where TCommand : ITest
{
    private readonly ICommandHandler<TResponse, TCommand> _inner;
    private readonly ILogger<TestDecorator<TResponse, TCommand>> _logger;

    public TestDecorator(ICommandHandler<TResponse, TCommand> inner, ILogger<TestDecorator<TResponse, TCommand>> logger)
    {
        _inner = inner;
        _logger = logger;
    }

    public async Task<Result<TResponse, Failure>> Handle(
        TCommand command,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("test");
        return await _inner.Handle(command, cancellationToken);
    }
}

public class ValidationDecorator<TResponse, TCommand> : ICommandHandler<TResponse, TCommand>
    where TCommand : ICommand
{
    private readonly ICommandHandler<TResponse, TCommand> _inner;
    private readonly IEnumerable<IValidator<TCommand>> _validators;

    public ValidationDecorator(
        ICommandHandler<TResponse, TCommand> inner,
        IEnumerable<IValidator<TCommand>> validators)
    {
        _inner = inner;
        _validators = validators;
    }

    public async Task<Result<TResponse, Failure>> Handle(
        TCommand command,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await _inner.Handle(command, cancellationToken);
        }

        var context = new ValidationContext<TCommand>(command);
        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .Where(f => f != null)
            .ToList();

        if (failures.Count > 0)
        {
            return failures.ToErrors();
        }

        return await _inner.Handle(command, cancellationToken);
    }
}