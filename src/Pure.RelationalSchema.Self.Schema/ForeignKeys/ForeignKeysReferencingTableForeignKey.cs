using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Column;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.ForeignKeys;

public sealed record ForeignKeysReferencingTableForeignKey : IForeignKey
{
    public ITable ReferencingTable => new ForeignKeysTable();

    public IEnumerable<IColumn> ReferencingColumns => [new ReferencingTableColumn()];

    public ITable ReferencedTable => new TablesTable();

    public IEnumerable<IColumn> ReferencedColumns => [new RowDeterminedHashColumn()];
}
