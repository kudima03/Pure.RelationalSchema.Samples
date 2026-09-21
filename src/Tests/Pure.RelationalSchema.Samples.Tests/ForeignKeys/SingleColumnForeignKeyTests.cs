using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ForeignKeys;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.ForeignKeys;

public sealed record SingleColumnForeignKeyTests
{
    [Fact]
    public void ReferencingTableIsOrdersTable()
    {
        IForeignKey foreignKey = new SingleColumnForeignKey();

        Assert.True(
            new TableHash(foreignKey.ReferencingTable).SequenceEqual(
                new TableHash(new OrdersTable())
            )
        );
    }

    [Fact]
    public void ReferencedTableIsUsersTable()
    {
        IForeignKey foreignKey = new SingleColumnForeignKey();

        Assert.True(
            new TableHash(foreignKey.ReferencedTable).SequenceEqual(
                new TableHash(new UsersTable())
            )
        );
    }

    [Fact]
    public void ReferencingColumnsCountIs1()
    {
        IForeignKey foreignKey = new SingleColumnForeignKey();

        _ = Assert.Single(foreignKey.ReferencingColumns);
    }

    [Fact]
    public void ReferencedColumnsCountIs1()
    {
        IForeignKey foreignKey = new SingleColumnForeignKey();

        _ = Assert.Single(foreignKey.ReferencedColumns);
    }

    [Fact]
    public void ReferencingColumnsContainsOrderUserIdColumn()
    {
        IForeignKey foreignKey = new SingleColumnForeignKey();

        Assert.Contains(
            foreignKey.ReferencingColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new OrderUserIdColumn()))
        );
    }

    [Fact]
    public void ReferencedColumnsContainsUserIdColumn()
    {
        IForeignKey foreignKey = new SingleColumnForeignKey();

        Assert.Contains(
            foreignKey.ReferencedColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UserIdColumn()))
        );
    }
}
