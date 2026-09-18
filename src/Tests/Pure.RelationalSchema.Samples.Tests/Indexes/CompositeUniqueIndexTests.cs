using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;

namespace Pure.RelationalSchema.Samples.Tests.Indexes;

public sealed record CompositeUniqueIndexTests
{
    [Fact]
    public void IsUniqueIsTrue()
    {
        IIndex index = new CompositeUniqueIndex();

        Assert.True(index.IsUnique.BoolValue);
    }

    [Fact]
    public void ColumnsCountIs2()
    {
        IIndex index = new CompositeUniqueIndex();

        Assert.Equal(2, index.Columns.Count());
    }

    [Fact]
    public void ColumnsContainsTenantIdColumn()
    {
        IIndex index = new CompositeUniqueIndex();

        Assert.Contains(
            index.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new TenantIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsIdColumn()
    {
        IIndex index = new CompositeUniqueIndex();

        Assert.Contains(
            index.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new IdColumn()))
        );
    }
}
