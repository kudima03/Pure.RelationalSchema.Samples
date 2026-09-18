using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;

namespace Pure.RelationalSchema.Samples.Tests.Indexes;

public sealed record SingleColumnUniqueIndexTests
{
    [Fact]
    public void IsUniqueIsTrue()
    {
        IIndex index = new SingleColumnUniqueIndex();

        Assert.True(index.IsUnique.BoolValue);
    }

    [Fact]
    public void ColumnsCountIs1()
    {
        IIndex index = new SingleColumnUniqueIndex();

        _ = Assert.Single(index.Columns);
    }

    [Fact]
    public void ColumnsContainsIdColumn()
    {
        IIndex index = new SingleColumnUniqueIndex();

        Assert.Contains(
            index.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new IdColumn()))
        );
    }
}
