using AutoMapper;
using Vasis.Erp.Facil.Application.Dtos.Cadastros;
using Vasis.Erp.Facil.Domain.Interfaces.Repositories;
using Vasis.Erp.Facil.Shared.Domain.Entities;
using Vasis.Erp.Facil.Shared.Dtos.Common;

public class EmpresaService : IEmpresaService
{
    private readonly IEmpresaRepository _repository;
    private readonly IMapper _mapper;

    public EmpresaService(IEmpresaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResultDto<EmpresaDto>> GetPagedAsync(PagedRequestDto<EmpresaDto> request)
    {
        var result = await _repository.GetPagedAsync(
            e => string.IsNullOrEmpty(request.Filter) || e.Nome.Contains(request.Filter),
            request
        );

        return new PagedResultDto<EmpresaDto>
        {
            Items = result.Items.Select(_mapper.Map<EmpresaDto>).ToList(),
            TotalCount = result.TotalCount
        };
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
}
