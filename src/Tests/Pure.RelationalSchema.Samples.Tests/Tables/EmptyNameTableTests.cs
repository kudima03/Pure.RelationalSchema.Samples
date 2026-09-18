using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Tables;

public sealed record EmptyNameTableTests
{
    [Fact]
    public void NameIsEmpty()
    {
        ITable table = new EmptyNameTable();

        Assert.Equal(string.Empty, table.Name.TextValue);
    }

    [Fact]
    public void ColumnsIsEmpty()
    {
        ITable table = new EmptyNameTable();

        Assert.Empty(table.Columns);
    }

    [Fact]
    public void IndexesIsEmpty()
    {
        ITable table = new EmptyNameTable();

        Assert.Empty(table.Indexes);
    }
}
