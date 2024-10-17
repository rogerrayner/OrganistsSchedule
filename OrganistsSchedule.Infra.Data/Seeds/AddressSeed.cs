using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Infrastructure.Seeds;

public static class AddressSeed
{
    private static ICollection<Address> _individualAddresses = new List<Address>()
    {
        new Address { Id = 1, CongregationId = 1, CepId = 1, StreetNumber = 284 },
        new Address { Id = 2, CongregationId = 2, CepId = 2, StreetNumber = 583 },
        new Address { Id = 3, CongregationId = 3, CepId = 3, StreetNumber = 400 },
        new Address { Id = 4, CongregationId = 4, CepId = 4, StreetNumber = 1549 },
        new Address { Id = 5, CongregationId = 5, CepId = 5, StreetNumber = 44 },
        new Address { Id = 6, CongregationId = 6, CepId = 6, StreetNumber = 76 },
        new Address { Id = 7, CongregationId = 7, CepId = 7, StreetNumber = 340 },
        new Address { Id = 8, CongregationId = 8, CepId = 8, StreetNumber = 97 },
        new Address { Id = 9, CongregationId = 9, CepId = 9, StreetNumber = 75 },
        new Address { Id = 10, CongregationId = 10, CepId = 10, StreetNumber = 13491 },
        new Address { Id = 11, CongregationId = 11, CepId = 11, StreetNumber = 52 },
        new Address { Id = 12, CongregationId = 12, CepId = 12, StreetNumber = 1123 },
        new Address { Id = 13, CongregationId = 13, CepId = 13, StreetNumber = 10 },
        new Address { Id = 14, CongregationId = 14, CepId = 14, StreetNumber = 678 },
        new Address { Id = 15, CongregationId = 15, CepId = 15, StreetNumber = 112 },
        new Address { Id = 16, CongregationId = 16, CepId = 16, StreetNumber = 806 },
        new Address { Id = 17, CongregationId = 17, CepId = 17, StreetNumber = 352 },
        new Address { Id = 18, CongregationId = 18, CepId = 18, StreetNumber = 201 },
        new Address { Id = 19, CongregationId = 19, CepId = 19, StreetNumber = 452 },
        new Address { Id = 20, CongregationId = 20, CepId = 20, StreetNumber = 70 },
        new Address { Id = 21, CongregationId = 21, CepId = 21, StreetNumber = 337 },
        new Address { Id = 22, CongregationId = 22, CepId = 22, StreetNumber = 140 },
        new Address { Id = 23, CongregationId = 23, CepId = 23, StreetNumber = 129 },
        new Address { Id = 24, CongregationId = 24, CepId = 24, StreetNumber = 228 },
        new Address { Id = 25, CongregationId = 25, CepId = 25, StreetNumber = 1445 },
        new Address { Id = 26, CongregationId = 26, CepId = 26, StreetNumber = 1415 },
        new Address { Id = 27, CongregationId = 27, CepId = 27, StreetNumber = 235 },
        new Address { Id = 28, CongregationId = 28, CepId = 28, StreetNumber = 699 },
        new Address { Id = 29, CongregationId = 29, CepId = 29, StreetNumber = 252 },
        new Address { Id = 30, CongregationId = 30, CepId = 30, StreetNumber = 63 },
        new Address { Id = 31, CongregationId = 31, CepId = 31, StreetNumber = 690 },
        new Address { Id = 32, CongregationId = 32, CepId = 32, StreetNumber = 177 },
        new Address { Id = 33, CongregationId = 33, CepId = 33, StreetNumber = 55 },
        new Address { Id = 34, CongregationId = 34, CepId = 34, StreetNumber = 42 },
        new Address { Id = 35, CongregationId = 35, CepId = 35, StreetNumber = 415 },
        new Address { Id = 36, CongregationId = 36, CepId = 36, StreetNumber = 599 }
    };
    
    public static ICollection<Address> IndividualAddresses => _individualAddresses;
}