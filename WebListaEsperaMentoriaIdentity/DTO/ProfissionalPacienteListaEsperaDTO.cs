using System;
using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.DTO
{
    public class ProfissionalPacienteListaEsperaDTO
    {
        public Guid ProfissionalId { get; set; }
        public string? NomeProfissional { get; set; }
        public int QtdePacienteListaEspera { get; set; }

    }
}
