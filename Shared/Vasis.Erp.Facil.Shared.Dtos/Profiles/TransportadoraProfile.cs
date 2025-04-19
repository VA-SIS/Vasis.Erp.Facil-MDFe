using AutoMapper;
using Vasis.Erp.Facil.Shared.Domain.Entities;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;

namespace Vasis.Erp.Facil.Shared.Dtos.Profiles;

public class TransportadoraProfile : Profile
{
    public TransportadoraProfile()
    {
        CreateMap<Transportadora, TransportadoraDto>().ReverseMap();
    }
}