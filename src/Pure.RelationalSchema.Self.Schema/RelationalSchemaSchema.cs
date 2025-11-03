using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Self.Schema.ForeignKeys;
using Pure.RelationalSchema.Self.Schema.Tables;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Self.Schema;

public sealed record RelationalSchemaSchema : ISchema
{
    public IString Name => new String("schemas");

    public IEnumerable<ITable> Tables =>
        [
            new ColumnTypesTable(),
            new ColumnsTable(),
            new IndexesTable(),
            new TablesTable(),
            new ForeignKeysTable(),
            new SchemasTable(),
            new TablesToColumnsTable(),
            new TablesToIndexesTable(),
            new IndexesToColumnsTable(),
            new ForeignKeysToReferencingColumnsTable(),
            new ForeignKeysToReferencedColumnsTable(),
            new SchemasToTablesTable(),
            new SchemasToForeignKeysTable(),
        ];

    public IEnumerable<IForeignKey> ForeignKeys =>
        [
            new ColumnsColumnTypesForeignKey(),
            new TablesToColumnsTableForeignKey(),
            new TablesToColumnsColumnForeignKey(),
            new TablesToIndexesIndexesForeignKey(),
            new TablesToIndexesTableForeignKey(),
            new IndexesToColumnsColumnForeignKey(),
            new IndexesToColumnsIndexForeignKey(),
            new ForeignKeysReferencingTableForeignKey(),
            new ForeignKeysReferencedTableForeignKey(),
            new ForeignKeysToReferencingColumnsTableColumnForeignKey(),
            new ForeignKeysToReferencedColumnsTableColumnForeignKey(),
            new ForeignKeysToReferencingColumnsTableForeignKeyForeignKey(),
            new ForeignKeysToReferencedColumnsTableForeignKeyForeignKey(),
            new SchemasToTablesTableForeignKey(),
            new SchemasToTablesSchemaForeignKey(),
            new SchemasToForeignKeysForeignKeyForeignKey(),
            new SchemasToForeignKeysSchemaForeignKey(),
        ];
}
