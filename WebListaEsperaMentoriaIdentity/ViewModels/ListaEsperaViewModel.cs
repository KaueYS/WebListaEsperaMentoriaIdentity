using WebListaEsperaMentoriaIdentity.DTO;
using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.ViewModels
{
    public class ListaEsperaViewModel : PacienteDadosBasicosViewModel
    {
        public ProfissionalModel? Profissional {  get; set; }
        public Guid? ProfissionalId { get; set; }
        public List<PacienteModel>? Pacientes { get; set; }
        
        public Guid PacienteId { get; set; }
        public List<ProfissionalPacienteListaEsperaDTO>? ProfissionaisPacienteListaEspera { get; set; }

       


        public static implicit operator PacienteModel(ListaEsperaViewModel paciente)
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

        public static implicit operator ListaEsperaViewModel(PacienteModel paciente)
        {
            return new ListaEsperaViewModel
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

