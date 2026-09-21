using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.Samples.Schemas;

namespace Pure.RelationalSchema.Samples.Tests.Schemas;

public sealed record CrossDomainAmbiguityIsConfinedToFullSchemaTests
{
    private static readonly IEnumerable<string> AmbiguousColumnNames =
    [
        "id",
        "name",
        "created_at",
        "tenant_id",
    ];

    private static readonly IEnumerable<string> MultiplyOccurringColumnNames =
    [
        "id",
        "name",
        "created_at",
    ];

    [Fact]
    public void MultiplyOccurringColumnsOccurOnMultipleFullSchemaRelations()
    {
        ISchema schema = new FullRelationalSchema();
        IEnumerable<string> names = schema
            .Tables.SelectMany(t => t.Columns)
            .Select(c => c.Name.TextValue);

        Assert.All(
            MultiplyOccurringColumnNames,
            name => Assert.True(names.Count(n => n == name) > 1)
        );
    }

    [Fact]
    public void TenantIdOccursExactlyOnceInFullSchema()
    {
        ISchema schema = new FullRelationalSchema();
        IEnumerable<string> names = schema
            .Tables.SelectMany(t => t.Columns)
            .Select(c => c.Name.TextValue);

        Assert.Equal(1, names.Count(n => n == "tenant_id"));
    }

    [Fact]
    public void AmbiguousColumnsAreAbsentFromDomainSchemas()
    {
        IEnumerable<ISchema> domainSchemas =
        [
            new RelationalSchemaWithForeignKeys(),
            new AuditRelationalSchema(),
            new RefsRelationalSchema(),
        ];
        IEnumerable<string> names = domainSchemas
            .SelectMany(s => s.Tables)
            .SelectMany(t => t.Columns)
            .Select(c => c.Name.TextValue);

        Assert.All(AmbiguousColumnNames, name => Assert.DoesNotContain(name, names));
    }
}
