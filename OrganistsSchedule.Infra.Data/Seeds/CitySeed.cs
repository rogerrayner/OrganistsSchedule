using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Infrastructure.Seeds;

public static class CitySeed
{

    private static ICollection<City> _cities =
    [
        new City
        {
            Id = 1,
            Name = "Joinville",
            CountryId = 1,
            Country = null
        }
    ];
    
    public static ICollection<City> Cities => _cities;
    
}