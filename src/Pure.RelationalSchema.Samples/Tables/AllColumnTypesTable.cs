using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Columns;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Tables;

public sealed record AllColumnTypesTable : ITable
{
    public IString Name => new String("all_column_types_table");

    public IEnumerable<IColumn> Columns =>
        [
            new IdColumn(),
            new NameColumn(),
            new AgeColumn(),
            new QuantityColumn(),
            new PriceColumn(),
            new IsActiveColumn(),
            new BirthDateColumn(),
            new StartTimeColumn(),
            new CreatedAtColumn(),
            new EmptyNameColumn(),
        ];

    public IEnumerable<IIndex> Indexes => [];
}
