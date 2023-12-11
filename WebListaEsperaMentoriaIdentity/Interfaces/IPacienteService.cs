using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.Interfaces
{
    public interface IPacienteService
    {
        List<PacienteModel> BuscarPacientes();
        PacienteModel BuscarPorId(int id);
        PacienteModel CriarPaciente(PacienteModel paciente);
        PacienteModel EditarPaciente(PacienteModel paciente);
        PacienteModel DeletarPaciente(int id);
    }
}
