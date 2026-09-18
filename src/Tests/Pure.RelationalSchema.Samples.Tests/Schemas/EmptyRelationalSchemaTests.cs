using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.Samples.Schemas;

namespace Pure.RelationalSchema.Samples.Tests.Schemas;

public sealed record EmptyRelationalSchemaTests
{
    [Fact]
    public void NameIsEmptySchema()
    {
        ISchema schema = new EmptyRelationalSchema();

        Assert.Equal("empty_schema", schema.Name.TextValue);
    }

    [Fact]
    public void TablesIsEmpty()
    {
        ISchema schema = new EmptyRelationalSchema();

        Assert.Empty(schema.Tables);
    }

    [Fact]
    public void ForeignKeysIsEmpty()
    {
        ISchema schema = new EmptyRelationalSchema();

        Assert.Empty(schema.ForeignKeys);
    }
}
