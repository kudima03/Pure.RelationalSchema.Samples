using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record SignupDateColumnTests
{
    [Fact]
    public void NameIsSignupDate()
    {
        IColumn column = new SignupDateColumn();

        Assert.Equal("signup_date", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsDateColumnType()
    {
        IColumn column = new SignupDateColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new DateColumnType())
            )
        );
    }
}
