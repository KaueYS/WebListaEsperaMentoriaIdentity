using WebListaEsperaMentoriaIdentity.Models;
using WebListaEsperaMentoriaIdentity.ViewModels;

namespace WebListaEsperaMentoriaIdentity.Interfaces
{
    public interface IPacienteService
    {
        List<PacienteModel> BuscarPacientes();
        List<PacienteModel> BuscarPacientesFinalizados();
        PacienteViewModel BuscarPorId(int id);
        PacienteModel CriarPaciente(PacienteModel paciente);
        PacienteModel EditarPaciente(PacienteModel paciente);
        PacienteModel DeletarPacienteService(int id);
    }
}
