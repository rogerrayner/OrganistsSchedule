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
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 1
        },

        new Organist("65110149089")
        {
            Id = 2,
            FullName = "Jemima Oliveira Costa",
            ShortName = "Jemima",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 2
        },

        new Organist("45555585020")
        {
            Id = 3,
            FullName = "Valdete Pereira Lima",
            ShortName = "Valdete",
            ServicesDaysOfWeek = [DayOfWeek.Tuesday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 3
        },

        new Organist("73552078061")
        {
            Id = 4,
            FullName = "Joana Martins Souza",
            ShortName = "Joana",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 4
        },

        new Organist("49709279017")
        {
            Id = 5,
            FullName = "Rosemari Alves Pinto",
            ShortName = "Rosemari",
            ServicesDaysOfWeek = [DayOfWeek.Tuesday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 5
        },

        new Organist("02016533030")
        {
            Id = 6,
            FullName = "Camila Souza Lima",
            ShortName = "Camila",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 6
        },

        new Organist("33913742093")
        {
            Id = 7,
            FullName = "Priscila Andrade Melo",
            ShortName = "Priscila",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 7
        },

        new Organist("47085758074")
        {
            Id = 8,
            FullName = "Joanita Silva Costa",
            ShortName = "Joanita",
            ServicesDaysOfWeek = [DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 8
        },

        new Organist("23333775000")
        {
            Id = 9,
            FullName = "Vanderleia Souza Lima",
            ShortName = "Vanderleia",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 9
        },

        new Organist("91112746030")
        {
            Id = 10,
            FullName = "Ana Paula Fernandes",
            ShortName = "Ana Paula",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService | OrganistsLevelEnum.YouthMeeting,
            Sequence = 10,
        },

        new Organist("43417000068")
        {
            Id = 11,
            FullName = "Amanda Ribeiro Costa",
            ShortName = "Amanda",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 11
        },

        new Organist("87388819002")
        {
            Id = 12,
            FullName = "Hallen Martins Souza",
            ShortName = "Hallen",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 12
        },

        new Organist("84081083010")
        {
            Id = 13,
            FullName = "Solange Pereira Lima",
            ShortName = "Solange",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 13
        },

        new Organist("87771172040")
        {
            Id = 14,
            FullName = "Dinorá Souza Pinto",
            ShortName = "Dinorá",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 14
        },

        new Organist("26516790035")
        {
            Id = 15,
            FullName = "Rosangela Lima Costa",
            ShortName = "Rosangela",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 15
        },

        new Organist("77218566049")
        {
            Id = 16,
            FullName = "Sarah Martins Souza",
            ShortName = "Sarah",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 16
        },

        new Organist("65914758009")
        {
            Id = 17,
            FullName = "Luciana Pereira Lima",
            ShortName = "Luciana",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 17
        },

        new Organist("39464202068")
        {
            Id = 18,
            FullName = "Manoela Souza Pinto",
            ShortName = "Manoela",
            ServicesDaysOfWeek = [DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.YouthMeeting,
            Sequence = 18
        },

        new Organist("56503344040")
        {
            Id = 19,
            FullName = "Kauany Martins Souza",
            ShortName = "Kauany",
            ServicesDaysOfWeek = [DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.YouthMeeting,
            Sequence = 19
        },

        new Organist("16894804087")
        {
            Id = 20,
            FullName = "Mônica Pereira Lima",
            ShortName = "Mônica",
            ServicesDaysOfWeek = [DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.YouthMeeting,
            Sequence = 20
        }
    ];

    public static ICollection<Organist> Organists => _organists;
}