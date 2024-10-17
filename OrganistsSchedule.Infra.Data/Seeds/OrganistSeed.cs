using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Enums;

namespace OrganistsSchedule.Infrastructure.Seeds;

public static class OrganistSeed
{
    private static ICollection<Organist> _organists =
    [
        new Organist
        {
            Id = 1,
            FullName = "Alzenir",
            ShortName = "Alzenir",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 1,
            Cpf = "12345678909"
        },

        new Organist
        {
            Id = 2,
            FullName = "Jemima",
            ShortName = "Jemima",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 2,
            Cpf = "98765432100"
        },

        new Organist
        {
            Id = 3,
            FullName = "Valdete",
            ShortName = "Valdete",
            ServicesDaysOfWeek = [DayOfWeek.Tuesday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 3,
            Cpf = "45678912365"
        },

        new Organist
        {
            Id = 4,
            FullName = "Joana",
            ShortName = "Joana",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 4,
            Cpf = "65432198734"
        },

        new Organist
        {
            Id = 5,
            FullName = "Rosemari",
            ShortName = "Rosemari",
            ServicesDaysOfWeek = [DayOfWeek.Tuesday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 5,
            Cpf = "32165498729"
        },

        new Organist
        {
            Id = 6,
            FullName = "Camila",
            ShortName = "Camila",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 6,
            Cpf = "98732165473"
        },

        new Organist
        {
            Id = 7,
            FullName = "Priscila",
            ShortName = "Priscila",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 7,
            Cpf = "12378945601"
        },

        new Organist
        {
            Id = 8,
            FullName = "Joanita",
            ShortName = "Joanita",
            ServicesDaysOfWeek = [DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 8,
            Cpf = "65498732185"
        },

        new Organist
        {
            Id = 9,
            FullName = "Vanderleia",
            ShortName = "Vanderleia",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 9,
            Cpf = "78945612322"
        },

        new Organist
        {
            Id = 10,
            FullName = "Ana Paula",
            ShortName = "Ana Paula",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService | OrganistsLevelEnum.YouthMeeting,
            Sequence = 10,
            Cpf = "32198765498"
        },

        new Organist
        {
            Id = 11,
            FullName = "Amanda",
            ShortName = "Amanda",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 11,
            Cpf = "65412398756"
        },

        new Organist
        {
            Id = 12,
            FullName = "Hallen",
            ShortName = "Hallen",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 12,
            Cpf = "45698712344"
        },

        new Organist
        {
            Id = 13,
            FullName = "Solange",
            ShortName = "Solange",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 13,
            Cpf = "78912345655"
        },

        new Organist
        {
            Id = 14,
            FullName = "Dinorá",
            ShortName = "Dinorá",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 14,
            Cpf = "12345698766"
        },

        new Organist
        {
            Id = 15,
            FullName = "Rosangela",
            ShortName = "Rosangela",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 15,
            Cpf = "98712345632"
        },

        new Organist
        {
            Id = 16,
            FullName = "Sarah",
            ShortName = "Sarah",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 16,
            Cpf = "65478912310"
        },

        new Organist
        {
            Id = 17,
            FullName = "Luciana",
            ShortName = "Luciana",
            ServicesDaysOfWeek = [DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.HolyService,
            Sequence = 17,
            Cpf = "45612398721"
        },

        new Organist
        {
            Id = 18,
            FullName = "Manoela",
            ShortName = "Manoela",
            ServicesDaysOfWeek = [DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.YouthMeeting,
            Sequence = 18,
            Cpf = "78932145688"
        },

        new Organist
        {
            Id = 19,
            FullName = "Kauany",
            ShortName = "Kauany",
            ServicesDaysOfWeek = [DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.YouthMeeting,
            Sequence = 19,
            Cpf = "12365478966"
        },

        new Organist
        {
            Id = 20,
            FullName = "Mônica",
            ShortName = "Mônica",
            ServicesDaysOfWeek = [DayOfWeek.Sunday],
            Level = OrganistsLevelEnum.YouthMeeting,
            Sequence = 20,
            Cpf = "98765412333"
        }
    ];

    public static ICollection<Organist> Organists => _organists;
}