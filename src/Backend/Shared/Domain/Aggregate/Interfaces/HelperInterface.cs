namespace Shared.Domain.Aggregate.Interfaces;

public interface IHelper<TRequest,TResponse>
{
    public abstract static TResponse Execute(TRequest data);
}
