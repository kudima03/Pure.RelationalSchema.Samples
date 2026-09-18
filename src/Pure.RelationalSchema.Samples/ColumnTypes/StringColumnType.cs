using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.ColumnType;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.ColumnTypes;

public sealed record StringColumnType : IColumnType
{
    public IString Name => new String("string");
}
