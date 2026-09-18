using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Tables;

public sealed record SingleColumnTableTests
{
    [Fact]
    public void NameIsSingleColumnTable()
    {
        ITable table = new SingleColumnTable();

        Assert.Equal("single_column_table", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsCountIs1()
    {
        ITable table = new SingleColumnTable();

        _ = Assert.Single(table.Columns);
    }

    [Fact]
    public void IndexesIsEmpty()
    {
        ITable table = new SingleColumnTable();

        Assert.Empty(table.Indexes);
    }

    [Fact]
    public void ColumnsContainsIdColumn()
    {
        ITable table = new SingleColumnTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new IdColumn()))
        );
    }
}
