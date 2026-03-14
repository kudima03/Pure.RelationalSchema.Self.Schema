using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.ColumnType;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;

namespace Pure.RelationalSchema.Self.Schema.Tests.Columns;

public sealed record ReferencedTableColumnTests
{
    [Fact]
    public void NameIsReferencedTableUuid()
    {
        IColumn column = new ReferencedTableColumn();

        Assert.Equal("referenced_table_uuid", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsUuidColumnType()
    {
        IColumn column = new ReferencedTableColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new UuidColumnType())
            )
        );
    }
}
