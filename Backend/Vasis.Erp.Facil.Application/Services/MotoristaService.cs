using AutoMapper;
using Vasis.Erp.Facil.Application.Dtos.Motorista;
using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Application.Services.Interfaces;
using Vasis.Erp.Facil.Domain.Repositories;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Application.Services.Implementations
{
    public class MotoristaService : IMotoristaService
    {
        private readonly IMotoristaRepository _repository;
        private readonly IMapper _mapper;

        public MotoristaService(IMotoristaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResultDto<MotoristaDto>> GetPagedAsync(PagedRequestDto request)
        {
            var query = await _repository.GetPagedAsync(x =>
                string.IsNullOrEmpty(request.Filter) || x.Nome!.Contains(request.Filter), request);

            var items = _mapper.Map<List<MotoristaDto>>(query.Items);
            return new PagedResultDto<MotoristaDto>
            {
                TotalCount = query.TotalCount,
                Items = items
            };
        }

        public async Task<MotoristaDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<MotoristaDto>(entity);
        }

        public async Task<MotoristaDto> CreateAsync(MotoristaDto dto)
        {
            var entity = _mapper.Map<Motorista>(dto);
            var result = await _repository.AddAsync(entity);
            return _mapper.Map<MotoristaDto>(result);
        }

        public async Task<MotoristaDto> UpdateAsync(Guid id, MotoristaDto dto)
        {
            var entity = await _repository.GetByIdAsync(id) ?? throw new Exception("Motorista não encontrado.");
            _mapper.Map(dto, entity);
            var updated = await _repository.UpdateAsync(entity);
            return _mapper.Map<MotoristaDto>(updated);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<MotoristaDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return _mapper.Map<List<MotoristaDto>>(result);
        }
    }
}
