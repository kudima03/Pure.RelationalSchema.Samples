using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Tables;

public sealed record TableWithSingleIndexTests
{
    [Fact]
    public void NameIsTableWithSingleIndex()
    {
        ITable table = new TableWithSingleIndex();

        Assert.Equal("table_with_single_index", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsCountIs2()
    {
        ITable table = new TableWithSingleIndex();

        Assert.Equal(2, table.Columns.Count());
    }

    [Fact]
    public void IndexesCountIs1()
    {
        ITable table = new TableWithSingleIndex();

        _ = Assert.Single(table.Indexes);
    }

    [Fact]
    public void ColumnsContainsIdColumn()
    {
        ITable table = new TableWithSingleIndex();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new IdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsNameColumn()
    {
        ITable table = new TableWithSingleIndex();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new NameColumn()))
        );
    }

    [Fact]
    public void IndexesContainsSingleColumnUniqueIndex()
    {
        ITable table = new TableWithSingleIndex();

        Assert.Contains(
            table.Indexes,
            i =>
                new IndexHash(i).SequenceEqual(
                    new IndexHash(new SingleColumnUniqueIndex())
                )
        );
    }
}
