using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.ForeignKeys;
using Pure.RelationalSchema.Samples.Schemas;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Schemas;

public sealed record RelationalSchemaWithSelfReferencingTableTests
{
    [Fact]
    public void NameIsSchemaWithSelfReferencingTable()
    {
        ISchema schema = new RelationalSchemaWithSelfReferencingTable();

        Assert.Equal("schema_with_self_referencing_table", schema.Name.TextValue);
    }

    [Fact]
    public void TablesCountIs1()
    {
        ISchema schema = new RelationalSchemaWithSelfReferencingTable();

        _ = Assert.Single(schema.Tables);
    }

    [Fact]
    public void ForeignKeysCountIs1()
    {
        ISchema schema = new RelationalSchemaWithSelfReferencingTable();

        _ = Assert.Single(schema.ForeignKeys);
    }

    [Fact]
    public void TablesContainsEmployeesTable()
    {
        ISchema schema = new RelationalSchemaWithSelfReferencingTable();

        Assert.Contains(
            schema.Tables,
            t => new TableHash(t).SequenceEqual(new TableHash(new EmployeesTable()))
        );
    }

    [Fact]
    public void ForeignKeysContainsSelfReferencingForeignKey()
    {
        ISchema schema = new RelationalSchemaWithSelfReferencingTable();

        Assert.Contains(
            schema.ForeignKeys,
            f =>
                new ForeignKeyHash(f).SequenceEqual(
                    new ForeignKeyHash(new SelfReferencingForeignKey())
                )
        );
    }
}
