using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.ForeignKeys;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.Tests.ForeignKeys;

public sealed record TablesToIndexesIndexesForeignKeyTests
{
    [Fact]
    public void ReferencingTableIsTablesToIndexesTable()
    {
        IForeignKey fk = new TablesToIndexesIndexesForeignKey();

        Assert.True(
            new TableHash(fk.ReferencingTable).SequenceEqual(
                new TableHash(new TablesToIndexesTable())
            )
        );
    }

    [Fact]
    public void ReferencedTableIsIndexesTable()
    {
        IForeignKey fk = new TablesToIndexesIndexesForeignKey();

        Assert.True(
            new TableHash(fk.ReferencedTable).SequenceEqual(
                new TableHash(new IndexesTable())
            )
        );
    }

    [Fact]
    public void ReferencingColumnsContainsReferenceToIndexColumn()
    {
        IForeignKey fk = new TablesToIndexesIndexesForeignKey();

        Assert.Contains(
            fk.ReferencingColumns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new ReferenceToIndexColumn())
                )
        );
    }

    [Fact]
    public void ReferencedColumnsContainsUuidColumn()
    {
        IForeignKey fk = new TablesToIndexesIndexesForeignKey();

        Assert.Contains(
            fk.ReferencedColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UuidColumn()))
        );
    }
}
