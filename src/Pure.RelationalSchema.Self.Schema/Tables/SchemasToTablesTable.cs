using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Self.Schema.Columns;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Self.Schema.Tables;

public sealed record SchemasToTablesTable : ITable
{
    public IString Name => new String("schemas_to_tables");

    public IEnumerable<IColumn> Columns =>
        [new GuidColumn(), new ReferenceToSchemaColumn(), new ReferenceToTableColumn()];

    public IEnumerable<IIndex> Indexes => [];
}
