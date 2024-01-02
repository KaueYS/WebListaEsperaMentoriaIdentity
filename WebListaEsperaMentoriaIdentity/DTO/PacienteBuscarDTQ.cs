using WebListaEsperaMentoriaIdentity.Enums;

namespace WebListaEsperaMentoriaIdentity.DTO
{
    public class PacienteBuscarDTQ
    {
        public int PacienteId { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.Nenhum;
        public Guid UsuarioLogado { get; set; } = Guid.Empty;
    }
}
