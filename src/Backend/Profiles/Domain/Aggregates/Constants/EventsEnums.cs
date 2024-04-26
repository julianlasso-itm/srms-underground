namespace Profiles.Domain.Aggregates.Constants;

public abstract class EventsConst
{
    public const string Prefix = "Profiles";

    public const string EventCountryRegistered = "CountryRegistered";
    public const string EventSkillRegistered = "SkillRegistered";
    public const string EventSkillDeleted = "SkillDeleted"; 
    public const string EventSkillUpdated = "SkillUpdated";
}
