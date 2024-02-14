using System.ComponentModel;
using System;
using WebListaEsperaMentoriaIdentity.Enums;
using WebListaEsperaMentoriaIdentity.Models;
using System.Collections.Generic;

namespace WebListaEsperaMentoriaIdentity.ViewModels
{
    public class ListaEsperaPacienteViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string TelefoneFormatado { get; set; } = string.Empty;

        [DisplayName("Data do cadastro")]
        public DateTime DataCadastro { get; set; }
        public string? Observacao { get; set; }

        public StatusEnum Status { get; set; }

        
        public ProfissionalModel? Profissional { get; set; }

        [DisplayName("Data disponivel")]
        public DateTime DataAgendamento { get; set; } = DateTime.Now.Date.ToLocalTime();

        public List<PacienteModel>? ListaPacientesCadaProfissional { get; set; }
        public PacienteModel? Paciente { get; set; }

    }
}
