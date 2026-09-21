using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record StatusLabelColumnTests
{
    [Fact]
    public void NameIsStatusLabel()
    {
        IColumn column = new StatusLabelColumn();

        Assert.Equal("status_label", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsStringColumnType()
    {
        IColumn column = new StatusLabelColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new StringColumnType())
            )
        );
    }
}
