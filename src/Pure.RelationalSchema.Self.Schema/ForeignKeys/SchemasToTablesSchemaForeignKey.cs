using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Column;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.ForeignKeys;

public sealed record SchemasToTablesSchemaForeignKey : IForeignKey
{
    public ITable ReferencingTable => new SchemasToTablesTable();

    public IEnumerable<IColumn> ReferencingColumns => [new ReferenceToSchemaColumn()];

    public ITable ReferencedTable => new TablesTable();

    public IEnumerable<IColumn> ReferencedColumns => [new RowDeterminedHashColumn()];
}
