using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.ViewModels
{
    public class ListaPacientesCadaProfissionalViewModel
    {
        public Guid? ProfissionalId { get; set; }
        public ProfissionalModel? Profissional { get; set; }
        public List<PacienteModel>? ListaPacientesCadaProfissional { get; set; }
        public PacienteModel? Paciente { get; set; }
        public Guid? PacienteId { get; set; }
    }
}
