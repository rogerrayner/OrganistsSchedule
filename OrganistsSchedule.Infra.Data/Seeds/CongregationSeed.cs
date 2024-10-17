using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Infrastructure.Seeds;

public static class CongregationSeed
{
    private static ICollection<Congregation> _congregations = new List<Congregation>
    {
        new Congregation { Id = 1, Name = "Adhemar Garcia", HasYouthMeetings = true, AddressId = 1, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Friday  ]} ,
        new Congregation { Id = 2, Name = "Areião do Fátima", HasYouthMeetings = true, AddressId = 2, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Tuesday  ]} ,
        new Congregation { Id = 3, Name = "Central - Boa Vista", HasYouthMeetings = true, AddressId = 3, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday, DayOfWeek.Tuesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 4, Name = "Bom Retiro", HasYouthMeetings = true, AddressId = 4, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Friday  ]} ,
        new Congregation { Id = 5, Name = "Canto do Rio", HasYouthMeetings = true, AddressId = 5, DaysOfService = [ DayOfWeek.Wednesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 6, Name = "Comasa", HasYouthMeetings = true, AddressId = 6, DaysOfService = [ DayOfWeek.Tuesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 7, Name = "Costa e Silva", HasYouthMeetings = true, AddressId = 7, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday  ]} ,
        new Congregation { Id = 8, Name = "Cubatão", HasYouthMeetings = true, AddressId = 8, DaysOfService = [ DayOfWeek.Wednesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 9, Name = "Distrito Pirabeiraba - Canela", HasYouthMeetings = true, AddressId = 9, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Friday  ]} ,
        new Congregation { Id = 10, Name = "Distrito Pirabeiraba - Centro", HasYouthMeetings = true, AddressId = 10, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Thursday  ]} ,
        new Congregation { Id = 11, Name = "Distrito Pirabeiraba - Rio Bonito", HasYouthMeetings = true, AddressId = 11, DaysOfService = [ DayOfWeek.Wednesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 12, Name = "Escolinha", HasYouthMeetings = true, AddressId = 12, DaysOfService = [ DayOfWeek.Wednesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 13, Name = "Espinheiros", HasYouthMeetings = true, AddressId = 13, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday  ]} ,
        new Congregation { Id = 14, Name = "Fátima", HasYouthMeetings = true, AddressId = 14, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 15, Name = "Floresta", HasYouthMeetings = true, AddressId = 15, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Friday  ]} ,
        new Congregation { Id = 16, Name = "Iririú", HasYouthMeetings = true, AddressId = 16, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 17, Name = "Jardim das Oliveiras", HasYouthMeetings = true, AddressId = 17, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday  ]} ,
        new Congregation { Id = 18, Name = "Jardim Edilene", HasYouthMeetings = true, AddressId = 18, DaysOfService = [ DayOfWeek.Tuesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 19, Name = "Jardim Iririú", HasYouthMeetings = true, AddressId = 19, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday  ]} ,
        new Congregation { Id = 20, Name = "Jardim Paraíso", HasYouthMeetings = true, AddressId = 20, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Friday  ]} ,
        new Congregation { Id = 21, Name = "Jardim Sofia", HasYouthMeetings = true, AddressId = 21, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Thursday  ]} ,
        new Congregation { Id = 22, Name = "Jativoca", HasYouthMeetings = true, AddressId = 22, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Thursday  ]} ,
        new Congregation { Id = 23, Name = "Loteamento São Francisco II", HasYouthMeetings = true, AddressId = 23, DaysOfService = [ DayOfWeek.Wednesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 24, Name = "Loteamento Tahiti", HasYouthMeetings = true, AddressId = 24, DaysOfService = [ DayOfWeek.Tuesday  ]} ,
        new Congregation { Id = 25, Name = "Morro do Meio", HasYouthMeetings = true, AddressId = 25, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday  ]} ,
        new Congregation { Id = 26, Name = "Nova Brasília", HasYouthMeetings = true, AddressId = 26, DaysOfService = [ DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 27, Name = "Paranaguamirim", HasYouthMeetings = true, AddressId = 27, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday, DayOfWeek.Friday  ]} ,
        new Congregation { Id = 28, Name = "Parque Joinville", HasYouthMeetings = true, AddressId = 28, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday  ]} ,
        new Congregation { Id = 29, Name = "Petrópolis", HasYouthMeetings = true, AddressId = 29, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday  ]} ,
        new Congregation { Id = 30, Name = "Pinotti", HasYouthMeetings = true, AddressId = 30, DaysOfService = [ DayOfWeek.Thursday  ]} ,
        new Congregation { Id = 31, Name = "Pitaguaras", HasYouthMeetings = true, AddressId = 31, DaysOfService = [ DayOfWeek.Wednesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 32, Name = "Profipo", HasYouthMeetings = true, AddressId = 32, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Thursday  ]} ,
        new Congregation { Id = 33, Name = "Santa Barbara", HasYouthMeetings = true, AddressId = 33, DaysOfService = [ DayOfWeek.Tuesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 34, Name = "Ulysses Guimarães", HasYouthMeetings = true, AddressId = 34, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Wednesday  ]} ,
        new Congregation { Id = 35, Name = "Vila Nova", HasYouthMeetings = true, AddressId = 35, DaysOfService = [ DayOfWeek.Wednesday, DayOfWeek.Saturday  ]} ,
        new Congregation { Id = 36, Name = "Vila Paraná", HasYouthMeetings = true, AddressId = 36, DaysOfService = [ DayOfWeek.Sunday, DayOfWeek.Friday  ]} ,
    };

    public static ICollection<Congregation> Congregations => _congregations;
}