using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.ColumnType;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;

namespace Pure.RelationalSchema.Self.Schema.Tests.Columns;

public sealed record IsUniqueColumnTests
{
    [Fact]
    public void NameIsIsUnique()
    {
        IColumn column = new IsUniqueColumn();

        Assert.Equal("is_unique", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsBoolColumnType()
    {
        IColumn column = new IsUniqueColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new BoolColumnType())
            )
        );
    }
}
