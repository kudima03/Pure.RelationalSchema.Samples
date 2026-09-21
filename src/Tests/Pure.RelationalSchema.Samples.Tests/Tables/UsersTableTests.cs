using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Tables;

public sealed record UsersTableTests
{
    [Fact]
    public void NameIsUsers()
    {
        ITable table = new UsersTable();

        Assert.Equal("users", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsCountIs13()
    {
        ITable table = new UsersTable();

        Assert.Equal(13, table.Columns.Count());
    }

    [Fact]
    public void IndexesCountIs2()
    {
        ITable table = new UsersTable();

        Assert.Equal(2, table.Indexes.Count());
    }

    [Fact]
    public void ColumnsContainsUserIdColumn()
    {
        ITable table = new UsersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UserIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsUserTenantIdColumn()
    {
        ITable table = new UsersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UserTenantIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsUserNameColumn()
    {
        ITable table = new UsersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UserNameColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsSignupDateColumn()
    {
        ITable table = new UsersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new SignupDateColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsUserActiveColumn()
    {
        ITable table = new UsersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UserActiveColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsLastLoginColumn()
    {
        ITable table = new UsersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new LastLoginColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsUserAgeColumn()
    {
        ITable table = new UsersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UserAgeColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsShiftStartColumn()
    {
        ITable table = new UsersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new ShiftStartColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsUserScoreColumn()
    {
        ITable table = new UsersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UserScoreColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsUserPrecisionValueColumn()
    {
        ITable table = new UsersTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new UserPrecisionValueColumn())
                )
        );
    }

    [Fact]
    public void ColumnsContainsUserEdgeDateColumn()
    {
        ITable table = new UsersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UserEdgeDateColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsUserEdgeDateTimeColumn()
    {
        ITable table = new UsersTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new UserEdgeDateTimeColumn())
                )
        );
    }

    [Fact]
    public void ColumnsContainsUserEdgeTimeColumn()
    {
        ITable table = new UsersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UserEdgeTimeColumn()))
        );
    }

    [Fact]
    public void IndexesContainsUsersPrimaryIndex()
    {
        ITable table = new UsersTable();

        Assert.Contains(
            table.Indexes,
            i => new IndexHash(i).SequenceEqual(new IndexHash(new UsersPrimaryIndex()))
        );
    }

    [Fact]
    public void IndexesContainsUsersNameIndex()
    {
        ITable table = new UsersTable();

        Assert.Contains(
            table.Indexes,
            i => new IndexHash(i).SequenceEqual(new IndexHash(new UsersNameIndex()))
        );
    }
}
