using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.ForeignKeys;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.Tests.ForeignKeys;

public sealed record ForeignKeysToReferencedColumnsTableForeignKeyForeignKeyTests
{
    [Fact]
    public void ReferencingTableIsForeignKeysToReferencedColumnsTable()
    {
        IForeignKey fk = new ForeignKeysToReferencedColumnsTableForeignKeyForeignKey();

        Assert.True(
            new TableHash(fk.ReferencingTable).SequenceEqual(
                new TableHash(new ForeignKeysToReferencedColumnsTable())
            )
        );
    }

    [Fact]
    public void ReferencedTableIsForeignKeysTable()
    {
        IForeignKey fk = new ForeignKeysToReferencedColumnsTableForeignKeyForeignKey();

        Assert.True(
            new TableHash(fk.ReferencedTable).SequenceEqual(
                new TableHash(new ForeignKeysTable())
            )
        );
    }

    [Fact]
    public void ReferencingColumnsContainsReferenceToForeignKeyColumn()
    {
        IForeignKey fk = new ForeignKeysToReferencedColumnsTableForeignKeyForeignKey();

        Assert.Contains(
            fk.ReferencingColumns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new ReferenceToForeignKeyColumn())
                )
        );
    }

    [Fact]
    public void ReferencedColumnsContainsUuidColumn()
    {
        IForeignKey fk = new ForeignKeysToReferencedColumnsTableForeignKeyForeignKey();

        Assert.Contains(
            fk.ReferencedColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UuidColumn()))
        );
    }
}
