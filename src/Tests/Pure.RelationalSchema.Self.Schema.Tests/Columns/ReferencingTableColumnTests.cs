using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.ColumnType;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;

namespace Pure.RelationalSchema.Self.Schema.Tests.Columns;

public sealed record ReferencingTableColumnTests
{
    [Fact]
    public void NameIsReferencingTableUuid()
    {
        IColumn column = new ReferencingTableColumn();

        Assert.Equal("referencing_table_uuid", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsUuidColumnType()
    {
        IColumn column = new ReferencingTableColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new UuidColumnType())
            )
        );
    }
}
