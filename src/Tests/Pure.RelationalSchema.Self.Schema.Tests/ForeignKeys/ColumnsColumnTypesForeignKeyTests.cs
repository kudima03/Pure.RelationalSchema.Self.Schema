using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.ForeignKeys;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.Tests.ForeignKeys;

public sealed record ColumnsColumnTypesForeignKeyTests
{
    [Fact]
    public void ReferencingTableIsColumnsTable()
    {
        IForeignKey fk = new ColumnsColumnTypesForeignKey();

        Assert.True(
            new TableHash(fk.ReferencingTable).SequenceEqual(
                new TableHash(new ColumnsTable())
            )
        );
    }

    [Fact]
    public void ReferencedTableIsColumnTypesTable()
    {
        IForeignKey fk = new ColumnsColumnTypesForeignKey();

        Assert.True(
            new TableHash(fk.ReferencedTable).SequenceEqual(
                new TableHash(new ColumnTypesTable())
            )
        );
    }

    [Fact]
    public void ReferencingColumnsContainsReferenceToColumnTypeColumn()
    {
        IForeignKey fk = new ColumnsColumnTypesForeignKey();

        Assert.Contains(
            fk.ReferencingColumns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new ReferenceToColumnTypeColumn())
                )
        );
    }

    [Fact]
    public void ReferencedColumnsContainsUuidColumn()
    {
        IForeignKey fk = new ColumnsColumnTypesForeignKey();

        Assert.Contains(
            fk.ReferencedColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UuidColumn()))
        );
    }
}
