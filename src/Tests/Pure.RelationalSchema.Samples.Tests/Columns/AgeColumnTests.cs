using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record AgeColumnTests
{
    [Fact]
    public void NameIsAge()
    {
        IColumn column = new AgeColumn();

        Assert.Equal("age", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsIntColumnType()
    {
        IColumn column = new AgeColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new IntColumnType())
            )
        );
    }
}
