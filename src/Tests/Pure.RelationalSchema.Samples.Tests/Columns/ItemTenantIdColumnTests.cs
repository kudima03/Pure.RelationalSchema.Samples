using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record ItemTenantIdColumnTests
{
    [Fact]
    public void NameIsItemTenantId()
    {
        IColumn column = new ItemTenantIdColumn();

        Assert.Equal("item_tenant_id", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsUuidColumnType()
    {
        IColumn column = new ItemTenantIdColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new UuidColumnType())
            )
        );
    }
}
