using System.Data;
using Npgsql;
using Testcontainers.PostgreSql;

namespace Pure.RelationalSchema.Self.Schema.Tests;

public sealed record DatabaseFixture : IDisposable
{
    public IDbConnection Connection { get; }

    public PostgreSqlContainer Postgres { get; }

    public DatabaseFixture()
    {
        Postgres = new PostgreSqlBuilder()
            .WithDatabase("testdb")
            .WithUsername("postgres")
            .WithPassword("postgres")
            .Build();

        Postgres.StartAsync().GetAwaiter().GetResult();

        Connection = new NpgsqlConnection(Postgres.GetConnectionString());
        Connection.Open();
    }

    public void Dispose()
    {
        Connection.Dispose();
        Postgres.DisposeAsync().AsTask().GetAwaiter().GetResult();
    }
}
