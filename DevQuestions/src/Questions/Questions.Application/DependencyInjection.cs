using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Questions.Application.Behaviors;
using Shared.Abstractions;

namespace Questions.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(c =>
        {
            c.RegisterServicesFromAssembly(assembly);

            c.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        // services.Scan(scan => scan.FromAssemblies(assembly)
        //     .AddClasses(classes => classes
        //         .AssignableToAny(typeof(ICommandHandler<,>), typeof(ICommandHandler<>)))
        //     .AsSelfWithInterfaces()
        //     .WithScopedLifetime());
        //
        // services.Scan(scan => scan.FromAssemblies(assembly)
        //     .AddClasses(classes => classes
        //         .AssignableToAny(typeof(IQueryHandler<,>)))
        //     .AsSelfWithInterfaces()
        //     .WithScopedLifetime());

        return services;
    }
}