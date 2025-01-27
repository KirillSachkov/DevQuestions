using System.Data;
using DevQuestions.Application.Database;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DevQuestion.Infrastructure.Postgres;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly IConfiguration _configuration;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection Create()
    {
        var connection = new NpgsqlConnection(_configuration.GetConnectionString("Database"));

        return connection;
    }
}