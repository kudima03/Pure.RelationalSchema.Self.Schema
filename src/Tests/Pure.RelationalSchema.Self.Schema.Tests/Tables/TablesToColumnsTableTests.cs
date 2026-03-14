using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.Tests.Tables;

public sealed record TablesToColumnsTableTests
{
    [Fact]
    public void NameIsTablesToColumns()
    {
        ITable table = new TablesToColumnsTable();

        Assert.Equal("tables_to_columns", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsContainsReferenceToColumnColumn()
    {
        ITable table = new TablesToColumnsTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new ReferenceToColumnColumn())
                )
        );
    }

    [Fact]
    public void ColumnsContainsReferenceToTableColumn()
    {
        ITable table = new TablesToColumnsTable();

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
        ITable table = new TablesToColumnsTable();

        Assert.Equal(2, table.Columns.Count());
    }

    [Fact]
    public void IndexesIsEmpty()
    {
        ITable table = new TablesToColumnsTable();

        Assert.Empty(table.Indexes);
    }
}
