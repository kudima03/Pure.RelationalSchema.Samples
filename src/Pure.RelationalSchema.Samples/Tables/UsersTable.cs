using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Tables;

public sealed record UsersTable : ITable
{
    public IString Name => new String("users");

    public IEnumerable<IColumn> Columns =>
        [
            new UserIdColumn(),
            new UserTenantIdColumn(),
            new UserNameColumn(),
            new SignupDateColumn(),
            new UserActiveColumn(),
            new LastLoginColumn(),
            new UserAgeColumn(),
            new ShiftStartColumn(),
            new UserScoreColumn(),
            new UserPrecisionValueColumn(),
            new UserEdgeDateColumn(),
            new UserEdgeDateTimeColumn(),
            new UserEdgeTimeColumn(),
        ];

    public IEnumerable<IIndex> Indexes => [new UsersPrimaryIndex(), new UsersNameIndex()];
}
