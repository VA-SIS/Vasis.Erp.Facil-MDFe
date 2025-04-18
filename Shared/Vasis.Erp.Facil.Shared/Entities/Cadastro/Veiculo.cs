namespace Vasis.Erp.Facil.Shared.Entities.Cadastros;

public class Veiculo
{
    public Guid Id { get; set; }
    public string Placa { get; set; } = string.Empty;
    public string? Renavam { get; set; }
    public string? Tipo { get; set; }
    public string? Cor { get; set; }
    public string? Marca { get; set; }
    public string? Modelo { get; set; }
    public int AnoFabricacao { get; set; }

    public Guid? TransportadoraId { get; set; }
    public Transportadora? Transportadora { get; set; }

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public DateTime? AtualizadoEm { get; set; }
}
