using System.ComponentModel;
using WebListaEsperaMentoriaIdentity.Enums;

namespace WebListaEsperaMentoriaIdentity.ViewModels
{
    public class PacienteDadosBasicosViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;

        [DisplayName("Data do cadastro")]
        public DateTime DataCadastro { get; set; }
        public string? Observacao { get; set; }

        public StatusEnum Status { get; set; }
        public Guid UsuarioId { get; set; }

    }
}
