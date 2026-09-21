using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Columns;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Tables;

public sealed record LoginsTable : ITable
{
    public IString Name => new String("logins");

    public IEnumerable<IColumn> Columns =>
        [new LoginIdColumn(), new LoginUserIdColumn(), new LoginAtColumn()];

    public IEnumerable<IIndex> Indexes => [];
}
