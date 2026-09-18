using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Samples.Indexes;

namespace Pure.RelationalSchema.Samples.Tests.Indexes;

public sealed record EmptyIndexTests
{
    [Fact]
    public void IsUniqueIsFalse()
    {
        IIndex index = new EmptyIndex();

        Assert.False(index.IsUnique.BoolValue);
    }

    [Fact]
    public void ColumnsIsEmpty()
    {
        IIndex index = new EmptyIndex();

        Assert.Empty(index.Columns);
    }
}
