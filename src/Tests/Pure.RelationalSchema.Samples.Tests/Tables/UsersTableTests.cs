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
    public void ColumnsCountIs6()
    {
        ITable table = new UsersTable();

        Assert.Equal(6, table.Columns.Count());
    }

    [Fact]
    public void IndexesCountIs2()
    {
        ITable table = new UsersTable();

        Assert.Equal(2, table.Indexes.Count());
    }

    [Fact]
    public void ColumnsContainsIdColumn()
    {
        ITable table = new UsersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new IdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsTenantIdColumn()
    {
        ITable table = new UsersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new TenantIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsNameColumn()
    {
        ITable table = new UsersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new NameColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsBirthDateColumn()
    {
        ITable table = new UsersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new BirthDateColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsIsActiveColumn()
    {
        ITable table = new UsersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new IsActiveColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsCreatedAtColumn()
    {
        ITable table = new UsersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new CreatedAtColumn()))
        );
    }

    [Fact]
    public void IndexesContainsSingleColumnUniqueIndex()
    {
        ITable table = new UsersTable();

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
        ITable table = new UsersTable();

        Assert.Contains(
            table.Indexes,
            i =>
                new IndexHash(i).SequenceEqual(
                    new IndexHash(new SingleColumnNonUniqueIndex())
                )
        );
    }
}
