using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record UserEdgeTimeColumnTests
{
    [Fact]
    public void NameIsUserEdgeTime()
    {
        IColumn column = new UserEdgeTimeColumn();

        Assert.Equal("user_edge_time", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsTimeColumnType()
    {
        IColumn column = new UserEdgeTimeColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new TimeColumnType())
            )
        );
    }
}
