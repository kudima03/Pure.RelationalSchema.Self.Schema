using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Bool;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Self.Schema.Columns;

namespace Pure.RelationalSchema.Self.Schema.Indexes;

public sealed record UuidUniqueIndex : IIndex
{
    public IBool IsUnique => new True();

    public IEnumerable<IColumn> Columns => [new UuidColumn()];
}
