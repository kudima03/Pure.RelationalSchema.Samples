using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;

namespace Pure.RelationalSchema.Samples.Tests.Indexes;

public sealed record ProductsPrimaryIndexTests
{
    [Fact]
    public void IsUniqueIsTrue()
    {
        IIndex index = new ProductsPrimaryIndex();

        Assert.True(index.IsUnique.BoolValue);
    }

    [Fact]
    public void ColumnsCountIs1()
    {
        IIndex index = new ProductsPrimaryIndex();

        _ = Assert.Single(index.Columns);
    }

    [Fact]
    public void ColumnsContainsProductIdColumn()
    {
        IIndex index = new ProductsPrimaryIndex();

        Assert.Contains(
            index.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new ProductIdColumn()))
        );
    }
}
