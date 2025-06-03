using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Infrastructure.Seeds;

public static class CongregationSeed
{
    private static ICollection<Congregation> _congregations = new List<Congregation>
    {
        new Congregation { Id = 3, RelatorioBrasCode = "BR200029", Name = "Central - Boa Vista", HasYouthMeetings = true, AddressId = 3, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday, DayOfWeek.Tuesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 1, RelatorioBrasCode = "BR200577", Name = "Adhemar Garcia", HasYouthMeetings = true, AddressId = 1, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Friday  ]} ,
        new Congregation { Id = 2, RelatorioBrasCode = "BR200553", Name = "Areião do Fátima", HasYouthMeetings = true, AddressId = 2, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Tuesday  ]} ,
        new Congregation { Id = 4, RelatorioBrasCode = "BR200384", Name = "Bom Retiro", HasYouthMeetings = true, AddressId = 4, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Friday  ]} ,
        new Congregation { Id = 5, RelatorioBrasCode = "BR200613", Name = "Canto do Rio", HasYouthMeetings = true, AddressId = 5, DaysOfService = [ DayOfWeek.Wednesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 6, RelatorioBrasCode = "BR200669", Name = "Comasa", HasYouthMeetings = true, AddressId = 6, DaysOfService = [ DayOfWeek.Tuesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 7, RelatorioBrasCode = "BR200070", Name = "Costa e Silva", HasYouthMeetings = true, AddressId = 7, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday  ]} ,
        new Congregation { Id = 8, RelatorioBrasCode = "BR200219", Name = "Cubatão", HasYouthMeetings = true, AddressId = 8, DaysOfService = [ DayOfWeek.Wednesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 9, RelatorioBrasCode = "BR200149", Name = "Distrito Pirabeiraba - Canela", HasYouthMeetings = true, AddressId = 9, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Friday  ]} ,
        new Congregation { Id = 10, RelatorioBrasCode = "BR200535", Name = "Distrito Pirabeiraba - Centro", HasYouthMeetings = true, AddressId = 10, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Thursday  ]} ,
        new Congregation { Id = 11, RelatorioBrasCode = "BR200583", Name = "Distrito Pirabeiraba - Rio Bonito", HasYouthMeetings = true, AddressId = 11, DaysOfService = [ DayOfWeek.Wednesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 12, RelatorioBrasCode = "BR200109", Name = "Escolinha", HasYouthMeetings = true, AddressId = 12, DaysOfService = [ DayOfWeek.Wednesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 13, RelatorioBrasCode = "BR200274", Name = "Espinheiros", HasYouthMeetings = true, AddressId = 13, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday  ]} ,
        new Congregation { Id = 14, RelatorioBrasCode = "BR200073", Name = "Fátima", HasYouthMeetings = true, AddressId = 14, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 15, RelatorioBrasCode = "BR200343", Name = "Floresta", HasYouthMeetings = true, AddressId = 15, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Friday  ]} ,
        new Congregation { Id = 16, RelatorioBrasCode = "BR200058", Name = "Iririú", HasYouthMeetings = true, AddressId = 16, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 17, RelatorioBrasCode = "BR200546", Name = "Jardim das Oliveiras", HasYouthMeetings = true, AddressId = 17, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday  ]} ,
        new Congregation { Id = 18, RelatorioBrasCode = "BR200547", Name = "Jardim Edilene", HasYouthMeetings = true, AddressId = 18, DaysOfService = [ DayOfWeek.Tuesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 19, RelatorioBrasCode = "BR200554", Name = "Jardim Iririú", HasYouthMeetings = true, AddressId = 19, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday  ]} ,
        new Congregation { Id = 20, RelatorioBrasCode = "BR200137", Name = "Jardim Paraíso", HasYouthMeetings = true, AddressId = 20, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Friday  ]} ,
        new Congregation { Id = 21, RelatorioBrasCode = "BR200582", Name = "Jardim Sofia", HasYouthMeetings = true, AddressId = 21, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Thursday  ]} ,
        new Congregation { Id = 22, RelatorioBrasCode = "BR200242", Name = "Jativoca", HasYouthMeetings = true, AddressId = 22, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Thursday  ]} ,
        new Congregation { Id = 23, RelatorioBrasCode = "BR200587", Name = "Loteamento São Francisco II", HasYouthMeetings = true, AddressId = 23, DaysOfService = [ DayOfWeek.Wednesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 24, RelatorioBrasCode = "BR200575", Name = "Loteamento Tahiti", HasYouthMeetings = true, AddressId = 24, DaysOfService = [ DayOfWeek.Tuesday  ]} ,
        new Congregation { Id = 25, RelatorioBrasCode = "BR200110", Name = "Morro do Meio", HasYouthMeetings = true, AddressId = 25, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday  ]} ,
        new Congregation { Id = 26, RelatorioBrasCode = "BR200195", Name = "Nova Brasília", HasYouthMeetings = true, AddressId = 26, DaysOfService = [ DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 27, RelatorioBrasCode = "BR200184", Name = "Paranaguamirim", HasYouthMeetings = true, AddressId = 27, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday, DayOfWeek.Friday  ]} ,
        new Congregation { Id = 28, RelatorioBrasCode = "BR200220", Name = "Parque Joinville", HasYouthMeetings = true, AddressId = 28, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday  ]} ,
        new Congregation { Id = 29, RelatorioBrasCode = "BR200555", Name = "Petrópolis", HasYouthMeetings = true, AddressId = 29, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday  ]} ,
        new Congregation { Id = 30, RelatorioBrasCode = "BR200584", Name = "Pinotti", HasYouthMeetings = true, AddressId = 30, DaysOfService = [ DayOfWeek.Thursday  ]} ,
        new Congregation { Id = 31, RelatorioBrasCode = "BR200610", Name = "Pitaguaras", HasYouthMeetings = true, AddressId = 31, DaysOfService = [ DayOfWeek.Wednesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 32, RelatorioBrasCode = "BR200221", Name = "Profipo", HasYouthMeetings = true, AddressId = 32, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Thursday  ]} ,
        new Congregation { Id = 33, RelatorioBrasCode = "BR200590", Name = "Santa Barbara", HasYouthMeetings = true, AddressId = 33, DaysOfService = [ DayOfWeek.Tuesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 34, RelatorioBrasCode = "BR200544", Name = "Ulysses Guimarães", HasYouthMeetings = true, AddressId = 34, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday  ]} ,
        new Congregation { Id = 35, RelatorioBrasCode = "BR200222", Name = "Vila Nova", HasYouthMeetings = true, AddressId = 35, DaysOfService = [ DayOfWeek.Wednesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 36, RelatorioBrasCode = "BR200306", Name = "Vila Paraná", HasYouthMeetings = true, AddressId = 36, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Friday  ]} ,
        new Congregation { Id = 37, RelatorioBrasCode = "BR200687", Name = "Anaburgo", HasYouthMeetings = false, AddressId = 37, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Friday  ]}
    };

    public static ICollection<Congregation> Congregations => _congregations;
}