using ProtoBuf;
using Shared.Common.Enums;

namespace Shared.Common.Bases
{
  [ProtoContract]
  public class Result<Type>
  {
    [ProtoMember(1)]
    public bool IsSuccess { get; set; }

    [ProtoMember(2)]
    public bool IsFailure => !IsSuccess;

    [ProtoMember(3, IsRequired = false)]
    public string? Message { get; set; }

    [ProtoMember(4, IsRequired = false)]
    public ErrorEnum? Code { get; set; }

    [ProtoMember(5, IsRequired = false)]
    public object? Details { get; set; }

    [ProtoMember(6, IsRequired = false)]
    public Type Data { get; set; }
  }
}
