namespace Profiles.Domain.Aggregates.Constants;

public abstract class EventsConst
{
    public const string Prefix = "Profiles";
    public const string EventCountryRegistered = "CountryRegistered";
    public const string EventCountryUpdated = "CountryUpdated";
    public const string EventCountryDeleted = "CountryDeleted";
    public const string EventProvinceRegistered = "ProvinceRegistered";
    public const string EventProvinceUpdated = "ProvinceUpdated";
    public const string EventProvinceDeleted = "ProvinceDeleted";
    public const string EventCityRegistered = "CityRegistered";
    public const string EventCityUpdated = "CityUpdated";
    public const string EventCityDeleted = "CityDeleted";
}
