using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;

namespace Pure.RelationalSchema.Samples.Tests.Indexes;

public sealed record OrdersPrimaryIndexTests
{
    [Fact]
    public void IsUniqueIsTrue()
    {
        IIndex index = new OrdersPrimaryIndex();

        Assert.True(index.IsUnique.BoolValue);
    }

    [Fact]
    public void ColumnsCountIs1()
    {
        IIndex index = new OrdersPrimaryIndex();

        _ = Assert.Single(index.Columns);
    }

    [Fact]
    public void ColumnsContainsOrderIdColumn()
    {
        IIndex index = new OrdersPrimaryIndex();

        Assert.Contains(
            index.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new OrderIdColumn()))
        );
    }
}
