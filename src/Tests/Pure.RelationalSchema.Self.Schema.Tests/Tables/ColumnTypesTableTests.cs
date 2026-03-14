using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.Indexes;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.Tests.Tables;

public sealed record ColumnTypesTableTests
{
    [Fact]
    public void NameIsColumnTypes()
    {
        ITable table = new ColumnTypesTable();

        Assert.Equal("column_types", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsContainsUuidColumn()
    {
        ITable table = new ColumnTypesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UuidColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsNameColumn()
    {
        ITable table = new ColumnTypesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new NameColumn()))
        );
    }

    [Fact]
    public void ColumnsCountIs2()
    {
        ITable table = new ColumnTypesTable();

        Assert.Equal(2, table.Columns.Count());
    }

    [Fact]
    public void IndexesContainsUuidUniqueIndex()
    {
        ITable table = new ColumnTypesTable();

        Assert.Contains(
            table.Indexes,
            i => new IndexHash(i).SequenceEqual(new IndexHash(new UuidUniqueIndex()))
        );
    }

    [Fact]
    public void IndexesCountIs1()
    {
        ITable table = new ColumnTypesTable();

        _ = Assert.Single(table.Indexes);
    }
}
