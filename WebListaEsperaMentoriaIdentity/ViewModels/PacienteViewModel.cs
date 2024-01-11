using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using WebListaEsperaMentoriaIdentity.Enums;
using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.ViewModels
{
    public class PacienteViewModel : PacienteDadosBasicosViewModel
    {
        public ProfissionalModel? Profissional {  get; set; }
        public int? ProfissionalId { get; set; }
        public List<PacienteModel>? Pacientes { get; set; }
        
        


        public static implicit operator PacienteModel(PacienteViewModel paciente)
        {
            return new PacienteModel
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                Email = paciente.Email,
                Telefone = paciente.Telefone,
                DataCadastro = paciente.DataCadastro,
                Observacao = paciente.Observacao,
                ProfissionalId = paciente.ProfissionalId,
                Profissional = paciente.Profissional,
                Status = paciente.Status
                
            };
        }

        public static implicit operator PacienteViewModel(PacienteModel paciente)
        {
            return new PacienteViewModel
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                Email = paciente.Email,
                Telefone = paciente.Telefone,
                DataCadastro = paciente.DataCadastro,
                Observacao = paciente.Observacao,
                ProfissionalId = paciente.ProfissionalId,
                Profissional= paciente.Profissional,
                Status = paciente.Status,
                
            };
        }
       
    }
}

