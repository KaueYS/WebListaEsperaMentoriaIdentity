using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.Interfaces
{
    public interface IPacienteRepository
    {
        Task <PacienteModel> BuscarPorId(int id);
        Task <List<PacienteModel>> BuscarAsync();
        Task <List<PacienteModel>> BuscarFinalizadosAsync();
        Task <PacienteModel> EditarAsync(PacienteModel model);
        Task <PacienteModel> CriarAsync(PacienteModel model);
        Task< PacienteModel> DeletarAsync(int id);
    }
}
