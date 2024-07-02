namespace Shared.Infrastructure.ProtocolBuffers.Interfaces
{
  public interface IResultProtoBuf<Type>
  {
    Type Data { get; }
    bool Success { get; init; }
    bool IsFailure { get; }
    string? ErrorCode { get; init; }
    string? ErrorMessage { get; init; }
    string? ErrorDetails { get; init; }
  }
}
