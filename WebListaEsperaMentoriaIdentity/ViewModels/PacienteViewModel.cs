using System.ComponentModel;
using WebListaEsperaMentoriaIdentity.Enums;
using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.ViewModels
{
    public class PacienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        [DisplayName("Data do cadastro")]
        public DateTime DataCadastro { get; set; } 
        public string? Observacao { get; set; }
        public bool Finalizado { get; set; } = false;

        public StatusEnum Status { get; set; }
        public Guid UsuarioId { get; set; }
        //public virtual IdentityUser Usuario { get; set; }

        public static implicit operator PacienteModel(PacienteViewModel paciente)
        {
            return new PacienteModel
            {

                Nome = paciente.Nome,
                Email = paciente.Email,
                Telefone = paciente.Telefone,
                DataCadastro = paciente.DataCadastro,
                Observacao = paciente.Observacao,
                Finalizado = paciente.Finalizado,
                Status = paciente.Status
            };
        }

        public static implicit operator PacienteViewModel(PacienteModel paciente)
        {
            return new PacienteViewModel
            {
                Nome = paciente.Nome,
                Email = paciente.Email,
                Telefone = paciente.Telefone,
                DataCadastro = paciente.DataCadastro,
                Observacao = paciente.Observacao,
                Finalizado = paciente.Finalizado,
                Status = paciente.Status
            };
        }
    }
}

