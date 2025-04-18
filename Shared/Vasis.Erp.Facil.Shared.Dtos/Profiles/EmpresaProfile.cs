using AutoMapper;
using Vasis.Erp.Facil.Application.Dtos.Cadastros;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Shared.Dtos.Profiles;

public class EmpresaProfile : Profile
{
    public EmpresaProfile()
    {
        CreateMap<Empresa, EmpresaDto>().ReverseMap();
    }
}
