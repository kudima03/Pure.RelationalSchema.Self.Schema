using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.ForeignKeys;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.Tests.ForeignKeys;

public sealed record SchemasToTablesSchemaForeignKeyTests
{
    [Fact]
    public void ReferencingTableIsSchemasToTablesTable()
    {
        IForeignKey fk = new SchemasToTablesSchemaForeignKey();

        Assert.True(
            new TableHash(fk.ReferencingTable).SequenceEqual(
                new TableHash(new SchemasToTablesTable())
            )
        );
    }

    [Fact]
    public void ReferencedTableIsSchemasTable()
    {
        IForeignKey fk = new SchemasToTablesSchemaForeignKey();

        Assert.True(
            new TableHash(fk.ReferencedTable).SequenceEqual(
                new TableHash(new SchemasTable())
            )
        );
    }

    [Fact]
    public void ReferencingColumnsContainsReferenceToSchemaColumn()
    {
        IForeignKey fk = new SchemasToTablesSchemaForeignKey();

        Assert.Contains(
            fk.ReferencingColumns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new ReferenceToSchemaColumn())
                )
        );
    }

    [Fact]
    public void ReferencedColumnsContainsUuidColumn()
    {
        IForeignKey fk = new SchemasToTablesSchemaForeignKey();

        Assert.Contains(
            fk.ReferencedColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UuidColumn()))
        );
    }
}
