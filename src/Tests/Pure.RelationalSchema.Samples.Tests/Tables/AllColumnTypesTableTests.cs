using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Tables;

public sealed record AllColumnTypesTableTests
{
    [Fact]
    public void NameIsAllColumnTypesTable()
    {
        ITable table = new AllColumnTypesTable();

        Assert.Equal("all_column_types_table", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsCountIs10()
    {
        ITable table = new AllColumnTypesTable();

        Assert.Equal(10, table.Columns.Count());
    }

    [Fact]
    public void IndexesIsEmpty()
    {
        ITable table = new AllColumnTypesTable();

        Assert.Empty(table.Indexes);
    }

    [Fact]
    public void ColumnsContainsIdColumn()
    {
        ITable table = new AllColumnTypesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new IdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsNameColumn()
    {
        ITable table = new AllColumnTypesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new NameColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsAgeColumn()
    {
        ITable table = new AllColumnTypesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new AgeColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsQuantityColumn()
    {
        ITable table = new AllColumnTypesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new QuantityColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsPriceColumn()
    {
        ITable table = new AllColumnTypesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new PriceColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsIsActiveColumn()
    {
        ITable table = new AllColumnTypesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new IsActiveColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsBirthDateColumn()
    {
        ITable table = new AllColumnTypesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new BirthDateColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsStartTimeColumn()
    {
        ITable table = new AllColumnTypesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new StartTimeColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsCreatedAtColumn()
    {
        ITable table = new AllColumnTypesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new CreatedAtColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsEmptyNameColumn()
    {
        ITable table = new AllColumnTypesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new EmptyNameColumn()))
        );
    }
}
