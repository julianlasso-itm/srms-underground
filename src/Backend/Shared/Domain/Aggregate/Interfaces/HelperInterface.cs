namespace Shared.Domain.Aggregate.Interfaces
{
  public interface IHelper<TRequest, TResponse>
  {
    public static abstract TResponse Execute(TRequest data);
  }
}
