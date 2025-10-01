using Pure.RelationalSchema.Storage.PostgreSQL;

namespace Pure.RelationalSchema.Self.Schema.Tests;

public sealed record RelationalSchemaSchemaTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;

    public RelationalSchemaSchemaTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Migrate()
    {
        PostgreSqlCreatedSchema createdSchema = new PostgreSqlCreatedSchema(
            new RelationalSchemaSchema(),
            _fixture.Connection
        );
        _ = createdSchema.Name;
    }
}
