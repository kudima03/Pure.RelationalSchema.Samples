using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Tables;

public sealed record StatusesTableTests
{
    [Fact]
    public void NameIsStatuses()
    {
        ITable table = new StatusesTable();

        Assert.Equal("statuses", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsCountIs3()
    {
        ITable table = new StatusesTable();

        Assert.Equal(3, table.Columns.Count());
    }

    [Fact]
    public void IndexesIsEmpty()
    {
        ITable table = new StatusesTable();

        Assert.Empty(table.Indexes);
    }

    [Fact]
    public void ColumnsContainsStatusCodeColumn()
    {
        ITable table = new StatusesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new StatusCodeColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsStatusLabelColumn()
    {
        ITable table = new StatusesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new StatusLabelColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsStatusIsFinalColumn()
    {
        ITable table = new StatusesTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(new ColumnHash(new StatusIsFinalColumn()))
        );
    }
}
