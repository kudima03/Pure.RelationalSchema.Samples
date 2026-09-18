using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;

namespace Pure.RelationalSchema.Samples.Tests.Indexes;

public sealed record SingleColumnNonUniqueIndexTests
{
    [Fact]
    public void IsUniqueIsFalse()
    {
        IIndex index = new SingleColumnNonUniqueIndex();

        Assert.False(index.IsUnique.BoolValue);
    }

    [Fact]
    public void ColumnsCountIs1()
    {
        IIndex index = new SingleColumnNonUniqueIndex();

        _ = Assert.Single(index.Columns);
    }

    [Fact]
    public void ColumnsContainsNameColumn()
    {
        IIndex index = new SingleColumnNonUniqueIndex();

        Assert.Contains(
            index.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new NameColumn()))
        );
    }
}
