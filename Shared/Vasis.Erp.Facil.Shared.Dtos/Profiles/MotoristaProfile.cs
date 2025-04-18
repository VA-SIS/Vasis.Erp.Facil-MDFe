using AutoMapper;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Application.Mappings;

public class MotoristaProfile : Profile
{
    public MotoristaProfile()
    {
        CreateMap<Motorista, MotoristaDto>().ReverseMap();
    }
}
