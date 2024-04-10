namespace Shared.Domain.Events.Interfaces;

public interface IEvent
{
    public void Emit(string channel, string data);
}
