using Microsoft.Extensions.DependencyInjection;
using Questions.Application;

namespace Questions.Infrastructure.Postgres;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<QuestionsDbContext>();

        services.AddScoped<IQuestionsRepository, QuestionsEfCoreRepository>();

        return services;
    }
}