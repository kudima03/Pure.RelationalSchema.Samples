using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record LoginIdColumnTests
{
    [Fact]
    public void NameIsLoginId()
    {
        IColumn column = new LoginIdColumn();

        Assert.Equal("login_id", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsUuidColumnType()
    {
        IColumn column = new LoginIdColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new UuidColumnType())
            )
        );
    }
}
