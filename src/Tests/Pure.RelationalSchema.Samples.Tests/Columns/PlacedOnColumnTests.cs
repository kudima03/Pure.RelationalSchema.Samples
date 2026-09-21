using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record PlacedOnColumnTests
{
    [Fact]
    public void NameIsPlacedOn()
    {
        IColumn column = new PlacedOnColumn();

        Assert.Equal("placed_on", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsDateColumnType()
    {
        IColumn column = new PlacedOnColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new DateColumnType())
            )
        );
    }
}
