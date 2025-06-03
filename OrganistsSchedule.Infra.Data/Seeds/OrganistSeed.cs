using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Enums;

namespace OrganistsSchedule.Infrastructure.Seeds;

public static class OrganistSeed
{
    private static ICollection<Organist> _organists =
    [
        new Organist("77781670000")
        {
            Id = 1,
            FullName = "Alzenir da Silva Souza",
            ShortName = "Alzenir",
            Level = OrganistsLevelEnum.HolyService
        },

        new Organist("65110149089")
        {
            Id = 2,
            FullName = "Jemima Oliveira Costa",
            ShortName = "Jemima",
            Level = OrganistsLevelEnum.HolyService
        },

        new Organist("45555585020")
        {
            Id = 3,
            FullName = "Valdete Pereira Lima",
            ShortName = "Valdete",
            Level = OrganistsLevelEnum.HolyService
        },

        new Organist("73552078061")
        {
            Id = 4,
            FullName = "Joana Martins Souza",
            ShortName = "Joana",
            Level = OrganistsLevelEnum.HolyService
        },

        new Organist("49709279017")
        {
            Id = 5,
            FullName = "Rosemari Alves Pinto",
            ShortName = "Rosemari",
            Level = OrganistsLevelEnum.HolyService
        },

        new Organist("02016533030")
        {
            Id = 6,
            FullName = "Camila Souza Lima",
            ShortName = "Camila",
            Level = OrganistsLevelEnum.HolyService
        },

        new Organist("33913742093")
        {
            Id = 7,
            FullName = "Priscila Andrade Melo",
            ShortName = "Priscila",
            Level = OrganistsLevelEnum.HolyService
        },

        new Organist("47085758074")
        {
            Id = 8,
            FullName = "Joanita Silva Costa",
            ShortName = "Joanita",
            Level = OrganistsLevelEnum.HolyService
        },

        new Organist("23333775000")
        {
            Id = 9,
            FullName = "Vanderleia Souza Lima",
            ShortName = "Vanderleia",
            Level = OrganistsLevelEnum.HolyService
        },

        new Organist("91112746030")
        {
            Id = 10,
            FullName = "Ana Paula Fernandes",
            ShortName = "Ana Paula",
            Level = OrganistsLevelEnum.HolyService | OrganistsLevelEnum.YouthMeeting,
        },

        new Organist("43417000068")
        {
            Id = 11,
            FullName = "Amanda Ribeiro Costa",
            ShortName = "Amanda",
            Level = OrganistsLevelEnum.HolyService
        },

        new Organist("87388819002")
        {
            Id = 12,
            FullName = "Hallen Martins Souza",
            ShortName = "Hallen",
            Level = OrganistsLevelEnum.HolyService
        },

        new Organist("84081083010")
        {
            Id = 13,
            FullName = "Solange Pereira Lima",
            ShortName = "Solange",
            Level = OrganistsLevelEnum.HolyService
        },

        new Organist("87771172040")
        {
            Id = 14,
            FullName = "Dinorá Souza Pinto",
            ShortName = "Dinorá",
            Level = OrganistsLevelEnum.HolyService
        },

        new Organist("26516790035")
        {
            Id = 15,
            FullName = "Rosangela Lima Costa",
            ShortName = "Rosangela",
            Level = OrganistsLevelEnum.HolyService
        },

        new Organist("77218566049")
        {
            Id = 16,
            FullName = "Sarah Martins Souza",
            ShortName = "Sarah",
            Level = OrganistsLevelEnum.HolyService
        },

        new Organist("65914758009")
        {
            Id = 17,
            FullName = "Luciana Pereira Lima",
            ShortName = "Luciana",
            Level = OrganistsLevelEnum.HolyService
        },

        new Organist("39464202068")
        {
            Id = 18,
            FullName = "Manoela Souza Pinto",
            ShortName = "Manoela",
            Level = OrganistsLevelEnum.YouthMeeting
        },

        new Organist("56503344040")
        {
            Id = 19,
            FullName = "Kauany Martins Souza",
            ShortName = "Kauany",
            Level = OrganistsLevelEnum.YouthMeeting
        },

        new Organist("16894804087")
        {
            Id = 20,
            FullName = "Mônica Pereira Lima",
            ShortName = "Mônica",
            Level = OrganistsLevelEnum.YouthMeeting
        }
    ];

    public static ICollection<Organist> Organists => _organists;
}