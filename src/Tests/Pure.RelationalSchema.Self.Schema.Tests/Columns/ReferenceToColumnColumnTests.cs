using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.ColumnType;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;

namespace Pure.RelationalSchema.Self.Schema.Tests.Columns;

public sealed record ReferenceToColumnColumnTests
{
    [Fact]
    public void NameIsColumnUuid()
    {
        IColumn column = new ReferenceToColumnColumn();

        Assert.Equal("column_uuid", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsUuidColumnType()
    {
        IColumn column = new ReferenceToColumnColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new UuidColumnType())
            )
        );
    }
}
