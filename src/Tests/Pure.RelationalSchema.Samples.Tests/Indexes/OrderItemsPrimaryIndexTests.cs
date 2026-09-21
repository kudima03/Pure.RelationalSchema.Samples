using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;

namespace Pure.RelationalSchema.Samples.Tests.Indexes;

public sealed record OrderItemsPrimaryIndexTests
{
    [Fact]
    public void IsUniqueIsTrue()
    {
        IIndex index = new OrderItemsPrimaryIndex();

        Assert.True(index.IsUnique.BoolValue);
    }

    [Fact]
    public void ColumnsCountIs1()
    {
        IIndex index = new OrderItemsPrimaryIndex();

        _ = Assert.Single(index.Columns);
    }

    [Fact]
    public void ColumnsContainsItemIdColumn()
    {
        IIndex index = new OrderItemsPrimaryIndex();

        Assert.Contains(
            index.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new ItemIdColumn()))
        );
    }
}
