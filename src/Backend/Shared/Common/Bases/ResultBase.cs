using ProtoBuf;
using Shared.Common.Enums;

namespace Shared.Common.Bases
{
  [ProtoContract]
  // [ProtoInclude(1, typeof(Result<RegisterUserResponse>), DataFormat = DataFormat.Group)]
  public class Result<Type>
  {
    [ProtoMember(2)]
    public Type Data { get; set; }

    [ProtoMember(3)]
    public bool IsSuccess { get; set; }

    [ProtoMember(4)]
    public bool IsFailure => !IsSuccess;

    [ProtoMember(5, IsRequired = false)]
    public string? Message { get; set; }

    [ProtoMember(6, IsRequired = false)]
    public ErrorEnum? Code { get; set; }

    [ProtoMember(7, IsRequired = false)]
    public object? Details { get; set; }
  }
}
