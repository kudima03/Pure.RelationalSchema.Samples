using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Schemas;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Schemas;

public sealed record RelationalSchemaWithIndexesTests
{
    [Fact]
    public void NameIsSchemaWithIndexes()
    {
        ISchema schema = new RelationalSchemaWithIndexes();

        Assert.Equal("schema_with_indexes", schema.Name.TextValue);
    }

    [Fact]
    public void TablesCountIs2()
    {
        ISchema schema = new RelationalSchemaWithIndexes();

        Assert.Equal(2, schema.Tables.Count());
    }

    [Fact]
    public void ForeignKeysIsEmpty()
    {
        ISchema schema = new RelationalSchemaWithIndexes();

        Assert.Empty(schema.ForeignKeys);
    }

    [Fact]
    public void TablesContainsTableWithSingleIndex()
    {
        ISchema schema = new RelationalSchemaWithIndexes();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new TableWithSingleIndex()))
        );
    }

    [Fact]
    public void TablesContainsTableWithIndexes()
    {
        ISchema schema = new RelationalSchemaWithIndexes();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new TableWithIndexes()))
        );
    }
}
