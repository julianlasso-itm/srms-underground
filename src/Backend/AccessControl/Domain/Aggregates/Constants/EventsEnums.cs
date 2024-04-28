namespace AccessControl.Domain.Aggregates.Constants;

public abstract class EventsConst
{
    public const string Prefix = "AccessControl";
    public const string EventCredentialRegistered = "CredentialRegistered";
    public const string EventRoleRegistered = "RoleRegistered";
    public const string EventRoleUpdated = "RoleUpdated";
    public const string EventRoleDeleted = "RoleDeleted";
}
