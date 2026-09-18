using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record EmptyNameColumnTests
{
    [Fact]
    public void NameIsEmpty()
    {
        IColumn column = new EmptyNameColumn();

        Assert.Equal("", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsEmptyNameColumnType()
    {
        IColumn column = new EmptyNameColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new EmptyNameColumnType())
            )
        );
    }
}
