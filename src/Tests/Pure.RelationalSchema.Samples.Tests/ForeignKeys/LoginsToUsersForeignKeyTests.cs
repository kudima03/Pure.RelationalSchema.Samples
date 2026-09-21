using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ForeignKeys;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.ForeignKeys;

public sealed record LoginsToUsersForeignKeyTests
{
    [Fact]
    public void ReferencingTableIsLoginsTable()
    {
        IForeignKey foreignKey = new LoginsToUsersForeignKey();

        Assert.True(
            new TableHash(foreignKey.ReferencingTable).SequenceEqual(
                new TableHash(new LoginsTable())
            )
        );
    }

    [Fact]
    public void ReferencedTableIsUsersTable()
    {
        IForeignKey foreignKey = new LoginsToUsersForeignKey();

        Assert.True(
            new TableHash(foreignKey.ReferencedTable).SequenceEqual(
                new TableHash(new UsersTable())
            )
        );
    }

    [Fact]
    public void ReferencingColumnsCountIs1()
    {
        IForeignKey foreignKey = new LoginsToUsersForeignKey();

        _ = Assert.Single(foreignKey.ReferencingColumns);
    }

    [Fact]
    public void ReferencedColumnsCountIs1()
    {
        IForeignKey foreignKey = new LoginsToUsersForeignKey();

        _ = Assert.Single(foreignKey.ReferencedColumns);
    }

    [Fact]
    public void ReferencingColumnsContainsLoginUserIdColumn()
    {
        IForeignKey foreignKey = new LoginsToUsersForeignKey();

        Assert.Contains(
            foreignKey.ReferencingColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new LoginUserIdColumn()))
        );
    }

    [Fact]
    public void ReferencedColumnsContainsUserIdColumn()
    {
        IForeignKey foreignKey = new LoginsToUsersForeignKey();

        Assert.Contains(
            foreignKey.ReferencedColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UserIdColumn()))
        );
    }
}
