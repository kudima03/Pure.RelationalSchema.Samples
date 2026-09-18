using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.ForeignKeys;
using Pure.RelationalSchema.Samples.Schemas;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Schemas;

public sealed record FullRelationalSchemaTests
{
    [Fact]
    public void NameIsFullSchema()
    {
        ISchema schema = new FullRelationalSchema();

        Assert.Equal("full_schema", schema.Name.TextValue);
    }

    [Fact]
    public void TablesCountIs11()
    {
        ISchema schema = new FullRelationalSchema();

        Assert.Equal(11, schema.Tables.Count());
    }

    [Fact]
    public void ForeignKeysCountIs5()
    {
        ISchema schema = new FullRelationalSchema();

        Assert.Equal(5, schema.ForeignKeys.Count());
    }

    [Fact]
    public void TablesContainsEmptyTable()
    {
        ISchema schema = new FullRelationalSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new EmptyTable()))
        );
    }

    [Fact]
    public void TablesContainsSingleColumnTable()
    {
        ISchema schema = new FullRelationalSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new SingleColumnTable()))
        );
    }

    [Fact]
    public void TablesContainsTableWithoutIndexes()
    {
        ISchema schema = new FullRelationalSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new TableWithoutIndexes()))
        );
    }

    [Fact]
    public void TablesContainsTableWithSingleIndex()
    {
        ISchema schema = new FullRelationalSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new TableWithSingleIndex()))
        );
    }

    [Fact]
    public void TablesContainsTableWithIndexes()
    {
        ISchema schema = new FullRelationalSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new TableWithIndexes()))
        );
    }

    [Fact]
    public void TablesContainsAllColumnTypesTable()
    {
        ISchema schema = new FullRelationalSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new AllColumnTypesTable()))
        );
    }

    [Fact]
    public void TablesContainsUsersTable()
    {
        ISchema schema = new FullRelationalSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new UsersTable()))
        );
    }

    [Fact]
    public void TablesContainsOrdersTable()
    {
        ISchema schema = new FullRelationalSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new OrdersTable()))
        );
    }

    [Fact]
    public void TablesContainsProductsTable()
    {
        ISchema schema = new FullRelationalSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new ProductsTable()))
        );
    }

    [Fact]
    public void TablesContainsOrderItemsTable()
    {
        ISchema schema = new FullRelationalSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new OrderItemsTable()))
        );
    }

    [Fact]
    public void TablesContainsEmployeesTable()
    {
        ISchema schema = new FullRelationalSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new EmployeesTable()))
        );
    }

    [Fact]
    public void ForeignKeysContainsEmptyColumnsForeignKey()
    {
        ISchema schema = new FullRelationalSchema();

        Assert.Contains(
            schema.ForeignKeys,
            f =>
                new ForeignKeyHash(f).SequenceEqual(
                    new ForeignKeyHash(new EmptyColumnsForeignKey())
                )
        );
    }

    [Fact]
    public void ForeignKeysContainsSingleColumnForeignKey()
    {
        ISchema schema = new FullRelationalSchema();

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
        ISchema schema = new FullRelationalSchema();

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
        ISchema schema = new FullRelationalSchema();

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
        ISchema schema = new FullRelationalSchema();

        Assert.Contains(
            schema.ForeignKeys,
            f =>
                new ForeignKeyHash(f).SequenceEqual(
                    new ForeignKeyHash(new SelfReferencingForeignKey())
                )
        );
    }
}
