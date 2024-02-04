using System;
using WebListaEsperaMentoriaIdentity.Enums;
using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.DTO
{
    public class PacienteBuscarDTQ
    {
        public Guid PacienteId { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.Normal;
        public Guid UsuarioLogado { get; set; } = Guid.Empty;
        public Guid ProfissionalId { get; set; } = Guid.Empty;
        public Guid ProfissionalLogado { get; set; } = Guid.Empty;
    }
}
