using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.Tests.Tables;

public sealed record TablesToIndexesTableTests
{
    [Fact]
    public void NameIsTablesToIndexes()
    {
        ITable table = new TablesToIndexesTable();

        Assert.Equal("tables_to_indexes", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsContainsReferenceToIndexColumn()
    {
        ITable table = new TablesToIndexesTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new ReferenceToIndexColumn())
                )
        );
    }

    [Fact]
    public void ColumnsContainsReferenceToTableColumn()
    {
        ITable table = new TablesToIndexesTable();

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
        ITable table = new TablesToIndexesTable();

        Assert.Equal(2, table.Columns.Count());
    }

    [Fact]
    public void IndexesIsEmpty()
    {
        ITable table = new TablesToIndexesTable();

        Assert.Empty(table.Indexes);
    }
}
