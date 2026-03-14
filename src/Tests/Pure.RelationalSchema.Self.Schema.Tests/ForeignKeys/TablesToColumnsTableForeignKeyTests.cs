using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.ForeignKeys;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.Tests.ForeignKeys;

public sealed record TablesToColumnsTableForeignKeyTests
{
    [Fact]
    public void ReferencingTableIsTablesToColumnsTable()
    {
        IForeignKey fk = new TablesToColumnsTableForeignKey();

        Assert.True(
            new TableHash(fk.ReferencingTable).SequenceEqual(
                new TableHash(new TablesToColumnsTable())
            )
        );
    }

    [Fact]
    public void ReferencedTableIsTablesTable()
    {
        IForeignKey fk = new TablesToColumnsTableForeignKey();

        Assert.True(
            new TableHash(fk.ReferencedTable).SequenceEqual(
                new TableHash(new TablesTable())
            )
        );
    }

    [Fact]
    public void ReferencingColumnsContainsReferenceToTableColumn()
    {
        IForeignKey fk = new TablesToColumnsTableForeignKey();

        Assert.Contains(
            fk.ReferencingColumns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new ReferenceToTableColumn())
                )
        );
    }

    [Fact]
    public void ReferencedColumnsContainsUuidColumn()
    {
        IForeignKey fk = new TablesToColumnsTableForeignKey();

        Assert.Contains(
            fk.ReferencedColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UuidColumn()))
        );
    }
}
