using Shared.Common.Bases;

namespace Shared.Domain.Aggregate.Interfaces
{
  public interface IHelper<TRequest>
  {
    public static abstract Result Execute(TRequest data);
  }
}
