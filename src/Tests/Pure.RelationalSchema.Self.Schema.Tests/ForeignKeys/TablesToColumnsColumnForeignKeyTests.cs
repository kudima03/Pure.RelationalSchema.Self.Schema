using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.ForeignKeys;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.Tests.ForeignKeys;

public sealed record TablesToColumnsColumnForeignKeyTests
{
    [Fact]
    public void ReferencingTableIsTablesToColumnsTable()
    {
        IForeignKey fk = new TablesToColumnsColumnForeignKey();

        Assert.True(
            new TableHash(fk.ReferencingTable).SequenceEqual(
                new TableHash(new TablesToColumnsTable())
            )
        );
    }

    [Fact]
    public void ReferencedTableIsColumnsTable()
    {
        IForeignKey fk = new TablesToColumnsColumnForeignKey();

        Assert.True(
            new TableHash(fk.ReferencedTable).SequenceEqual(
                new TableHash(new ColumnsTable())
            )
        );
    }

    [Fact]
    public void ReferencingColumnsContainsReferenceToColumnColumn()
    {
        IForeignKey fk = new TablesToColumnsColumnForeignKey();

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
        IForeignKey fk = new TablesToColumnsColumnForeignKey();

        Assert.Contains(
            fk.ReferencedColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UuidColumn()))
        );
    }
}
