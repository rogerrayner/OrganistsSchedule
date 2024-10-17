using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Infrastructure.Seeds;

public static class CountrySeed
{

    private static ICollection<Country> _countries =
    [
        new Country
        {
            Id = 1,
            Name = "Brasil"
        }
    ];
    
    public static ICollection<Country> Countries => _countries;
    
}