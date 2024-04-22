using Shared.Infrastructure.Events.Base;

namespace AccessControl.Infrastructure.Messaging.Events;

public class RegisterUserEvent : BaseEvent
{
    private const string Uri = "localhost:6379";

    public RegisterUserEvent()
        : base(Uri) { }
}
