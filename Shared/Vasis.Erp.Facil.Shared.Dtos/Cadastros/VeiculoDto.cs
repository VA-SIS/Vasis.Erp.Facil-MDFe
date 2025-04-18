namespace Vasis.Erp.Facil.Shared.Dtos.Cadastros;

public class VeiculoDto
{
    public Guid Id { get; set; }
    public string Placa { get; set; } = string.Empty;
    public string? Rntrc { get; set; }
    public string? Tipo { get; set; } // Truck, Cavalo, Reboque etc
    public string? Uf { get; set; }

    public Guid? TransportadoraId { get; set; }

    public DateTime CriadoEm { get; set; }
    public DateTime? AtualizadoEm { get; set; }
}
