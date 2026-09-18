using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Tables;

public sealed record EmptyTableTests
{
    [Fact]
    public void NameIsEmptyTable()
    {
        ITable table = new EmptyTable();

        Assert.Equal("empty_table", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsIsEmpty()
    {
        ITable table = new EmptyTable();

        Assert.Empty(table.Columns);
    }

    [Fact]
    public void IndexesIsEmpty()
    {
        ITable table = new EmptyTable();

        Assert.Empty(table.Indexes);
    }
}
