using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.ForeignKeys;
using Pure.RelationalSchema.Self.Schema.Tables;
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
    public void NameIsSchemas()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Equal("schemas", schema.Name.TextValue);
    }

    [Fact]
    public void TablesContains13Tables()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Equal(13, schema.Tables.Count());
    }

    [Fact]
    public void ForeignKeysContains17ForeignKeys()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Equal(17, schema.ForeignKeys.Count());
    }

    [Fact]
    public void TablesContainsColumnTypesTable()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new ColumnTypesTable()))
        );
    }

    [Fact]
    public void TablesContainsColumnsTable()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new ColumnsTable()))
        );
    }

    [Fact]
    public void TablesContainsIndexesTable()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new IndexesTable()))
        );
    }

    [Fact]
    public void TablesContainsTablesTable()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new TablesTable()))
        );
    }

    [Fact]
    public void TablesContainsForeignKeysTable()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new ForeignKeysTable()))
        );
    }

    [Fact]
    public void TablesContainsSchemasTable()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new SchemasTable()))
        );
    }

    [Fact]
    public void TablesContainsTablesToColumnsTable()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new TablesToColumnsTable()))
        );
    }

    [Fact]
    public void TablesContainsTablesToIndexesTable()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new TablesToIndexesTable()))
        );
    }

    [Fact]
    public void TablesContainsIndexesToColumnsTable()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.Tables,
            t =>
                new TableHash(t).SequenceEqual(new TableHash(new IndexesToColumnsTable()))
        );
    }

    [Fact]
    public void TablesContainsForeignKeysToReferencingColumnsTable()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.Tables,
            t =>
                new TableHash(t).SequenceEqual(
                    new TableHash(new ForeignKeysToReferencingColumnsTable())
                )
        );
    }

    [Fact]
    public void TablesContainsForeignKeysToReferencedColumnsTable()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.Tables,
            t =>
                new TableHash(t).SequenceEqual(
                    new TableHash(new ForeignKeysToReferencedColumnsTable())
                )
        );
    }

    [Fact]
    public void TablesContainsSchemasToTablesTable()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new SchemasToTablesTable()))
        );
    }

    [Fact]
    public void TablesContainsSchemasToForeignKeysTable()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.Tables,
            t =>
                new TableHash(t).SequenceEqual(
                    new TableHash(new SchemasToForeignKeysTable())
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsColumnsColumnTypesForeignKey()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.ForeignKeys,
            fk =>
                new ForeignKeyHash(fk).SequenceEqual(
                    new ForeignKeyHash(new ColumnsColumnTypesForeignKey())
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsTablesToColumnsTableForeignKey()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.ForeignKeys,
            fk =>
                new ForeignKeyHash(fk).SequenceEqual(
                    new ForeignKeyHash(new TablesToColumnsTableForeignKey())
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsTablesToColumnsColumnForeignKey()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.ForeignKeys,
            fk =>
                new ForeignKeyHash(fk).SequenceEqual(
                    new ForeignKeyHash(new TablesToColumnsColumnForeignKey())
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsTablesToIndexesTableForeignKey()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.ForeignKeys,
            fk =>
                new ForeignKeyHash(fk).SequenceEqual(
                    new ForeignKeyHash(new TablesToIndexesTableForeignKey())
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsTablesToIndexesIndexesForeignKey()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.ForeignKeys,
            fk =>
                new ForeignKeyHash(fk).SequenceEqual(
                    new ForeignKeyHash(new TablesToIndexesIndexesForeignKey())
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsIndexesToColumnsIndexForeignKey()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.ForeignKeys,
            fk =>
                new ForeignKeyHash(fk).SequenceEqual(
                    new ForeignKeyHash(new IndexesToColumnsIndexForeignKey())
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsIndexesToColumnsColumnForeignKey()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.ForeignKeys,
            fk =>
                new ForeignKeyHash(fk).SequenceEqual(
                    new ForeignKeyHash(new IndexesToColumnsColumnForeignKey())
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsForeignKeysReferencingTableForeignKey()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.ForeignKeys,
            fk =>
                new ForeignKeyHash(fk).SequenceEqual(
                    new ForeignKeyHash(new ForeignKeysReferencingTableForeignKey())
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsForeignKeysReferencedTableForeignKey()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.ForeignKeys,
            fk =>
                new ForeignKeyHash(fk).SequenceEqual(
                    new ForeignKeyHash(new ForeignKeysReferencedTableForeignKey())
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsForeignKeysToReferencingColumnsTableColumnForeignKey()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.ForeignKeys,
            fk =>
                new ForeignKeyHash(fk).SequenceEqual(
                    new ForeignKeyHash(
                        new ForeignKeysToReferencingColumnsTableColumnForeignKey()
                    )
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsForeignKeysToReferencedColumnsTableColumnForeignKey()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.ForeignKeys,
            fk =>
                new ForeignKeyHash(fk).SequenceEqual(
                    new ForeignKeyHash(
                        new ForeignKeysToReferencedColumnsTableColumnForeignKey()
                    )
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsForeignKeysToReferencingColumnsTableForeignKeyForeignKey()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.ForeignKeys,
            fk =>
                new ForeignKeyHash(fk).SequenceEqual(
                    new ForeignKeyHash(
                        new ForeignKeysToReferencingColumnsTableForeignKeyForeignKey()
                    )
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsForeignKeysToReferencedColumnsTableForeignKeyForeignKey()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.ForeignKeys,
            fk =>
                new ForeignKeyHash(fk).SequenceEqual(
                    new ForeignKeyHash(
                        new ForeignKeysToReferencedColumnsTableForeignKeyForeignKey()
                    )
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsSchemasToTablesTableForeignKey()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.ForeignKeys,
            fk =>
                new ForeignKeyHash(fk).SequenceEqual(
                    new ForeignKeyHash(new SchemasToTablesTableForeignKey())
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsSchemasToTablesSchemaForeignKey()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.ForeignKeys,
            fk =>
                new ForeignKeyHash(fk).SequenceEqual(
                    new ForeignKeyHash(new SchemasToTablesSchemaForeignKey())
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsSchemasToForeignKeysForeignKeyForeignKey()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.ForeignKeys,
            fk =>
                new ForeignKeyHash(fk).SequenceEqual(
                    new ForeignKeyHash(new SchemasToForeignKeysForeignKeyForeignKey())
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsSchemasToForeignKeysSchemaForeignKey()
    {
        ISchema schema = new RelationalSchemaSchema();

        Assert.Contains(
            schema.ForeignKeys,
            fk =>
                new ForeignKeyHash(fk).SequenceEqual(
                    new ForeignKeyHash(new SchemasToForeignKeysSchemaForeignKey())
                )
        );
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
