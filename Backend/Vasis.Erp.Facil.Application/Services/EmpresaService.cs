using AutoMapper;
using Vasis.Erp.Facil.Application.Dtos.Cadastros;
using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Application.Interfaces.Services;
using Vasis.Erp.Facil.Data.Repositories.Interfaces;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Application.Services;

public class EmpresaService : IEmpresaService
{
    private readonly IEmpresaRepository _repository;
    private readonly IMapper _mapper;

    public EmpresaService(IEmpresaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmpresaDto> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<EmpresaDto>(entity);
    }

    public async Task<EmpresaDto> CreateAsync(EmpresaDto dto)
    {
        var entity = _mapper.Map<Empresa>(dto);
        await _repository.AddAsync(entity);
        return _mapper.Map<EmpresaDto>(entity);
    }

    public async Task<EmpresaDto> UpdateAsync(Guid id, EmpresaDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        _mapper.Map(dto, entity);
        await _repository.UpdateAsync(entity);
        return _mapper.Map<EmpresaDto>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<PagedResultDto<EmpresaDto>> GetPagedAsync(PagedRequestDto request)
    {
        var result = await _repository.GetPagedAsync(
            e => string.IsNullOrWhiteSpace(request.Filter) ||
                 e.RazaoSocial.Contains(request.Filter, StringComparison.OrdinalIgnoreCase),
            request
        );

        return new PagedResultDto<EmpresaDto>
        {
            Items = result.Items.Select(_mapper.Map<EmpresaDto>).ToList(),
            TotalCount = result.TotalCount
        };
    }
}
