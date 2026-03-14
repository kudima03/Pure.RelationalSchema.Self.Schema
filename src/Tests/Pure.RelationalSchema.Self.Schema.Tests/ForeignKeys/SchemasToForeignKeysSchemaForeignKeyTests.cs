using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.ForeignKeys;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.Tests.ForeignKeys;

public sealed record SchemasToForeignKeysSchemaForeignKeyTests
{
    [Fact]
    public void ReferencingTableIsSchemasToForeignKeysTable()
    {
        IForeignKey fk = new SchemasToForeignKeysSchemaForeignKey();

        Assert.True(
            new TableHash(fk.ReferencingTable).SequenceEqual(
                new TableHash(new SchemasToForeignKeysTable())
            )
        );
    }

    [Fact]
    public void ReferencedTableIsSchemasTable()
    {
        IForeignKey fk = new SchemasToForeignKeysSchemaForeignKey();

        Assert.True(
            new TableHash(fk.ReferencedTable).SequenceEqual(
                new TableHash(new SchemasTable())
            )
        );
    }

    [Fact]
    public void ReferencingColumnsContainsReferenceToSchemaColumn()
    {
        IForeignKey fk = new SchemasToForeignKeysSchemaForeignKey();

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
        IForeignKey fk = new SchemasToForeignKeysSchemaForeignKey();

        Assert.Contains(
            fk.ReferencedColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UuidColumn()))
        );
    }
}
