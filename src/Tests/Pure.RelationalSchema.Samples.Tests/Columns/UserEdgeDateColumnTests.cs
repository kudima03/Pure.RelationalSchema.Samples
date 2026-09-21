using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record UserEdgeDateColumnTests
{
    [Fact]
    public void NameIsUserEdgeDate()
    {
        IColumn column = new UserEdgeDateColumn();

        Assert.Equal("user_edge_date", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsDateColumnType()
    {
        IColumn column = new UserEdgeDateColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new DateColumnType())
            )
        );
    }
}
