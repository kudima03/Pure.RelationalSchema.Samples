using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.ForeignKeys;
using Pure.RelationalSchema.Samples.Schemas;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Schemas;

public sealed record RelationalSchemaWithCompositeForeignKeyTests
{
    [Fact]
    public void NameIsSchemaWithCompositeForeignKey()
    {
        ISchema schema = new RelationalSchemaWithCompositeForeignKey();

        Assert.Equal("schema_with_composite_foreign_key", schema.Name.TextValue);
    }

    [Fact]
    public void TablesCountIs2()
    {
        ISchema schema = new RelationalSchemaWithCompositeForeignKey();

        Assert.Equal(2, schema.Tables.Count());
    }

    [Fact]
    public void ForeignKeysCountIs1()
    {
        ISchema schema = new RelationalSchemaWithCompositeForeignKey();

        _ = Assert.Single(schema.ForeignKeys);
    }

    [Fact]
    public void TablesContainsOrdersTable()
    {
        ISchema schema = new RelationalSchemaWithCompositeForeignKey();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new OrdersTable()))
        );
    }

    [Fact]
    public void TablesContainsOrderItemsTable()
    {
        ISchema schema = new RelationalSchemaWithCompositeForeignKey();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new OrderItemsTable()))
        );
    }

    [Fact]
    public void ForeignKeysContainsCompositeForeignKey()
    {
        ISchema schema = new RelationalSchemaWithCompositeForeignKey();

        Assert.Contains(
            schema.ForeignKeys,
            f =>
                new ForeignKeyHash(f).SequenceEqual(
                    new ForeignKeyHash(new CompositeForeignKey())
                )
        );
    }
}
