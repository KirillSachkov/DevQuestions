using DevQuestion.Infrastructure.Postgres.Repositories;
using DevQuestions.Application.Database;
using DevQuestions.Application.Questions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DevQuestion.Infrastructure.Postgres;

public static class DependencyInjection
{
    public static IServiceCollection AddPostgresInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<QuestionsDbContext>();

        services.AddScoped<IQuestionsRepository, QuestionsEfCoreRepository>();

        return services;
    }
}