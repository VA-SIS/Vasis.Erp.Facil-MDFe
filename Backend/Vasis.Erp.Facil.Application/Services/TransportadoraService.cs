using AutoMapper;
using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Application.Interfaces;
using Vasis.Erp.Facil.Shared.Domain.Entities;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;

public class TransportadoraService : ITransportadoraService
{
    private readonly ITransportadoraRepository _repository;
    private readonly IMapper _mapper;

    public TransportadoraService(ITransportadoraRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TransportadoraDto> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<TransportadoraDto>(entity);
    }

    public async Task<TransportadoraDto> CreateAsync(TransportadoraDto dto)
    {
        var entity = _mapper.Map<Transportadora>(dto);
        await _repository.AddAsync(entity);
        return _mapper.Map<TransportadoraDto>(entity);
    }

    public async Task<TransportadoraDto> UpdateAsync(Guid id, TransportadoraDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        _mapper.Map(dto, entity);
        await _repository.UpdateAsync(entity);
        return _mapper.Map<TransportadoraDto>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<PagedResultDto<TransportadoraDto>> GetPagedAsync(PagedRequestDto request)
    {
        var list = await _repository.GetAllAsync();

        var filtradas = string.IsNullOrWhiteSpace(request.Filter)
            ? list
            : list.Where(x => x.RazaoSocial.Contains(request.Filter, StringComparison.OrdinalIgnoreCase)).ToList();

        return new PagedResultDto<TransportadoraDto>
        {
            Items = filtradas.Select(_mapper.Map<TransportadoraDto>).ToList(),
            TotalCount = filtradas.Count()
        };
    }
}
