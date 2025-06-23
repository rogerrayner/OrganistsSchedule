using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Bff.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Bff.Services;

public class ParameterScheduleBffService(IMapper mapper, 
    IParameterScheduleService service) 
    : CrudBffServiceBase<ParameterSchedule, 
            ParameterScheduleDto, 
            ParameterSchedulePagedAndSortedRequest,
            ParameterScheduleCreateUpdateDto>(mapper, service),
        IParameterScheduleBffService
{

}