using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Column;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.Tables;

namespace Pure.RelationalSchema.Self.Schema.ForeignKeys;

public sealed record AdaptersToSchemasAdapterForeignKey : IForeignKey
{
    public ITable ReferencingTable => new AdaptersToSchemasTable();

    public IEnumerable<IColumn> ReferencingColumns => [new ReferenceToAdapterColumn()];

    public ITable ReferencedTable => new AdaptersTable();

    public IEnumerable<IColumn> ReferencedColumns => [new RowDeterminedHashColumn()];
}
