using Pure.Primitives.Abstractions.String;
using Pure.Primitives.String;
using Pure.RelationalSchema.Abstractions.ColumnType;

namespace Pure.RelationalSchema.Samples.ColumnTypes;

public sealed record EmptyNameColumnType : IColumnType
{
    public IString Name => new EmptyString();
}
