using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Self.Schema.Columns;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Self.Schema.Tables;

public sealed record ForeignKeysToReferencingColumnsTable : ITable
{
    public IString Name => new String("foreign_keys_to_referencing_columns");

    public IEnumerable<IColumn> Columns =>
        [
            new GuidColumn(),
            new ReferenceToColumnColumn(),
            new ReferenceToForeignKeyColumn(),
        ];

    public IEnumerable<IIndex> Indexes => [];
}
