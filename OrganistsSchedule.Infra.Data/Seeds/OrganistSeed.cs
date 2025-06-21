using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Enums;

namespace OrganistsSchedule.Infrastructure.Seeds;

public static class OrganistSeed
{
    private static ICollection<Organist> _organists =
    [
        new Organist()
        {
            Id = 1,
            FullName = "Alzenir da Silva Souza",
            ShortName = "Alzenir",
            Level = OrganistsLevelEnum.HolyService,
            CepId = 3
        },

        new Organist()
        {
            Id = 2,
            FullName = "Jemima Oliveira Costa",
            ShortName = "Jemima",
            Level = OrganistsLevelEnum.HolyService,
            CepId = 3
        },

        new Organist()
        {
            Id = 3,
            FullName = "Valdete Pereira Lima",
            ShortName = "Valdete",
            Level = OrganistsLevelEnum.HolyService,
            CepId = 3
        },

        new Organist()
        {
            Id = 4,
            FullName = "Joana Martins Souza",
            ShortName = "Joana",
            Level = OrganistsLevelEnum.HolyService,
            CepId = 3
        },

        new Organist()
        {
            Id = 5,
            FullName = "Rosemari Alves Pinto",
            ShortName = "Rosemari",
            Level = OrganistsLevelEnum.HolyService,
            CepId = 3
        },

        new Organist()
        {
            Id = 6,
            FullName = "Camila Souza Lima",
            ShortName = "Camila",
            Level = OrganistsLevelEnum.HolyService,
            CepId = 3
        },

        new Organist()
        {
            Id = 7,
            FullName = "Priscila Andrade Melo",
            ShortName = "Priscila",
            Level = OrganistsLevelEnum.HolyService,
            CepId = 3
        },

        new Organist()
        {
            Id = 8,
            FullName = "Joanita Silva Costa",
            ShortName = "Joanita",
            Level = OrganistsLevelEnum.HolyService,
            CepId = 3
        },

        new Organist()
        {
            Id = 9,
            FullName = "Vanderleia Souza Lima",
            ShortName = "Vanderleia",
            Level = OrganistsLevelEnum.HolyService,
            CepId = 3
        },

        new Organist()
        {
            Id = 10,
            FullName = "Ana Paula Fernandes",
            ShortName = "Ana Paula",
            Level = OrganistsLevelEnum.HolyService | OrganistsLevelEnum.YouthMeeting,
            CepId = 3
        },

        new Organist()
        {
            Id = 11,
            FullName = "Amanda Ribeiro Costa",
            ShortName = "Amanda",
            Level = OrganistsLevelEnum.HolyService,
            CepId = 3
        },

        new Organist()
        {
            Id = 12,
            FullName = "Hallen Martins Souza",
            ShortName = "Hallen",
            Level = OrganistsLevelEnum.HolyService,
            CepId = 3
        },

        new Organist()
        {
            Id = 13,
            FullName = "Solange Pereira Lima",
            ShortName = "Solange",
            Level = OrganistsLevelEnum.HolyService,
            CepId = 3
        },

        new Organist()
        {
            Id = 14,
            FullName = "Dinorá Souza Pinto",
            ShortName = "Dinorá",
            Level = OrganistsLevelEnum.HolyService,
            CepId = 3
        },

        new Organist()
        {
            Id = 15,
            FullName = "Rosangela Lima Costa",
            ShortName = "Rosangela",
            Level = OrganistsLevelEnum.HolyService,
            CepId = 3
        },

        new Organist()
        {
            Id = 16,
            FullName = "Sarah Martins Souza",
            ShortName = "Sarah",
            Level = OrganistsLevelEnum.HolyService,
            CepId = 3
        },

        new Organist()
        {
            Id = 17,
            FullName = "Luciana Pereira Lima",
            ShortName = "Luciana",
            Level = OrganistsLevelEnum.HolyService,
            CepId = 3
        },

        new Organist()
        {
            Id = 18,
            FullName = "Manoela Souza Pinto",
            ShortName = "Manoela",
            Level = OrganistsLevelEnum.YouthMeeting,
            CepId = 3
        },

        new Organist()
        {
            Id = 19,
            FullName = "Kauany Martins Souza",
            ShortName = "Kauany",
            Level = OrganistsLevelEnum.YouthMeeting,
            CepId = 3
        },

        new Organist()
        {
            Id = 20,
            FullName = "Mônica Pereira Lima",
            ShortName = "Mônica",
            Level = OrganistsLevelEnum.YouthMeeting,
            CepId = 3
        }
    ];

    public static ICollection<Organist> Organists => _organists;
}