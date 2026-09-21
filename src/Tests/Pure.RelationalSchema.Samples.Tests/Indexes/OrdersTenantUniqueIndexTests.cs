using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;

namespace Pure.RelationalSchema.Samples.Tests.Indexes;

public sealed record OrdersTenantUniqueIndexTests
{
    [Fact]
    public void IsUniqueIsTrue()
    {
        IIndex index = new OrdersTenantUniqueIndex();

        Assert.True(index.IsUnique.BoolValue);
    }

    [Fact]
    public void ColumnsCountIs2()
    {
        IIndex index = new OrdersTenantUniqueIndex();

        Assert.Equal(2, index.Columns.Count());
    }

    [Fact]
    public void ColumnsContainsOrderTenantIdColumn()
    {
        IIndex index = new OrdersTenantUniqueIndex();

        Assert.Contains(
            index.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(new ColumnHash(new OrderTenantIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsOrderIdColumn()
    {
        IIndex index = new OrdersTenantUniqueIndex();

        Assert.Contains(
            index.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new OrderIdColumn()))
        );
    }
}
