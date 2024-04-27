namespace Shared.Domain.Aggregate.Interfaces;

public interface IAggregateRoot
{
    public void EmitEvent(string channel, string data);
}
