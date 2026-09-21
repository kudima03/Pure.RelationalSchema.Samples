using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Schemas;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Schemas;

public sealed record RefsRelationalSchemaTests
{
    [Fact]
    public void NameIsRefs()
    {
        ISchema schema = new RefsRelationalSchema();

        Assert.Equal("refs", schema.Name.TextValue);
    }

    [Fact]
    public void TablesCountIs1()
    {
        ISchema schema = new RefsRelationalSchema();

        _ = Assert.Single(schema.Tables);
    }

    [Fact]
    public void ForeignKeysIsEmpty()
    {
        ISchema schema = new RefsRelationalSchema();

        Assert.Empty(schema.ForeignKeys);
    }

    [Fact]
    public void TablesContainsStatusesTable()
    {
        ISchema schema = new RefsRelationalSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new StatusesTable()))
        );
    }
}
