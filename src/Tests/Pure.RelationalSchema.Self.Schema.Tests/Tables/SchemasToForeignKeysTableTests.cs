using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.Tests.Tables;

public sealed record SchemasToForeignKeysTableTests
{
    [Fact]
    public void NameIsSchemasToForeignKeys()
    {
        ITable table = new SchemasToForeignKeysTable();

        Assert.Equal("schemas_to_foreign_keys", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsContainsReferenceToSchemaColumn()
    {
        ITable table = new SchemasToForeignKeysTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new ReferenceToSchemaColumn())
                )
        );
    }

    [Fact]
    public void ColumnsContainsReferenceToForeignKeyColumn()
    {
        ITable table = new SchemasToForeignKeysTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new ReferenceToForeignKeyColumn())
                )
        );
    }

    [Fact]
    public void ColumnsCountIs2()
    {
        ITable table = new SchemasToForeignKeysTable();

        Assert.Equal(2, table.Columns.Count());
    }

    [Fact]
    public void IndexesIsEmpty()
    {
        ITable table = new SchemasToForeignKeysTable();

        Assert.Empty(table.Indexes);
    }
}
