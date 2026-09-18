using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.ForeignKeys;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.ForeignKeys;

public sealed record EmptyColumnsForeignKeyTests
{
    [Fact]
    public void ReferencingTableIsEmptyTable()
    {
        IForeignKey foreignKey = new EmptyColumnsForeignKey();

        Assert.True(
            new TableHash(foreignKey.ReferencingTable).SequenceEqual(
                new TableHash(new EmptyTable())
            )
        );
    }

    [Fact]
    public void ReferencedTableIsSingleColumnTable()
    {
        IForeignKey foreignKey = new EmptyColumnsForeignKey();

        Assert.True(
            new TableHash(foreignKey.ReferencedTable).SequenceEqual(
                new TableHash(new SingleColumnTable())
            )
        );
    }

    [Fact]
    public void ReferencingColumnsIsEmpty()
    {
        IForeignKey foreignKey = new EmptyColumnsForeignKey();

        Assert.Empty(foreignKey.ReferencingColumns);
    }

    [Fact]
    public void ReferencedColumnsIsEmpty()
    {
        IForeignKey foreignKey = new EmptyColumnsForeignKey();

        Assert.Empty(foreignKey.ReferencedColumns);
    }
}
