using WebListaEsperaMentoriaIdentity.Models;
using WebListaEsperaMentoriaIdentity.ViewModels;

namespace WebListaEsperaMentoriaIdentity.Interfaces
{
    public interface IPacienteService
    {
        Task <List<PacienteModel>> BuscarAsync();
        Task<List<PacienteModel>> BuscarFinalizadosAsync();
        Task<PacienteViewModel> BuscarPorId(int id);
        Task<PacienteModel> CriarAsync(PacienteModel paciente);
        Task<PacienteModel> EditarAsync(PacienteModel paciente);
        Task<PacienteModel> DeletarAsync(int id);
    }
}
