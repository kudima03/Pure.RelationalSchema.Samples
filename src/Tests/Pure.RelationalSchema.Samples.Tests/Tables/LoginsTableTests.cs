using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Tables;

public sealed record LoginsTableTests
{
    [Fact]
    public void NameIsLogins()
    {
        ITable table = new LoginsTable();

        Assert.Equal("logins", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsCountIs3()
    {
        ITable table = new LoginsTable();

        Assert.Equal(3, table.Columns.Count());
    }

    [Fact]
    public void IndexesIsEmpty()
    {
        ITable table = new LoginsTable();

        Assert.Empty(table.Indexes);
    }

    [Fact]
    public void ColumnsContainsLoginIdColumn()
    {
        ITable table = new LoginsTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new LoginIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsLoginUserIdColumn()
    {
        ITable table = new LoginsTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new LoginUserIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsLoginAtColumn()
    {
        ITable table = new LoginsTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new LoginAtColumn()))
        );
    }
}
