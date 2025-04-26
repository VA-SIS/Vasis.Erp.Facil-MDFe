using System.Net.Http.Json;
using Vasis.Erp.Facil.Application.Dtos.Cadastros;

namespace Vasis.Erp.Facil.Frontend.Facil.Client.Services;

public class EmpresaService
{
    private readonly HttpClient _http;

    public EmpresaService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<EmpresaDto>> ListarAsync()
    {
        return await _http.GetFromJsonAsync<List<EmpresaDto>>("api/empresa") ?? new();
    }

    public async Task<EmpresaDto?> ObterPorIdAsync(Guid id)
    {
        return await _http.GetFromJsonAsync<EmpresaDto>($"api/empresa/{id}");
    }

    public async Task CriarAsync(EmpresaDto empresa)
    {
        await _http.PostAsJsonAsync("api/empresa", empresa);
    }

    public async Task AtualizarAsync(EmpresaDto empresa)
    {
        await _http.PutAsJsonAsync($"api/empresa/{empresa.Id}", empresa);
    }

    public async Task ExcluirAsync(Guid id)
    {
        await _http.DeleteAsync($"api/empresa/{id}");
    }
}
