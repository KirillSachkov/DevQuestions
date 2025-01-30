using Infrastructure.S3;
using Microsoft.Extensions.DependencyInjection;
using Questions.Application;
using Questions.Infrastructure.Postgres;
using Shared.FilesStorage;

namespace Questions.Presenters;

public static class DependencyInjection
{
    public static IServiceCollection AddQuestionsModule(this IServiceCollection services)
    {
        services.AddApplication();
        services.AddInfrastructure();

        services.AddScoped<IFilesProvider, S3Provider>();
        services.AddScoped<IQuestionsReadDbContext, QuestionsDbContext>();

        return services;
    }
}