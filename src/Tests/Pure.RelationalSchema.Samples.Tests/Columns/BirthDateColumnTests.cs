using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record BirthDateColumnTests
{
    [Fact]
    public void NameIsBirthDate()
    {
        IColumn column = new BirthDateColumn();

        Assert.Equal("birth_date", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsDateColumnType()
    {
        IColumn column = new BirthDateColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new DateColumnType())
            )
        );
    }
}
