namespace AccessControl.Domain.Aggregates.Constants
{
  public abstract class EventsConst
  {
    public const string Prefix = "AccessControl";
    public const string EventCredentialRegistered = "CredentialRegistered";
    public const string EventCredentialActivated = "CredentialActivated";
    public const string EventCredentialUpdated = "CredentialUpdated";
    public const string EventRoleRegistered = "RoleRegistered";
    public const string EventRoleUpdated = "RoleUpdated";
    public const string EventRoleDeleted = "RoleDeleted";
  }
}
