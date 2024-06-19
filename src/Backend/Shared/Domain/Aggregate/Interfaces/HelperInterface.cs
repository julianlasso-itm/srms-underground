using Shared.Common.Bases;

namespace Shared.Domain.Aggregate.Interfaces
{
  public interface IHelper<TRequest, TResponse>
  {
    public static abstract Result<TResponse> Execute(TRequest data);
  }
}
