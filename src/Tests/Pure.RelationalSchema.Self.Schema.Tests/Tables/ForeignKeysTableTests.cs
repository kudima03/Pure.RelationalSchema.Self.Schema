using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.Indexes;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.Tests.Tables;

public sealed record ForeignKeysTableTests
{
    [Fact]
    public void NameIsForeignKeys()
    {
        ITable table = new ForeignKeysTable();

        Assert.Equal("foreign_keys", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsContainsUuidColumn()
    {
        ITable table = new ForeignKeysTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UuidColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsReferencingTableColumn()
    {
        ITable table = new ForeignKeysTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new ReferencingTableColumn())
                )
        );
    }

    [Fact]
    public void ColumnsContainsReferencedTableColumn()
    {
        ITable table = new ForeignKeysTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new ReferencedTableColumn())
                )
        );
    }

    [Fact]
    public void ColumnsCountIs3()
    {
        ITable table = new ForeignKeysTable();

        Assert.Equal(3, table.Columns.Count());
    }

    [Fact]
    public void IndexesContainsUuidUniqueIndex()
    {
        ITable table = new ForeignKeysTable();

        Assert.Contains(
            table.Indexes,
            i => new IndexHash(i).SequenceEqual(new IndexHash(new UuidUniqueIndex()))
        );
    }

    [Fact]
    public void IndexesCountIs1()
    {
        ITable table = new ForeignKeysTable();

        _ = Assert.Single(table.Indexes);
    }
}
