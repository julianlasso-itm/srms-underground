using Shared.Infrastructure.Events.Base;

namespace Profiles.Infrastructure.Messaging.Events
{
    public class RegisterSkillEvent: BaseEvent
    {
        private const string Uri = "localhost:6379";

        public RegisterSkillEvent()
            : base(Uri) { }
    }
}
