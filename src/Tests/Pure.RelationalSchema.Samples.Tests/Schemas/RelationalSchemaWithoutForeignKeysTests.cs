using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Schemas;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Schemas;

public sealed record RelationalSchemaWithoutForeignKeysTests
{
    [Fact]
    public void NameIsSchemaWithoutForeignKeys()
    {
        ISchema schema = new RelationalSchemaWithoutForeignKeys();

        Assert.Equal("schema_without_foreign_keys", schema.Name.TextValue);
    }

    [Fact]
    public void TablesCountIs3()
    {
        ISchema schema = new RelationalSchemaWithoutForeignKeys();

        Assert.Equal(3, schema.Tables.Count());
    }

    [Fact]
    public void ForeignKeysIsEmpty()
    {
        ISchema schema = new RelationalSchemaWithoutForeignKeys();

        Assert.Empty(schema.ForeignKeys);
    }

    [Fact]
    public void TablesContainsEmptyTable()
    {
        ISchema schema = new RelationalSchemaWithoutForeignKeys();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new EmptyTable()))
        );
    }

    [Fact]
    public void TablesContainsSingleColumnTable()
    {
        ISchema schema = new RelationalSchemaWithoutForeignKeys();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new SingleColumnTable()))
        );
    }

    [Fact]
    public void TablesContainsTableWithoutIndexes()
    {
        ISchema schema = new RelationalSchemaWithoutForeignKeys();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new TableWithoutIndexes()))
        );
    }
}
