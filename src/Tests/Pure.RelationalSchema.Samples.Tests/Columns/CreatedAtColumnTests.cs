using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record CreatedAtColumnTests
{
    [Fact]
    public void NameIsCreatedAt()
    {
        IColumn column = new CreatedAtColumn();

        Assert.Equal("created_at", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsDateTimeColumnType()
    {
        IColumn column = new CreatedAtColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new DateTimeColumnType())
            )
        );
    }
}
