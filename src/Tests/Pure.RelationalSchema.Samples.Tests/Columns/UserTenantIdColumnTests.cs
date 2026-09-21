using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record UserTenantIdColumnTests
{
    [Fact]
    public void NameIsUserTenantId()
    {
        IColumn column = new UserTenantIdColumn();

        Assert.Equal("user_tenant_id", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsUuidColumnType()
    {
        IColumn column = new UserTenantIdColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new UuidColumnType())
            )
        );
    }
}
