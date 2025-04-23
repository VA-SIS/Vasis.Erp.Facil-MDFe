using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Data.Repositories.Interfaces;
using AutoMapper;
using Vasis.Erp.Facil.Application.Dtos.Cadastros;
using Vasis.Erp.Facil.Application.Interfaces.Services;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Application.Services.Implementations;

public class EmpresaService : IEmpresaService
{
    private readonly IEmpresaRepository _empresaRepository;
    private readonly IMapper _mapper;

    public EmpresaService(IEmpresaRepository empresaRepository, IMapper mapper)
    {
        _empresaRepository = empresaRepository;
        _mapper = mapper;
    }

    public async Task<EmpresaDto> CreateAsync(EmpresaDto dto)
    {
        var entity = _mapper.Map<Empresa>(dto);
        entity.Id = Guid.NewGuid(); // Garante novo ID

        var result = await _empresaRepository.AddAsync(entity);
        return _mapper.Map<EmpresaDto>(result);
    }

    public async Task<EmpresaDto> UpdateAsync(EmpresaDto dto)
    {
        var entity = _mapper.Map<Empresa>(dto);
        var updated = await _empresaRepository.UpdateAsync(entity);
        return _mapper.Map<EmpresaDto>(updated);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _empresaRepository.DeleteAsync(id);
    }

    public async Task<EmpresaDto?> GetByIdAsync(Guid id)
    {
        var entity = await _empresaRepository.GetByIdAsync(id);
        return entity is null ? null : _mapper.Map<EmpresaDto>(entity);
    }

    public async Task<PagedResultDto<EmpresaDto>> GetPagedAsync(PagedRequestDto request)
    {
        // Paginação sem filtro (pode ajustar se quiser filtro por nome, CNPJ etc.)
        var result = await _empresaRepository.GetPagedAsync(x => true, request);
        var dtoList = _mapper.Map<List<EmpresaDto>>(result.Items);
        return new PagedResultDto<EmpresaDto>(dtoList, result.TotalCount);
    }

    public async Task<List<EmpresaDto>> GetAllAsync()
    {
        var list = await _empresaRepository.GetAllAsync();
        return _mapper.Map<List<EmpresaDto>>(list);
    }

    public Task<EmpresaDto> UpdateAsync(Guid id, EmpresaDto dto)
    {
        throw new NotImplementedException();
    }
}
