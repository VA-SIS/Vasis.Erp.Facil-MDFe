using Microsoft.AspNetCore.Mvc;
using Vasis.Erp.Facil.Application.Interfaces;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;
using Vasis.Erp.Facil.Shared.Dtos.Common;

[ApiController]
[Route("api/[controller]")]
public class TransportadoraController : ControllerBase
{
    private readonly ITransportadoraService _transportadoraService;

    public TransportadoraController(ITransportadoraService transportadoraService)
    {
        _transportadoraService = transportadoraService;
    }

    [HttpPost("paged")]
    public async Task<IActionResult> GetAllPaged([FromBody] PagedRequestDto<TransportadoraDto> request)
    {
        var result = await _transportadoraService.GetPagedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _transportadoraService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TransportadoraDto dto)
    {
        var result = await _transportadoraService.CreateAsync(dto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] TransportadoraDto dto)
    {
        var result = await _transportadoraService.UpdateAsync(id, dto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _transportadoraService.DeleteAsync(id);
        return NoContent();
    }
}
