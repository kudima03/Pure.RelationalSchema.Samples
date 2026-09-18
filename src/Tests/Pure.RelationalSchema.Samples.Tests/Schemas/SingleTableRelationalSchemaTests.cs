using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Schemas;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Schemas;

public sealed record SingleTableRelationalSchemaTests
{
    [Fact]
    public void NameIsSingleTableSchema()
    {
        ISchema schema = new SingleTableRelationalSchema();

        Assert.Equal("single_table_schema", schema.Name.TextValue);
    }

    [Fact]
    public void TablesCountIs1()
    {
        ISchema schema = new SingleTableRelationalSchema();

        _ = Assert.Single(schema.Tables);
    }

    [Fact]
    public void ForeignKeysIsEmpty()
    {
        ISchema schema = new SingleTableRelationalSchema();

        Assert.Empty(schema.ForeignKeys);
    }

    [Fact]
    public void TablesContainsSingleColumnTable()
    {
        ISchema schema = new SingleTableRelationalSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new SingleColumnTable()))
        );
    }
}
