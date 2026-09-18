using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;

namespace Pure.RelationalSchema.Samples.Tests.Indexes;

public sealed record CompositeNonUniqueIndexTests
{
    [Fact]
    public void IsUniqueIsFalse()
    {
        IIndex index = new CompositeNonUniqueIndex();

        Assert.False(index.IsUnique.BoolValue);
    }

    [Fact]
    public void ColumnsCountIs2()
    {
        IIndex index = new CompositeNonUniqueIndex();

        Assert.Equal(2, index.Columns.Count());
    }

    [Fact]
    public void ColumnsContainsNameColumn()
    {
        IIndex index = new CompositeNonUniqueIndex();

        Assert.Contains(
            index.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new NameColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsCreatedAtColumn()
    {
        IIndex index = new CompositeNonUniqueIndex();

        Assert.Contains(
            index.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new CreatedAtColumn()))
        );
    }
}
