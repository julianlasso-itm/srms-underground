using System.Runtime.Serialization;
using Shared.Common.Enums;

namespace Shared.Common.Bases
{
  [DataContract]
  public abstract class Result<Type>
  {
    [DataMember(Order = 1)]
    public Type Data { get; set; }

    [DataMember(Order = 2)]
    public bool IsSuccess { get; set; }

    [DataMember(Order = 3)]
    public bool IsFailure => !IsSuccess;

    [DataMember(Order = 4, IsRequired = false)]
    public string? Message { get; set; }

    [DataMember(Order = 5, IsRequired = false)]
    public ErrorEnum? Code { get; set; }

    [DataMember(Order = 6, IsRequired = false)]
    public object? Details { get; set; }
  }
}
