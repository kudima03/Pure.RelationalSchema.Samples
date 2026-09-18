using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Tables;

public sealed record EmployeesTableTests
{
    [Fact]
    public void NameIsEmployees()
    {
        ITable table = new EmployeesTable();

        Assert.Equal("employees", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsCountIs4()
    {
        ITable table = new EmployeesTable();

        Assert.Equal(4, table.Columns.Count());
    }

    [Fact]
    public void IndexesCountIs1()
    {
        ITable table = new EmployeesTable();

        _ = Assert.Single(table.Indexes);
    }

    [Fact]
    public void ColumnsContainsIdColumn()
    {
        ITable table = new EmployeesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new IdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsNameColumn()
    {
        ITable table = new EmployeesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new NameColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsManagerIdColumn()
    {
        ITable table = new EmployeesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new ManagerIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsStartTimeColumn()
    {
        ITable table = new EmployeesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new StartTimeColumn()))
        );
    }

    [Fact]
    public void IndexesContainsSingleColumnUniqueIndex()
    {
        ITable table = new EmployeesTable();

        Assert.Contains(
            table.Indexes,
            i =>
                new IndexHash(i).SequenceEqual(
                    new IndexHash(new SingleColumnUniqueIndex())
                )
        );
    }
}
