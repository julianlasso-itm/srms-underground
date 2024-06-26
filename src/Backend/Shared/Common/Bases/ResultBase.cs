using System.Runtime.Serialization;
using Shared.Common.Enums;

namespace Shared.Common.Bases
{
  [DataContract]
  public class ResultBase
  {
    [DataMember(Order = 1)]
    public bool IsSuccess { get; set; }

    [DataMember(Order = 2)]
    public bool IsFailure => !IsSuccess;

    [DataMember(Order = 3)]
    public string? Message { get; set; }

    [DataMember(Order = 4)]
    public ErrorEnum? Code { get; set; }

    [DataMember(Order = 5)]
    public object? Details { get; set; }
  }

  [DataContract]
  public class Result<Type> : ResultBase
  {
    [DataMember(Order = 1)]
    public Type Data { get; set; }
  }
}
