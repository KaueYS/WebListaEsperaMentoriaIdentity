using WebListaEsperaMentoriaIdentity.Enums;
using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.DTO
{
    public class PacienteBuscarDTQ
    {
        public int PacienteId { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.Nenhum;
        public Guid UsuarioLogado { get; set; } = Guid.Empty;
        public int ProfissionalId { get; set; } = 0;
    }
}
