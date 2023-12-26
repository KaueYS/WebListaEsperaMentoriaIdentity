using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.Interfaces
{
    public interface IPacienteRepository
    {
        PacienteModel BuscarPorId(int id);
        List<PacienteModel> Buscar();
        List<PacienteModel> BuscarFinalizados();
        PacienteModel Editar(PacienteModel model);
        PacienteModel Criar(PacienteModel model);
        PacienteModel Deletar(int id);
    }
}
