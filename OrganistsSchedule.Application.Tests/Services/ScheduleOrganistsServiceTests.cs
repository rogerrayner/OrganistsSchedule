using Moq;
using OrganistsSchedule.Application.Services;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Enums;
using OrganistsSchedule.Domain.Exceptions;

public class ScheduleOrganistsServiceTests
{
    [Fact]
    public async Task Deve_Lancar_Excecao_Se_Algum_Culto_Ficar_Sem_Organista()
    {

        var organistas = new List<CongregationOrganist>
        {
            new CongregationOrganist { OrganistId = 1, Organist = new Organist { Id = 1, FullName = "Organista1", ShortName = "O1", Level = OrganistsLevelEnum.HolyService }, OrganistServiceDaysOfWeek = [ DayOfWeek.Saturday ] },
            new CongregationOrganist { OrganistId = 2, Organist = new Organist { Id = 2, FullName = "Organista2", ShortName = "O2", Level = OrganistsLevelEnum.HolyService }, OrganistServiceDaysOfWeek = [ DayOfWeek.Saturday ] },
            new CongregationOrganist { OrganistId = 3, Organist = new Organist { Id = 3, FullName = "Organista3", ShortName = "O3", Level = OrganistsLevelEnum.HolyService }, OrganistServiceDaysOfWeek = [ DayOfWeek.Saturday ] },
            new CongregationOrganist { OrganistId = 4, Organist = new Organist { Id = 4, FullName = "Organista4", ShortName = "O4", Level = OrganistsLevelEnum.HolyService }, OrganistServiceDaysOfWeek = [ DayOfWeek.Saturday ] }
        };

        var congregation = new Congregation
        {
            Id = 1,
            Name = "Central Church",
            RelatorioBrasCode = "BR999999",
            DaysOfService = [ DayOfWeek.Saturday, DayOfWeek.Sunday ],
            HasYouthMeetings = false
        };

        var parameters = new ParameterSchedule
        {
            StartDate = new DateTime(2024, 6, 1),
            EndDate = new DateTime(2024, 6, 9),
            Congregation = congregation,
            CongregationId = congregation.Id
        };

        var organistService = new Mock<IOrganistService>();
        var congregationService = new Mock<ICongregationService>();
        congregationService.Setup(x =>
                x.GetOrganistsByCongregationAsync(It.IsAny<long>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(organistas);

        var service = new ScheduleOrganistsService(organistService.Object, congregationService.Object);
        
        var ex = await Assert.ThrowsAsync<BusinessException>(async () =>
        {
            await service.ScheduleOrganistsForHolyServices(parameters);
        });
        Assert.Equal(ex.ErrorCode, Messages.GenerationSchedule1014.Code);
    }
    
    [Fact]
    public async Task Nao_Deve_Atribuir_Organista_Em_Dia_Nao_Permitido()
    {
        var congregation = new Congregation
        {
            Id = 1,
            Name = "Central",
            RelatorioBrasCode = "BR0001",
            DaysOfService = [ DayOfWeek.Saturday, DayOfWeek.Sunday ],
            HasYouthMeetings = false
        };

        var organistas = new List<CongregationOrganist>
        {
            new CongregationOrganist
            {
                OrganistId = 1,
                Organist = new Organist { Id = 1, FullName = "Organista1", ShortName = "O1", Level = OrganistsLevelEnum.HolyService },
                OrganistServiceDaysOfWeek = [ DayOfWeek.Saturday ]
            },
            new CongregationOrganist
            {
                OrganistId = 2,
                Organist = new Organist { Id = 2, FullName = "Organista2", ShortName = "O2", Level = OrganistsLevelEnum.HolyService },
                OrganistServiceDaysOfWeek = [ DayOfWeek.Sunday ]
            }
        };

        var parameters = new ParameterSchedule
        {
            StartDate = new DateTime(2024, 6, 1),
            EndDate = new DateTime(2024, 6, 2),
            Congregation = congregation,
            CongregationId = congregation.Id
        };

        var organistService = new Mock<IOrganistService>();
        var congregationService = new Mock<ICongregationService>();
        congregationService.Setup(x =>
                x.GetOrganistsByCongregationAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(organistas);

        var service = new ScheduleOrganistsService(organistService.Object, congregationService.Object);

        var cultos = await service.ScheduleOrganistsForHolyServices(parameters);
        
        Assert.All(cultos, culto => Assert.NotNull(culto.OrganistId));
        
        foreach (var culto in cultos)
        {
            var organista = organistas.FirstOrDefault(o => o.OrganistId == culto.OrganistId);
            Assert.NotNull(organista);
            Assert.Contains(culto.Date.DayOfWeek, organista.OrganistServiceDaysOfWeek);
        }
    }

    [Fact]
    public async Task Deve_Gerar_Cultos_Apenas_Nos_Dias_Permitidos()
    {
        var congregation = new Congregation
        {
            Id = 1,
            Name = "Central",
            RelatorioBrasCode = "BR0001",
            DaysOfService = [ DayOfWeek.Saturday ],
            HasYouthMeetings = false
        };

        var organistas = new List<CongregationOrganist>
        {
            new CongregationOrganist
            {
                OrganistId = 1,
                Organist = new Organist { Id = 1, FullName = "Organista1", ShortName = "O1", Level = OrganistsLevelEnum.HolyService },
                OrganistServiceDaysOfWeek = [ DayOfWeek.Saturday ]
            }
        };

        var parameters = new ParameterSchedule
        {
            StartDate = new DateTime(2024, 6, 1),
            EndDate = new DateTime(2024, 6, 7),
            Congregation = congregation,
            CongregationId = congregation.Id
        };

        var organistService = new Mock<IOrganistService>();
        var congregationService = new Mock<ICongregationService>();
        congregationService.Setup(x =>
                x.GetOrganistsByCongregationAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(organistas);

        var service = new ScheduleOrganistsService(organistService.Object, congregationService.Object);
        var cultos = await service.ScheduleOrganistsForHolyServices(parameters);

        Assert.All(cultos, culto =>
            Assert.Contains(culto.Date.DayOfWeek, congregation.DaysOfService));
    }

    [Fact]
    public async Task Deve_Distribuir_Organistas_De_Forma_Equilibrada()
    {
        var congregation = new Congregation
        {
            Id = 1,
            Name = "Central",
            RelatorioBrasCode = "BR0001",
            DaysOfService = [ DayOfWeek.Saturday, DayOfWeek.Sunday ],
            HasYouthMeetings = true
        };

        var organistas = new List<CongregationOrganist>();
        // 8 organistas só sábado, 6 só domingo, 6 ambos
        for (int i = 1; i <= 8; i++)
        {
            organistas.Add(new CongregationOrganist
            {
                OrganistId = i,
                Organist = new Organist
                {
                    Id = i,
                    FullName = $"Organista Sábado {i:00}",
                    ShortName = $"OS{i:00}",
                    Level = OrganistsLevelEnum.HolyService
                },
                OrganistServiceDaysOfWeek = [ DayOfWeek.Saturday ]
            });
        }
        for (int i = 9; i <= 14; i++)
        {
            organistas.Add(new CongregationOrganist
            {
                OrganistId = i,
                Organist = new Organist
                {
                    Id = i,
                    FullName = $"Organista Domingo {i:00}",
                    ShortName = $"OD{i:00}",
                    Level = OrganistsLevelEnum.YouthMeeting
                },
                OrganistServiceDaysOfWeek = [ DayOfWeek.Sunday ]
            });
        }
        for (int i = 15; i <= 20; i++)
        {
            organistas.Add(new CongregationOrganist
            {
                OrganistId = i,
                Organist = new Organist
                {
                    Id = i,
                    FullName = $"Organista Ambos {i:00}",
                    ShortName = $"OA{i:00}",
                    Level = OrganistsLevelEnum.YouthMeetingAndHolyService
                },
                OrganistServiceDaysOfWeek = [ DayOfWeek.Saturday, DayOfWeek.Sunday ]
            });
        }

        var parameters = new ParameterSchedule
        {
            StartDate = new DateTime(2024, 6, 1),
            EndDate = new DateTime(2024, 6, 30),
            Congregation = congregation,
            CongregationId = congregation.Id
        };

        var organistService = new Mock<IOrganistService>();
        var congregationService = new Mock<ICongregationService>();
        congregationService.Setup(x =>
                x.GetOrganistsByCongregationAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(organistas);

        var service = new ScheduleOrganistsService(organistService.Object, congregationService.Object);
        var cultos = await service.ScheduleOrganistsForHolyServices(parameters);
        
        foreach (var day in congregation.DaysOfService)
        {
            var cultosDoDia = cultos.Where(c => c.Date.DayOfWeek == day).ToList();
            var contagemPorOrganista = cultosDoDia.GroupBy(c => c.OrganistId).Select(g => g.Count()).ToList();
            int max = contagemPorOrganista.Max();
            int min = contagemPorOrganista.Min();
            Assert.InRange(max - min, 0, 1);
        }
    }
    
    [Fact]
    public async Task Deve_Respeitar_Nivel_Da_Organista()
    {
        var congregation = new Congregation
        {
            Id = 1,
            Name = "Central Church",
            RelatorioBrasCode = "BR999999",
            DaysOfService = [ DayOfWeek.Saturday ],
            HasYouthMeetings = true
        };

        List<CongregationOrganist> organistList =
        [
            new CongregationOrganist
            {
                OrganistId = 1,
                Organist = new Organist
                {
                    Id = 1,
                    Level = OrganistsLevelEnum.YouthMeeting,
                    FullName = "Organista 1",
                    ShortName = "Org1"
                },
                OrganistServiceDaysOfWeek = [DayOfWeek.Sunday],
                Sequence = 1,
                CongregationId = 1,
                Congregation = congregation
            },

            new CongregationOrganist
            {
                OrganistId = 2,
                Organist = new Organist
                {
                    Id = 2,
                    Level = OrganistsLevelEnum.HolyService,
                    FullName = "Organista 2",
                    ShortName = "Org2"
                },
                OrganistServiceDaysOfWeek = [DayOfWeek.Saturday, DayOfWeek.Sunday],
                Sequence = 1,
                CongregationId = 1,
                Congregation = congregation
            }
        ];
        
        var parameters = new ParameterSchedule
        {
            StartDate = new DateTime(2025, 6, 7),
            EndDate = new DateTime(2025, 6, 8),
            Congregation = congregation,
            CongregationId = congregation.Id
        };

        var organistService = new Mock<IOrganistService>();
        var congregationService = new Mock<ICongregationService>();
        congregationService.Setup(x => 
                x.GetOrganistsByCongregationAsync(It.IsAny<long>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(organistList);

        var service = new ScheduleOrganistsService(organistService.Object, congregationService.Object);
        var cultos = await service.ScheduleOrganistsForHolyServices(parameters);
        
        Assert.True(cultos.Any(c => c.IsYouthMeeting && c.OrganistId == 1));
        Assert.True(cultos.Any(c => !c.IsYouthMeeting && c.OrganistId == 2));
    }
}