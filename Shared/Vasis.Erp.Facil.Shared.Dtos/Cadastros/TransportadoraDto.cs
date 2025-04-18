namespace Vasis.Erp.Facil.Shared.Dtos.Cadastros;


public class TransportadoraDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Cnpj { get; set; }
    public string? Ie { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public string? Endereco { get; set; }
    public string? Cidade { get; set; }
    public string? Uf { get; set; }

    public DateTime CriadoEm { get; set; }
    public DateTime? AtualizadoEm { get; set; }
}
