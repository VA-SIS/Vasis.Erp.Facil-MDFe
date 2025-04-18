namespace Vasis.Erp.Facil.Application.Dtos.Cadastros;

public class EmpresaDto
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
}
