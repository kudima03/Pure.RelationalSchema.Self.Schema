using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.ForeignKeys;

public sealed record IndexesToColumnsIndexForeignKey : IForeignKey
{
    public ITable ReferencingTable => new IndexesToColumnsTable();

    public IEnumerable<IColumn> ReferencingColumns => [new ReferenceToIndexColumn()];

    public ITable ReferencedTable => new IndexesTable();

    public IEnumerable<IColumn> ReferencedColumns => [new UuidColumn()];
}
