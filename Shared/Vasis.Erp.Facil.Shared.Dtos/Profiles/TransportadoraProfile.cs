using AutoMapper;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Shared.Dtos.Profiles;

public class TransportadoraProfile : Profile
{
    public TransportadoraProfile()
    {
        CreateMap<Transportadora, TransportadoraDto>().ReverseMap();
    }
}