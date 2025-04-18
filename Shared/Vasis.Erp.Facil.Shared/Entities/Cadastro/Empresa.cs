namespace Vasis.Erp.Facil.Shared.Entities.Cadastros;
public class Empresa
{
    public Guid Id { get; set; }
    public string RazaoSocial { get; set; } = string.Empty;
    public string? NomeFantasia { get; set; }
    public string? Cnpj { get; set; }
    public string? Ie { get; set; }

    public string? Email { get; set; }
    public string? Telefone { get; set; }

    public string? Cep { get; set; }
    public string? Endereco { get; set; }
    public string? Numero { get; set; }
    public string? Bairro { get; set; }
    public string? Complemento { get; set; }
    public string? Cidade { get; set; }
    public string? Uf { get; set; }

    public ICollection<Pessoa> Pessoas { get; set; } = new List<Pessoa>();

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public DateTime? AtualizadoEm { get; set; }
}
