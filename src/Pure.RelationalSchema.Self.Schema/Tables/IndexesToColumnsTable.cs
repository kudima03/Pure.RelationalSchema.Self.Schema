using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Self.Schema.Columns;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Self.Schema.Tables;

public sealed record IndexesToColumnsTable : ITable
{
    public IString Name => new String("indexes_to_columns");

    public IEnumerable<IColumn> Columns =>
        [new ReferenceToIndexColumn(), new ReferenceToColumnColumn()];

    public IEnumerable<IIndex> Indexes => [];
}
