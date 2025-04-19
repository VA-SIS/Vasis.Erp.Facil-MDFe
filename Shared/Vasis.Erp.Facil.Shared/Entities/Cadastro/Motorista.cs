namespace Vasis.Erp.Facil.Shared.Domain.Entities;

public class Motorista : Pessoa
{
    public string? NumeroCpf { get; set; }
    public string? NumeroCnh { get; set; }
    public string? CategoriaCnh { get; set; }
    public DateTime? ValidadeCnh { get; set; }
}
