namespace Shared.Domain.Aggregate.Interfaces;

public interface IAggregate
{
    public void EmitEvent(string channel, string data);
}
