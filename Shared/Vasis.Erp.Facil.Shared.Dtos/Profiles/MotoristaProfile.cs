using AutoMapper;
using Vasis.Erp.Facil.Shared.Domain.Entities;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;

namespace Vasis.Erp.Facil.Application.Mappings;

public class MotoristaProfile : Profile
{
    public MotoristaProfile()
    {
        CreateMap<Motorista, MotoristaDto>().ReverseMap();
    }
}
