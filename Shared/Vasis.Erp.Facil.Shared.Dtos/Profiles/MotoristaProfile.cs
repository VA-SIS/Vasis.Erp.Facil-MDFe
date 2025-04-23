using AutoMapper;
using Vasis.Erp.Facil.Application.Dtos.Motorista;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Application.Mappings;

public class MotoristaProfile : Profile
{
    public MotoristaProfile()
    {
        CreateMap<Motorista, MotoristaDto>().ReverseMap();
    }
}
