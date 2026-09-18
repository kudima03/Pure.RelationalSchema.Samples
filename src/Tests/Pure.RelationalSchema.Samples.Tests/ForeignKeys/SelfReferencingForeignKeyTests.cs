using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ForeignKeys;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.ForeignKeys;

public sealed record SelfReferencingForeignKeyTests
{
    [Fact]
    public void ReferencingTableIsEmployeesTable()
    {
        IForeignKey foreignKey = new SelfReferencingForeignKey();

        Assert.True(
            new TableHash(foreignKey.ReferencingTable).SequenceEqual(
                new TableHash(new EmployeesTable())
            )
        );
    }

    [Fact]
    public void ReferencedTableIsEmployeesTable()
    {
        IForeignKey foreignKey = new SelfReferencingForeignKey();

        Assert.True(
            new TableHash(foreignKey.ReferencedTable).SequenceEqual(
                new TableHash(new EmployeesTable())
            )
        );
    }

    [Fact]
    public void ReferencingColumnsCountIs1()
    {
        IForeignKey foreignKey = new SelfReferencingForeignKey();

        _ = Assert.Single(foreignKey.ReferencingColumns);
    }

    [Fact]
    public void ReferencedColumnsCountIs1()
    {
        IForeignKey foreignKey = new SelfReferencingForeignKey();

        _ = Assert.Single(foreignKey.ReferencedColumns);
    }

    [Fact]
    public void ReferencingColumnsContainsManagerIdColumn()
    {
        IForeignKey foreignKey = new SelfReferencingForeignKey();

        Assert.Contains(
            foreignKey.ReferencingColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new ManagerIdColumn()))
        );
    }

    [Fact]
    public void ReferencedColumnsContainsIdColumn()
    {
        IForeignKey foreignKey = new SelfReferencingForeignKey();

        Assert.Contains(
            foreignKey.ReferencedColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new IdColumn()))
        );
    }
}
