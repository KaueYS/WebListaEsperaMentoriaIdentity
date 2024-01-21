using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace WebListaEsperaMentoriaIdentity.Models
{
    public class ProfissionalModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public EspecialidadeModel? Especialidade { get; set; }
        public Guid? EspecialidadeId { get; set; }

       
        public List<PacienteModel>? Pacientes { get; set;}

       
    }
}
