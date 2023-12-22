using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.Interfaces
{
    public interface IPacienteRepositorio
    {
        PacienteModel BuscarPorId(int id);
        List<PacienteModel> BuscarPacientes();
        PacienteModel EditarPaciente(PacienteModel model);
        PacienteModel CriarPaciente(PacienteModel model);
        PacienteModel DeletarPacienteRepository(int id);

    }
}
