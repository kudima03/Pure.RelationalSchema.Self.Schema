using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Self.Schema.Columns;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Self.Schema.Tables;

public sealed record SchemasToForeignKeysTable : ITable
{
    public IString Name => new String("schemas_to_foreign_keys");

    public IEnumerable<IColumn> Columns =>
        [new ReferenceToSchemaColumn(), new ReferenceToForeignKeyColumn()];

    public IEnumerable<IIndex> Indexes => [];
}
