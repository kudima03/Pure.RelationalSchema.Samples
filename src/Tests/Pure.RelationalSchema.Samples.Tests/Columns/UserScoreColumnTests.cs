using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record UserScoreColumnTests
{
    [Fact]
    public void NameIsUserScore()
    {
        IColumn column = new UserScoreColumn();

        Assert.Equal("user_score", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsDoubleColumnType()
    {
        IColumn column = new UserScoreColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new DoubleColumnType())
            )
        );
    }
}
