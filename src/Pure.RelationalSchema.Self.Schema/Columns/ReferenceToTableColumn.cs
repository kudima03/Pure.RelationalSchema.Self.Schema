using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.ColumnType;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Self.Schema.Columns;

public sealed record ReferenceToTableColumn : IColumn
{
    public IString Name => new String("table_hash");

    public IColumnType Type => new DeterminedHashColumnType();
}
