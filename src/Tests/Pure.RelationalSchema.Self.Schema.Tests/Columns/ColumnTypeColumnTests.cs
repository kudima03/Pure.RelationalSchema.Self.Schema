using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.ColumnType;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;

namespace Pure.RelationalSchema.Self.Schema.Tests.Columns;

public sealed record ColumnTypeColumnTests
{
    [Fact]
    public void NameIsType()
    {
        IColumn column = new ColumnTypeColumn();

        Assert.Equal("type", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsStringColumnType()
    {
        IColumn column = new ColumnTypeColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new StringColumnType())
            )
        );
    }
}
