using Vasis.Erp.Facil.Shared.Dtos.Cadastros;

namespace Vasis.Erp.Facil.Application.Dtos.Motorista
{
    public class MotoristaDto : PessoaDto
    {
        public string? NumeroCpf { get; set; }
        public string? NumeroCnh { get; set; }
        public string? CategoriaCnh { get; set; }
        public DateTime? ValidadeCnh { get; set; }
    }
}
