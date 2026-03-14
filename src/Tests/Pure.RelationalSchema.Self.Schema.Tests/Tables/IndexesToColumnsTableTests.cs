using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.Tests.Tables;

public sealed record IndexesToColumnsTableTests
{
    [Fact]
    public void NameIsIndexesToColumns()
    {
        ITable table = new IndexesToColumnsTable();

        Assert.Equal("indexes_to_columns", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsContainsReferenceToIndexColumn()
    {
        ITable table = new IndexesToColumnsTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new ReferenceToIndexColumn())
                )
        );
    }

    [Fact]
    public void ColumnsContainsReferenceToColumnColumn()
    {
        ITable table = new IndexesToColumnsTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new ReferenceToColumnColumn())
                )
        );
    }

    [Fact]
    public void ColumnsCountIs2()
    {
        ITable table = new IndexesToColumnsTable();

        Assert.Equal(2, table.Columns.Count());
    }

    [Fact]
    public void IndexesIsEmpty()
    {
        ITable table = new IndexesToColumnsTable();

        Assert.Empty(table.Indexes);
    }
}
