using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.Tests.Tables;

public sealed record SchemasToTablesTableTests
{
    [Fact]
    public void NameIsSchemasToTables()
    {
        ITable table = new SchemasToTablesTable();

        Assert.Equal("schemas_to_tables", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsContainsReferenceToSchemaColumn()
    {
        ITable table = new SchemasToTablesTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new ReferenceToSchemaColumn())
                )
        );
    }

    [Fact]
    public void ColumnsContainsReferenceToTableColumn()
    {
        ITable table = new SchemasToTablesTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new ReferenceToTableColumn())
                )
        );
    }

    [Fact]
    public void ColumnsCountIs2()
    {
        ITable table = new SchemasToTablesTable();

        Assert.Equal(2, table.Columns.Count());
    }

    [Fact]
    public void IndexesIsEmpty()
    {
        ITable table = new SchemasToTablesTable();

        Assert.Empty(table.Indexes);
    }
}
