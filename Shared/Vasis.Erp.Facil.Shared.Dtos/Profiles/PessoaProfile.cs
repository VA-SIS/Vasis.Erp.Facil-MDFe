using AutoMapper;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Shared.Dtos.Mapping;

public class PessoaProfile : Profile
{
    public PessoaProfile()
    {
        CreateMap<Pessoa, PessoaDto>().ReverseMap();
    }
}
