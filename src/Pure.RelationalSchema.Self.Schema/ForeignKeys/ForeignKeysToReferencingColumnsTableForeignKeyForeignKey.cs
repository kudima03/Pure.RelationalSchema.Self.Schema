using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Column;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.ForeignKeys;

public sealed record ForeignKeysToReferencingColumnsTableForeignKeyForeignKey
    : IForeignKey
{
    public ITable ReferencingTable => new ForeignKeysToReferencingColumnsTable();

    public IEnumerable<IColumn> ReferencingColumns => [new ReferenceToForeignKeyColumn()];

    public ITable ReferencedTable => new ForeignKeysTable();

    public IEnumerable<IColumn> ReferencedColumns => [new RowDeterminedHashColumn()];
}
