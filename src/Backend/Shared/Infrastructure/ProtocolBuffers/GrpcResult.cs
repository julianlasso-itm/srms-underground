using ProtoBuf;
using ProtoBuf.Meta;
using Shared.Common.Enums;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace Shared.Infrastructure.ProtocolBuffers
{
  [ProtoContract]
  [ProtoInclude(1, typeof(GrpcResult<RegisterUserResponse>))]
  public abstract class GrpcResultBase
  {
    static readonly object s_ConfigurationLock = new();
    static bool s_IsAlreadyConfigured;

    public static void ConfigureTypes()
    {
      lock (s_ConfigurationLock)
      {
        if (s_IsAlreadyConfigured)
        {
          return;
        }
        s_IsAlreadyConfigured = true;
        var model = RuntimeTypeModel.Default;
        model[typeof(GrpcResult<RegisterUserResponse>)].AddSubType(1, typeof(RegisterUserResponse));
      }
    }
  }

  [ProtoContract]
  public class GrpcResult<Type> : GrpcResultBase
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

    public static GrpcResult<Type> Success(Type data)
    {
      return new GrpcResult<Type> { Data = data, IsSuccess = true };
    }

    public static GrpcResult<Type> Success()
    {
      return new GrpcResult<Type> { IsSuccess = true };
    }

    public static GrpcResult<Type> Failure(string message, ErrorEnum code, object? details = null)
    {
      return new GrpcResult<Type>
      {
        IsSuccess = false,
        Message = message,
        Code = code,
        Details = details
      };
    }

    public static GrpcResult<Type> Failure(string message, ErrorEnum code)
    {
      return new GrpcResult<Type>
      {
        IsSuccess = false,
        Message = message,
        Code = code
      };
    }
  }
}
