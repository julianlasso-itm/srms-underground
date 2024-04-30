using Shared.Infrastructure.Events.Base;

namespace Shared.Infrastructure.Events
{
  public class SharedEventHandler : BaseEvent
  {
    private const string Uri = "localhost:6379";

    public SharedEventHandler()
      : base(Uri) { }
  }
}
