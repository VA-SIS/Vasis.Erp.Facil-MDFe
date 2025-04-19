using AutoMapper;
using Vasis.Erp.Facil.Shared.Domain.Entities;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;

namespace Vasis.Erp.Facil.Shared.Dtos.Mapping;

public class PessoaProfile : Profile
{
    public PessoaProfile()
    {
        CreateMap<Pessoa, PessoaDto>().ReverseMap();
    }
}
