using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Self.Schema.Columns;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Self.Schema.Tables;

public sealed record TablesToIndexesTable : ITable
{
    public IString Name => new String("tables_to_indexes");

    public IEnumerable<IColumn> Columns =>
        [new GuidColumn(), new ReferenceToIndexColumn(), new ReferenceToTableColumn()];

    public IEnumerable<IIndex> Indexes => [];
}
