using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Samples.Indexes;

namespace Pure.RelationalSchema.Samples.Tests.Indexes;

public sealed record EmptyUniqueIndexTests
{
    [Fact]
    public void IsUniqueIsTrue()
    {
        IIndex index = new EmptyUniqueIndex();

        Assert.True(index.IsUnique.BoolValue);
    }

    [Fact]
    public void ColumnsIsEmpty()
    {
        IIndex index = new EmptyUniqueIndex();

        Assert.Empty(index.Columns);
    }
}
