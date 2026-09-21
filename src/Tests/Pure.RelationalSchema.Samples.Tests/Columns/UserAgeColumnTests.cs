using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record UserAgeColumnTests
{
    [Fact]
    public void NameIsUserAge()
    {
        IColumn column = new UserAgeColumn();

        Assert.Equal("user_age", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsDoubleColumnType()
    {
        IColumn column = new UserAgeColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new DoubleColumnType())
            )
        );
    }
}
