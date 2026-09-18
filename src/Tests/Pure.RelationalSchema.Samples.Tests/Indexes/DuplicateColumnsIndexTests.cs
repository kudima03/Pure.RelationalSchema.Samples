using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;

namespace Pure.RelationalSchema.Samples.Tests.Indexes;

public sealed record DuplicateColumnsIndexTests
{
    [Fact]
    public void IsUniqueIsFalse()
    {
        IIndex index = new DuplicateColumnsIndex();

        Assert.False(index.IsUnique.BoolValue);
    }

    [Fact]
    public void ColumnsCountIs2()
    {
        IIndex index = new DuplicateColumnsIndex();

        Assert.Equal(2, index.Columns.Count());
    }

    [Fact]
    public void ColumnsContainsIdColumn()
    {
        IIndex index = new DuplicateColumnsIndex();

        Assert.Contains(
            index.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new IdColumn()))
        );
    }
}
