using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record UserEdgeDateTimeColumnTests
{
    [Fact]
    public void NameIsUserEdgeDatetime()
    {
        IColumn column = new UserEdgeDateTimeColumn();

        Assert.Equal("user_edge_datetime", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsDateTimeColumnType()
    {
        IColumn column = new UserEdgeDateTimeColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new DateTimeColumnType())
            )
        );
    }
}
