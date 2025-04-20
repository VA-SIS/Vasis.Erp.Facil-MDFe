using Vasis.Erp.Facil.Data.Context;
using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Application.Interfaces;
using Vasis.Erp.Facil.Shared.Domain.Entities;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;
using Vasis.Erp.Facil.Shared.Dtos.Common;
using System.Linq;

namespace Vasis.Erp.Facil.Application.Services
{
    public class TransportadoraService : ITransportadoraService
    {
        private readonly ApplicationDbContext _context;

        public TransportadoraService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResultDto<TransportadoraDto>> GetPagedAsync(PagedRequestDto<TransportadoraDto> request)
        {
            var query = _context.Transportadoras.AsQueryable();

            var total = await query.CountAsync();
            var items = await query
                .Skip(request.Skip)
                .Take(request.Take)
                .Select(t => new TransportadoraDto
                {
                    Id = t.Id,
                    Nome = t.Nome,
                    Cnpj = t.Cnpj,
                    Ie = t.InscricaoEstadual,
                    Endereco = t.Endereco
                })
                .ToListAsync();

            return new PagedResultDto<TransportadoraDto>(items, total);
        }

        public async Task<TransportadoraDto> GetByIdAsync(Guid id)
        {
            var entity = await _context.Transportadoras.FindAsync(id);

            if (entity == null) return null;

            return new TransportadoraDto
            {
                Id = entity.Id,
                Nome = entity.NomeFantasia ?? string.Empty,
                Cnpj = entity.Cnpj,
                Ie = entity.Ie,
                Endereco = entity.Endereco
            };
        }

        public async Task<TransportadoraDto> CreateAsync(TransportadoraDto dto)
        {
            var entity = new Transportadora
            {
                Id = Guid.NewGuid(),
                NomeFantasia = dto.Nome ?? string.Empty,
                Cnpj = dto.Cnpj,
                ie = dto.Ie,
                Endereco = dto.Endereco
            };

            _context.Transportadoras.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            return dto;
        }

        public async Task<TransportadoraDto> UpdateAsync(Guid id, TransportadoraDto dto)
        {
            var entity = await _context.Transportadoras.FindAsync(id);

            if (entity == null) return null;

            entity.NomeFantasia = dto.Nome;
            entity.Cnpj = dto.Cnpj;
            entity.Ie = dto.Ie;
            entity.Endereco = dto.Endereco;

            _context.Transportadoras.Update(entity);
            await _context.SaveChangesAsync();

            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Transportadoras.FindAsync(id);

            if (entity != null)
            {
                _context.Transportadoras.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
