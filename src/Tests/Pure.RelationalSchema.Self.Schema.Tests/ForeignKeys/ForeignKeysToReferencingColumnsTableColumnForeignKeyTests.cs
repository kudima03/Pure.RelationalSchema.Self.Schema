using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.ForeignKeys;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.Tests.ForeignKeys;

public sealed record ForeignKeysToReferencingColumnsTableColumnForeignKeyTests
{
    [Fact]
    public void ReferencingTableIsForeignKeysToReferencingColumnsTable()
    {
        IForeignKey fk = new ForeignKeysToReferencingColumnsTableColumnForeignKey();

        Assert.True(
            new TableHash(fk.ReferencingTable).SequenceEqual(
                new TableHash(new ForeignKeysToReferencingColumnsTable())
            )
        );
    }

    [Fact]
    public void ReferencedTableIsColumnsTable()
    {
        IForeignKey fk = new ForeignKeysToReferencingColumnsTableColumnForeignKey();

        Assert.True(
            new TableHash(fk.ReferencedTable).SequenceEqual(
                new TableHash(new ColumnsTable())
            )
        );
    }

    [Fact]
    public void ReferencingColumnsContainsReferenceToColumnColumn()
    {
        IForeignKey fk = new ForeignKeysToReferencingColumnsTableColumnForeignKey();

        Assert.Contains(
            fk.ReferencingColumns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new ReferenceToColumnColumn())
                )
        );
    }

    [Fact]
    public void ReferencedColumnsContainsUuidColumn()
    {
        IForeignKey fk = new ForeignKeysToReferencingColumnsTableColumnForeignKey();

        Assert.Contains(
            fk.ReferencedColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UuidColumn()))
        );
    }
}
