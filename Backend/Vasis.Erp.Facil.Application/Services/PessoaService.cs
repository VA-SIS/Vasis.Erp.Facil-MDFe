using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Application.Services.Interfaces;
using Vasis.Erp.Facil.Domain.Repositories;
using Vasis.Erp.Facil.Shared.Domain.Entities;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;

namespace Vasis.Erp.Facil.Application.Services.Implementations;

public class PessoaService : IPessoaService
{
    private readonly IPessoaRepository _pessoaRepository;

    public PessoaService(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    public async Task<PagedResultDto<PessoaDto>> GetPagedAsync(PagedRequestDto request)
    {
        var query = await _pessoaRepository.GetAllAsync();

        if (!string.IsNullOrWhiteSpace(request.Filter))
        {
            query = query
                .Where(p => p.Nome.Contains(request.Filter, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        var totalCount = query.Count;
        var pagedItems = query
            .Skip(request.SkipCount)
            .Take(request.PageSize)
            .Select(p => new PessoaDto
            {
                Id = p.Id,
                Nome = p.Nome,
                CpfCnpj = p.CpfCnpj,
                TipoPessoa = p.TipoPessoa
            })
            .ToList();

        return new PagedResultDto<PessoaDto>(pagedItems, totalCount);
    }

    public async Task<PessoaDto?> GetByIdAsync(Guid id)
    {
        var entity = await _pessoaRepository.GetByIdAsync(id);
        if (entity == null) return null;

        return new PessoaDto
        {
            Id = entity.Id,
            Nome = entity.Nome,
            CpfCnpj = entity.CpfCnpj,
            TipoPessoa = entity.TipoPessoa
        };
    }

    public async Task<PessoaDto> CreateAsync(PessoaDto dto)
    {
        var entity = new Pessoa
        {
            Id = Guid.NewGuid(),
            Nome = dto.Nome,
            CpfCnpj = dto.CpfCnpj,
            TipoPessoa = dto.TipoPessoa
        };

        await _pessoaRepository.AddAsync(entity);

        dto.Id = entity.Id;
        return dto;
    }

    public async Task<PessoaDto?> UpdateAsync(PessoaDto dto)
    {
        var entity = await _pessoaRepository.GetByIdAsync(dto.Id);
        if (entity == null) return null;

        entity.Nome = dto.Nome;
        entity.CpfCnpj = dto.CpfCnpj;
        entity.TipoPessoa = dto.TipoPessoa;

        await _pessoaRepository.UpdateAsync(entity);
        return dto;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _pessoaRepository.GetByIdAsync(id);
        if (entity == null) return false;

        await _pessoaRepository.DeleteAsync(id);
        return true;
    }
}
