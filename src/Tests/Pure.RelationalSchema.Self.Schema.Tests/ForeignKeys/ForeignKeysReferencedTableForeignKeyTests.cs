using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.ForeignKeys;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.Tests.ForeignKeys;

public sealed record ForeignKeysReferencedTableForeignKeyTests
{
    [Fact]
    public void ReferencingTableIsForeignKeysTable()
    {
        IForeignKey fk = new ForeignKeysReferencedTableForeignKey();

        Assert.True(
            new TableHash(fk.ReferencingTable).SequenceEqual(
                new TableHash(new ForeignKeysTable())
            )
        );
    }

    [Fact]
    public void ReferencedTableIsTablesTable()
    {
        IForeignKey fk = new ForeignKeysReferencedTableForeignKey();

        Assert.True(
            new TableHash(fk.ReferencedTable).SequenceEqual(
                new TableHash(new TablesTable())
            )
        );
    }

    [Fact]
    public void ReferencingColumnsContainsReferencedTableColumn()
    {
        IForeignKey fk = new ForeignKeysReferencedTableForeignKey();

        Assert.Contains(
            fk.ReferencingColumns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new ReferencedTableColumn())
                )
        );
    }

    [Fact]
    public void ReferencedColumnsContainsUuidColumn()
    {
        IForeignKey fk = new ForeignKeysReferencedTableForeignKey();

        Assert.Contains(
            fk.ReferencedColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UuidColumn()))
        );
    }
}
