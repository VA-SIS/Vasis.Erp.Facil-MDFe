namespace Vasis.Erp.Facil.Shared.Dtos.Cadastros;

public class MotoristaDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? NumeroCpf { get; set; }
    public string? NumeroCnh { get; set; }
    public string? CategoriaCnh { get; set; }
    public DateTime? ValidadeCnh { get; set; }

    public Guid? TransportadoraId { get; set; }

    public DateTime CriadoEm { get; set; }
    public DateTime? AtualizadoEm { get; set; }
}
