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
    public void ColumnsCountIs5()
    {
        ITable table = new EmployeesTable();

        Assert.Equal(5, table.Columns.Count());
    }

    [Fact]
    public void IndexesCountIs1()
    {
        ITable table = new EmployeesTable();

        _ = Assert.Single(table.Indexes);
    }

    [Fact]
    public void ColumnsContainsEmployeeIdColumn()
    {
        ITable table = new EmployeesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new EmployeeIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsEmployeeNameColumn()
    {
        ITable table = new EmployeesTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new EmployeeNameColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsEmployeeManagerIdColumn()
    {
        ITable table = new EmployeesTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new EmployeeManagerIdColumn())
                )
        );
    }

    [Fact]
    public void ColumnsContainsEmployeeShiftStartColumn()
    {
        ITable table = new EmployeesTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new EmployeeShiftStartColumn())
                )
        );
    }

    [Fact]
    public void ColumnsContainsEmployeeUserIdColumn()
    {
        ITable table = new EmployeesTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new EmployeeUserIdColumn())
                )
        );
    }

    [Fact]
    public void IndexesContainsEmployeesPrimaryIndex()
    {
        ITable table = new EmployeesTable();

        Assert.Contains(
            table.Indexes,
            i =>
                new IndexHash(i).SequenceEqual(new IndexHash(new EmployeesPrimaryIndex()))
        );
    }
}
