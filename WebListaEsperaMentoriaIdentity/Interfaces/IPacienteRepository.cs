using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.Interfaces
{
    public interface IPacienteRepository
    {
        PacienteModel BuscarPorId(int id);
        List<PacienteModel> BuscarPacientes();
        List<PacienteModel> BuscarPacientesFinalizados();
        PacienteModel EditarPaciente(PacienteModel model);
        PacienteModel CriarPaciente(PacienteModel model);
        PacienteModel DeletarPacienteRepository(int id);
    }
}
