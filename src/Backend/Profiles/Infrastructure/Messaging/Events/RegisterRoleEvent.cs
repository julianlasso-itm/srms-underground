using Shared.Infrastructure.Events.Base;

namespace Profiles.Infrastructure.Messaging.Events
{
    public class RegisterRoleEvent : BaseEvent
    {
        private const string Uri = "localhost:6379";

        public RegisterRoleEvent()
            : base(Uri) { }
    }
}
