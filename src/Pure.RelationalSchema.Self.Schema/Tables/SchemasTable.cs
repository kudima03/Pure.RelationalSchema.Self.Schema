using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Self.Schema.Columns;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Self.Schema.Tables;

public sealed record SchemasTable : ITable
{
    public IString Name => new String("schemas");

    public IEnumerable<IColumn> Columns => [new NameColumn()];

    public IEnumerable<IIndex> Indexes => [];
}
