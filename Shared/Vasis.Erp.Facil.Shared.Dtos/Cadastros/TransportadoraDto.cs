namespace Vasis.Erp.Facil.Application.Dtos.Transportadoras;

public class TransportadoraDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Cnpj { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
}
