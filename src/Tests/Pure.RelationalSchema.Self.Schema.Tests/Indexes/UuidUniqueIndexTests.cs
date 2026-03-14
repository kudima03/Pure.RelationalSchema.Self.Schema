using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Self.Schema.Columns;
using Pure.RelationalSchema.Self.Schema.Indexes;

namespace Pure.RelationalSchema.Self.Schema.Tests.Indexes;

public sealed record UuidUniqueIndexTests
{
    [Fact]
    public void IsUniqueIsTrue()
    {
        IIndex index = new UuidUniqueIndex();

        Assert.True(index.IsUnique.BoolValue);
    }

    [Fact]
    public void ColumnsContainsUuidColumn()
    {
        IIndex index = new UuidUniqueIndex();

        Assert.Contains(
            index.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UuidColumn()))
        );
    }

    [Fact]
    public void ColumnsCountIs1()
    {
        IIndex index = new UuidUniqueIndex();

        _ = Assert.Single(index.Columns);
    }
}
