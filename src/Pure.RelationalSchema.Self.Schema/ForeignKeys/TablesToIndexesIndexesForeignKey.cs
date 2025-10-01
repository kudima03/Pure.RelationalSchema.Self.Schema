using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Column;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.ForeignKeys;

public sealed record TablesToIndexesIndexesForeignKey : IForeignKey
{
    public ITable ReferencingTable => new TablesToIndexesTable();

    public IEnumerable<IColumn> ReferencingColumns => [new ReferenceToIndexColumn()];

    public ITable ReferencedTable => new IndexesTable();

    public IEnumerable<IColumn> ReferencedColumns => [new RowDeterminedHashColumn()];
}
