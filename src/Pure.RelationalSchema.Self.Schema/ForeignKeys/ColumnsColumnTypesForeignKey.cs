using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Column;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.ForeignKeys;

public sealed record ColumnsColumnTypesForeignKey : IForeignKey
{
    public ITable ReferencingTable => new ColumnsTable();

    public IEnumerable<IColumn> ReferencingColumns => [new ReferenceToColumnTypeColumn()];

    public ITable ReferencedTable => new ColumnTypesTable();

    public IEnumerable<IColumn> ReferencedColumns => [new RowDeterminedHashColumn()];
}
