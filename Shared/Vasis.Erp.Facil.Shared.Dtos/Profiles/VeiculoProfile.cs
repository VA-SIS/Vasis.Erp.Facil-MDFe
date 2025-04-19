using AutoMapper;
using Vasis.Erp.Facil.Shared.Domain.Entities;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;

namespace Vasis.Erp.Facil.Shared.Dtos.Mapping;

public class VeiculoProfile : Profile
{
    public VeiculoProfile()
    {
        CreateMap<Veiculo, VeiculoDto>().ReverseMap();
    }
}