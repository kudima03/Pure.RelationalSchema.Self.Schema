using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.Indexes;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.Tests.Tables;

public sealed record TablesTableTests
{
    [Fact]
    public void NameIsTables()
    {
        ITable table = new TablesTable();

        Assert.Equal("tables", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsContainsUuidColumn()
    {
        ITable table = new TablesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UuidColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsNameColumn()
    {
        ITable table = new TablesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new NameColumn()))
        );
    }

    [Fact]
    public void ColumnsCountIs2()
    {
        ITable table = new TablesTable();

        Assert.Equal(2, table.Columns.Count());
    }

    [Fact]
    public void IndexesContainsUuidUniqueIndex()
    {
        ITable table = new TablesTable();

        Assert.Contains(
            table.Indexes,
            i => new IndexHash(i).SequenceEqual(new IndexHash(new UuidUniqueIndex()))
        );
    }

    [Fact]
    public void IndexesCountIs1()
    {
        ITable table = new TablesTable();

        _ = Assert.Single(table.Indexes);
    }
}
