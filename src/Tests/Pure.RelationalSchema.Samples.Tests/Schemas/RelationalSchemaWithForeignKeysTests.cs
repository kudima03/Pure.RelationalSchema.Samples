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
    public void TablesCountIs5()
    {
        ISchema schema = new RelationalSchemaWithForeignKeys();

        Assert.Equal(5, schema.Tables.Count());
    }

    [Fact]
    public void ForeignKeysCountIs6()
    {
        ISchema schema = new RelationalSchemaWithForeignKeys();

        Assert.Equal(6, schema.ForeignKeys.Count());
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
    public void TablesContainsProductsTable()
    {
        ISchema schema = new RelationalSchemaWithForeignKeys();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new ProductsTable()))
        );
    }

    [Fact]
    public void TablesContainsOrderItemsTable()
    {
        ISchema schema = new RelationalSchemaWithForeignKeys();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new OrderItemsTable()))
        );
    }

    [Fact]
    public void TablesContainsEmployeesTable()
    {
        ISchema schema = new RelationalSchemaWithForeignKeys();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new EmployeesTable()))
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

    [Fact]
    public void ForeignKeysContainsCompositeForeignKey()
    {
        ISchema schema = new RelationalSchemaWithForeignKeys();

        Assert.Contains(
            schema.ForeignKeys,
            f =>
                new ForeignKeyHash(f).SequenceEqual(
                    new ForeignKeyHash(new CompositeForeignKey())
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsOrderItemsToProductsForeignKey()
    {
        ISchema schema = new RelationalSchemaWithForeignKeys();

        Assert.Contains(
            schema.ForeignKeys,
            f =>
                new ForeignKeyHash(f).SequenceEqual(
                    new ForeignKeyHash(new OrderItemsToProductsForeignKey())
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsSelfReferencingForeignKey()
    {
        ISchema schema = new RelationalSchemaWithForeignKeys();

        Assert.Contains(
            schema.ForeignKeys,
            f =>
                new ForeignKeyHash(f).SequenceEqual(
                    new ForeignKeyHash(new SelfReferencingForeignKey())
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsEmployeesToUsersForeignKey()
    {
        ISchema schema = new RelationalSchemaWithForeignKeys();

        Assert.Contains(
            schema.ForeignKeys,
            f =>
                new ForeignKeyHash(f).SequenceEqual(
                    new ForeignKeyHash(new EmployeesToUsersForeignKey())
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsOrdersToStatusesForeignKey()
    {
        ISchema schema = new RelationalSchemaWithForeignKeys();

        Assert.Contains(
            schema.ForeignKeys,
            f =>
                new ForeignKeyHash(f).SequenceEqual(
                    new ForeignKeyHash(new OrdersToStatusesForeignKey())
                )
        );
    }
}
