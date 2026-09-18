using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Tables;

public sealed record TableWithoutIndexesTests
{
    [Fact]
    public void NameIsTableWithoutIndexes()
    {
        ITable table = new TableWithoutIndexes();

        Assert.Equal("table_without_indexes", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsCountIs3()
    {
        ITable table = new TableWithoutIndexes();

        Assert.Equal(3, table.Columns.Count());
    }

    [Fact]
    public void IndexesIsEmpty()
    {
        ITable table = new TableWithoutIndexes();

        Assert.Empty(table.Indexes);
    }

    [Fact]
    public void ColumnsContainsIdColumn()
    {
        ITable table = new TableWithoutIndexes();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new IdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsNameColumn()
    {
        ITable table = new TableWithoutIndexes();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new NameColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsCreatedAtColumn()
    {
        ITable table = new TableWithoutIndexes();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new CreatedAtColumn()))
        );
    }
}
