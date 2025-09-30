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
            new TablesTable(),
            new TablesToColumnsTable(),
            new ColumnsTable(),
            new ColumnTypesTable(),
            new TablesToIndexesTable(),
            new IndexesTable(),
            new ForeignKeysToReferencingColumnsTable(),
            new ForeignKeysToReferencedColumnsTable(),
            new ForeignKeysTable(),
            new AdaptersToSchemasTable(),
            new AdaptersTable(),
            new SchemasToTablesTable(),
            new SchemasTable(),
        ];

    public IEnumerable<IForeignKey> ForeignKeys =>
        [
            new ColumnsColumnTypesForeignKey(),
            new TablesToColumnsTableForeignKey(),
            new TablesToColumnsColumnForeignKey(),
            new TablesToIndexesIndexesForeignKey(),
            new TablesToIndexesTableForeignKey(),
            new ForeignKeysReferencingTableForeignKey(),
            new ForeignKeysReferencedTableForeignKey(),
            new ForeignKeysToReferencingColumnsTableColumnForeignKey(),
            new ForeignKeysToReferencedColumnsTableColumnForeignKey(),
            new ForeignKeysToReferencingColumnsTableForeignKeyForeignKey(),
            new ForeignKeysToReferencedColumnsTableForeignKeyForeignKey(),
            new SchemasToTablesTableForeignKey(),
            new SchemasToTablesSchemaForeignKey(),
            new AdaptersToSchemasSchemaForeignKey(),
            new AdaptersToSchemasAdapterForeignKey(),
        ];
}
