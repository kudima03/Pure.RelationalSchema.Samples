using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Schemas;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Schemas;

public sealed record RelationalSchemaWithAllColumnTypesTests
{
    [Fact]
    public void NameIsSchemaWithAllColumnTypes()
    {
        ISchema schema = new RelationalSchemaWithAllColumnTypes();

        Assert.Equal("schema_with_all_column_types", schema.Name.TextValue);
    }

    [Fact]
    public void TablesCountIs1()
    {
        ISchema schema = new RelationalSchemaWithAllColumnTypes();

        _ = Assert.Single(schema.Tables);
    }

    [Fact]
    public void ForeignKeysIsEmpty()
    {
        ISchema schema = new RelationalSchemaWithAllColumnTypes();

        Assert.Empty(schema.ForeignKeys);
    }

    [Fact]
    public void TablesContainsAllColumnTypesTable()
    {
        ISchema schema = new RelationalSchemaWithAllColumnTypes();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new AllColumnTypesTable()))
        );
    }
}
