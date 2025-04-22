using AutoMapper;
using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Application.Interfaces.Services;
using Vasis.Erp.Facil.Data.Repositories.Interfaces;
using Vasis.Erp.Facil.Shared.Domain.Entities;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;

public class PessoaService : IPessoaService
{
    private readonly IPessoaRepository _repository;
    private readonly IMapper _mapper;

    public PessoaService(IPessoaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PessoaDto> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<PessoaDto>(entity);
    }

    public async Task<PessoaDto> CreateAsync(PessoaDto dto)
    {
        var entity = _mapper.Map<Pessoa>(dto);
        await _repository.AddAsync(entity);
        return _mapper.Map<PessoaDto>(entity);
    }

    public async Task<PessoaDto> UpdateAsync(Guid id, PessoaDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        _mapper.Map(dto, entity);
        await _repository.UpdateAsync(entity);
        return _mapper.Map<PessoaDto>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<PagedResultDto<PessoaDto>> GetPagedAsync(PagedRequestDto request)
    {
        var pessoas = await _repository.GetAllAsync();

        var filtradas = string.IsNullOrWhiteSpace(request.Filter)
            ? pessoas
            : pessoas.Where(p =>
                (!string.IsNullOrEmpty(p.Nome) && p.Nome.Contains(request.Filter, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(p.Documento) && p.Documento.Contains(request.Filter, StringComparison.OrdinalIgnoreCase))
              ).ToList();

        var paginadas = filtradas
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        return new PagedResultDto<PessoaDto>
        {
            Items = paginadas.Select(_mapper.Map<PessoaDto>).ToList(),
            TotalCount = filtradas.Count()
        };
    }
}
