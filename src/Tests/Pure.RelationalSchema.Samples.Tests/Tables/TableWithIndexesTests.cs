using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Tables;

public sealed record TableWithIndexesTests
{
    [Fact]
    public void NameIsTableWithIndexes()
    {
        ITable table = new TableWithIndexes();

        Assert.Equal("table_with_indexes", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsCountIs4()
    {
        ITable table = new TableWithIndexes();

        Assert.Equal(4, table.Columns.Count());
    }

    [Fact]
    public void IndexesCountIs4()
    {
        ITable table = new TableWithIndexes();

        Assert.Equal(4, table.Indexes.Count());
    }

    [Fact]
    public void ColumnsContainsIdColumn()
    {
        ITable table = new TableWithIndexes();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new IdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsTenantIdColumn()
    {
        ITable table = new TableWithIndexes();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new TenantIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsNameColumn()
    {
        ITable table = new TableWithIndexes();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new NameColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsCreatedAtColumn()
    {
        ITable table = new TableWithIndexes();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new CreatedAtColumn()))
        );
    }

    [Fact]
    public void IndexesContainsSingleColumnUniqueIndex()
    {
        ITable table = new TableWithIndexes();

        Assert.Contains(
            table.Indexes,
            i =>
                new IndexHash(i).SequenceEqual(
                    new IndexHash(new SingleColumnUniqueIndex())
                )
        );
    }

    [Fact]
    public void IndexesContainsSingleColumnNonUniqueIndex()
    {
        ITable table = new TableWithIndexes();

        Assert.Contains(
            table.Indexes,
            i =>
                new IndexHash(i).SequenceEqual(
                    new IndexHash(new SingleColumnNonUniqueIndex())
                )
        );
    }

    [Fact]
    public void IndexesContainsCompositeUniqueIndex()
    {
        ITable table = new TableWithIndexes();

        Assert.Contains(
            table.Indexes,
            i => new IndexHash(i).SequenceEqual(new IndexHash(new CompositeUniqueIndex()))
        );
    }

    [Fact]
    public void IndexesContainsCompositeNonUniqueIndex()
    {
        ITable table = new TableWithIndexes();

        Assert.Contains(
            table.Indexes,
            i =>
                new IndexHash(i).SequenceEqual(
                    new IndexHash(new CompositeNonUniqueIndex())
                )
        );
    }
}
