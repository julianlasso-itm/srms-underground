namespace Shared.Common.Bases
{
  public abstract class Result(bool isSuccess)
  {
    public bool IsSuccess { get; protected set; } = isSuccess;
    public bool IsFailure => !IsSuccess;
  }
}
