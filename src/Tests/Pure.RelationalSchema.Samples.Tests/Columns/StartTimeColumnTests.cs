using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record StartTimeColumnTests
{
    [Fact]
    public void NameIsStartTime()
    {
        IColumn column = new StartTimeColumn();

        Assert.Equal("start_time", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsTimeColumnType()
    {
        IColumn column = new StartTimeColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new TimeColumnType())
            )
        );
    }
}
