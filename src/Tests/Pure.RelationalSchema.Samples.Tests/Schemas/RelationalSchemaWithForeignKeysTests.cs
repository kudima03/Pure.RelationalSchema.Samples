using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.ForeignKeys;
using Pure.RelationalSchema.Samples.Schemas;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Schemas;

public sealed record RelationalSchemaWithForeignKeysTests
{
    [Fact]
    public void NameIsSchemaWithForeignKeys()
    {
        ISchema schema = new RelationalSchemaWithForeignKeys();

        Assert.Equal("schema_with_foreign_keys", schema.Name.TextValue);
    }

    [Fact]
    public void TablesCountIs2()
    {
        ISchema schema = new RelationalSchemaWithForeignKeys();

        Assert.Equal(2, schema.Tables.Count());
    }

    [Fact]
    public void ForeignKeysCountIs1()
    {
        ISchema schema = new RelationalSchemaWithForeignKeys();

        _ = Assert.Single(schema.ForeignKeys);
    }

    [Fact]
    public void TablesContainsUsersTable()
    {
        ISchema schema = new RelationalSchemaWithForeignKeys();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new UsersTable()))
        );
    }

    [Fact]
    public void TablesContainsOrdersTable()
    {
        ISchema schema = new RelationalSchemaWithForeignKeys();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new OrdersTable()))
        );
    }

    [Fact]
    public void ForeignKeysContainsSingleColumnForeignKey()
    {
        ISchema schema = new RelationalSchemaWithForeignKeys();

        Assert.Contains(
            schema.ForeignKeys,
            f =>
                new ForeignKeyHash(f).SequenceEqual(
                    new ForeignKeyHash(new SingleColumnForeignKey())
                )
        );
    }
}
