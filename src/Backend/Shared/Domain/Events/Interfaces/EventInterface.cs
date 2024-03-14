namespace Shared.Domain.Events.Interfaces;

public interface IEvent
{
    public void Emit<TypeObject>(string eventName, TypeObject data);
}
