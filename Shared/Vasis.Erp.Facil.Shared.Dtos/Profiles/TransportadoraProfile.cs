using AutoMapper;
using Vasis.Erp.Facil.Application.Dtos.Transportadoras;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Shared.Dtos.Profiles;

public class TransportadoraProfile : Profile
{
    public TransportadoraProfile()
    {
        CreateMap<Transportadora, TransportadoraDto>().ReverseMap();
    }
}