using Shared.Infrastructure.Events.Base;

namespace Profiles.Infrastructure.Messaging.Events
{
    public class RegisterProfessionalEvent : BaseEvent
    {
        private const string Uri = "localhost:6379";

        public RegisterProfessionalEvent()
            : base(Uri) { }
    }
}

