namespace Vasis.Erp.Facil.Shared.Entities.Cadastros;

public class Pessoa
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? CpfCnpj { get; set; }
    public string? RgIe { get; set; }
    public string? TipoPessoa { get; set; } // F ou J
    public string? Email { get; set; }
    public string? Telefone { get; set; }

    public string? Cep { get; set; }
    public string? Endereco { get; set; }
    public string? Numero { get; set; }
    public string? Bairro { get; set; }
    public string? Complemento { get; set; }
    public string? Cidade { get; set; }
    public string? Uf { get; set; }

    public Guid? EmpresaId { get; set; }
    public Empresa? Empresa { get; set; }

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public DateTime? AtualizadoEm { get; set; }
}
