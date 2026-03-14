using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.Indexes;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.Tests.Tables;

public sealed record ColumnsTableTests
{
    [Fact]
    public void NameIsColumns()
    {
        ITable table = new ColumnsTable();

        Assert.Equal("columns", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsContainsUuidColumn()
    {
        ITable table = new ColumnsTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UuidColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsNameColumn()
    {
        ITable table = new ColumnsTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new NameColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsReferenceToColumnTypeColumn()
    {
        ITable table = new ColumnsTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new ReferenceToColumnTypeColumn())
                )
        );
    }

    [Fact]
    public void ColumnsCountIs3()
    {
        ITable table = new ColumnsTable();

        Assert.Equal(3, table.Columns.Count());
    }

    [Fact]
    public void IndexesContainsUuidUniqueIndex()
    {
        ITable table = new ColumnsTable();

        Assert.Contains(
            table.Indexes,
            i => new IndexHash(i).SequenceEqual(new IndexHash(new UuidUniqueIndex()))
        );
    }

    [Fact]
    public void IndexesCountIs1()
    {
        ITable table = new ColumnsTable();

        _ = Assert.Single(table.Indexes);
    }
}
