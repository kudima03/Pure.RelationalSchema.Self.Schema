using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.Tests.Tables;

public sealed record ForeignKeysToReferencingColumnsTableTests
{
    [Fact]
    public void NameIsForeignKeysToReferencingColumns()
    {
        ITable table = new ForeignKeysToReferencingColumnsTable();

        Assert.Equal("foreign_keys_to_referencing_columns", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsContainsReferenceToColumnColumn()
    {
        ITable table = new ForeignKeysToReferencingColumnsTable();

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
        ITable table = new ForeignKeysToReferencingColumnsTable();

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
        ITable table = new ForeignKeysToReferencingColumnsTable();

        Assert.Equal(2, table.Columns.Count());
    }

    [Fact]
    public void IndexesIsEmpty()
    {
        ITable table = new ForeignKeysToReferencingColumnsTable();

        Assert.Empty(table.Indexes);
    }
}
