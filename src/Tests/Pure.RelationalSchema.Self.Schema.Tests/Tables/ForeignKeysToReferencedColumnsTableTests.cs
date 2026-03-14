using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.Tests.Tables;

public sealed record ForeignKeysToReferencedColumnsTableTests
{
    [Fact]
    public void NameIsForeignKeysToReferencedColumns()
    {
        ITable table = new ForeignKeysToReferencedColumnsTable();

        Assert.Equal("foreign_keys_to_referenced_columns", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsContainsReferenceToColumnColumn()
    {
        ITable table = new ForeignKeysToReferencedColumnsTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new ReferenceToColumnColumn())
                )
        );
    }

    [Fact]
    public void ColumnsContainsReferenceToForeignKeyColumn()
    {
        ITable table = new ForeignKeysToReferencedColumnsTable();

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
        ITable table = new ForeignKeysToReferencedColumnsTable();

        Assert.Equal(2, table.Columns.Count());
    }

    [Fact]
    public void IndexesIsEmpty()
    {
        ITable table = new ForeignKeysToReferencedColumnsTable();

        Assert.Empty(table.Indexes);
    }
}
