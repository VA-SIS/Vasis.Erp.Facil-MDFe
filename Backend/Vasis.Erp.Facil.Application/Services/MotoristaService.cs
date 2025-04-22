using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Application.Interfaces.Services;
using Vasis.Erp.Facil.Data.Context;
using Vasis.Erp.Facil.Shared.Domain.Entities;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;

namespace Vasis.Erp.Facil.Application.Services
{
    public class MotoristaService : IMotoristaService
    {
        private readonly ApplicationDbContext _context;

        public MotoristaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResultDto<MotoristaDto>> GetPagedAsync(PagedRequestDto request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var query = _context.Motoristas.AsQueryable();

            int total = await query.CountAsync();

            var items = await query
                .Skip(request.Skip)
                .Take(request.Take)
                .Select(m => new MotoristaDto
                {
                    Id = m.Id,
                    Nome = m.Nome,
                    NumeroCpf = m.NumeroCpf,
                    NumeroCnh = m.NumeroCnh,
                    CategoriaCnh = m.Categoria
                })
                .ToListAsync();

            return new PagedResultDto<MotoristaDto>(items, total);
        }

        public async Task<MotoristaDto> GetByIdAsync(Guid id)
        {
            var entity = await _context.Motoristas.FindAsync(id);

            if (entity == null) return null;

            return new MotoristaDto
            {
                Id = entity.Id,
                Nome = entity.Nome,
                NumeroCpf = entity.NumeroCpf,
                NumeroCnh = entity.NumeroCnh,
                CategoriaCnh = entity.CategoriaCnh
            };
        }

        public async Task<MotoristaDto> CreateAsync(MotoristaDto dto)
        {
            var entity = new Motorista
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                NumeroCpf = dto.NumeroCpf,
                NumeroCnh = dto.NumeroCnh,
                CategoriaCnh = dto.CategoriaCnh
            };

            _context.Motoristas.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            return dto;
        }

        public async Task<MotoristaDto> UpdateAsync(Guid id, MotoristaDto dto)
        {
            var entity = await _context.Motoristas.FindAsync(id);
            if (entity == null) return null;

            entity.Nome = dto.Nome;
            entity.NumeroCpf = dto.NumeroCpf;
            entity.NumeroCnh = dto.NumeroCnh;
            entity.CategoriaCnh = dto.CategoriaCnh;

            _context.Motoristas.Update(entity);
            await _context.SaveChangesAsync();

            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Motoristas.FindAsync(id);
            if (entity != null)
            {
                _context.Motoristas.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
