using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.ForeignKeys;
using Pure.RelationalSchema.Samples.Schemas;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Schemas;

public sealed record AuditRelationalSchemaTests
{
    [Fact]
    public void NameIsAudit()
    {
        ISchema schema = new AuditRelationalSchema();

        Assert.Equal("audit", schema.Name.TextValue);
    }

    [Fact]
    public void TablesCountIs1()
    {
        ISchema schema = new AuditRelationalSchema();

        _ = Assert.Single(schema.Tables);
    }

    [Fact]
    public void ForeignKeysCountIs1()
    {
        ISchema schema = new AuditRelationalSchema();

        _ = Assert.Single(schema.ForeignKeys);
    }

    [Fact]
    public void TablesContainsLoginsTable()
    {
        ISchema schema = new AuditRelationalSchema();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new LoginsTable()))
        );
    }

    [Fact]
    public void ForeignKeysContainsLoginsToUsersForeignKey()
    {
        ISchema schema = new AuditRelationalSchema();

        Assert.Contains(
            schema.ForeignKeys,
            f =>
                new ForeignKeyHash(f).SequenceEqual(
                    new ForeignKeyHash(new LoginsToUsersForeignKey())
                )
        );
    }
}
