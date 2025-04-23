using AutoMapper;
using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Application.Dtos.Transportadoras;
using Vasis.Erp.Facil.Application.Services.Interfaces;
using Vasis.Erp.Facil.Data.Repositories.Interfaces;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Application.Services.Implementations
{
    public class TransportadoraService : ITransportadoraService
    {
        private readonly ITransportadoraRepository _repository;
        private readonly IMapper _mapper;

        public TransportadoraService(ITransportadoraRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResultDto<TransportadoraDto>> GetPagedAsync(PagedRequestDto request)
        {
            var query = await _repository.GetPagedAsync(x =>
                string.IsNullOrEmpty(request.Filter) || x.Nome.Contains(request.Filter), request);

            var dtoList = _mapper.Map<List<TransportadoraDto>>(query.Items);
            return new PagedResultDto<TransportadoraDto>
            {
                TotalCount = query.TotalCount,
                Items = dtoList
            };
        }

        public async Task<TransportadoraDto?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<TransportadoraDto>(entity);
        }

        public async Task<TransportadoraDto> CreateAsync(TransportadoraDto dto)
        {
            var entity = _mapper.Map<Transportadora>(dto);
            await _repository.AddAsync(entity);
            return _mapper.Map<TransportadoraDto>(entity);
        }

        public async Task<TransportadoraDto?> UpdateAsync(TransportadoraDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null) return null;

            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);
            return _mapper.Map<TransportadoraDto>(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
