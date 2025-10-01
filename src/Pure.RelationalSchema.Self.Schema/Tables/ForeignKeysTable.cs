using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Self.Schema.Columns;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Self.Schema.Tables;

public sealed record ForeignKeysTable : ITable
{
    public IString Name => new String("foreign_keys");

    public IEnumerable<IColumn> Columns =>
        [new ReferencingTableColumn(), new ReferencedTableColumn()];

    public IEnumerable<IIndex> Indexes => [];
}
