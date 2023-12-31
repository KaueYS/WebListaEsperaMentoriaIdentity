using WebListaEsperaMentoriaIdentity.DTO;
using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.Interfaces
{
    public interface IPacienteRepository
    {
        Task <List<PacienteModel>> Buscar(PacienteBuscarDTQ pacienteBuscarQuery);
        Task <PacienteModel> BuscarPorId(PacienteBuscarDTQ pacienteBuscarQuery);
        //Task <List<PacienteModel>> BuscarAsync();
        //Task <List<PacienteModel>> BuscarFinalizadosAsync();
        Task <PacienteModel> EditarAsync(PacienteModel model);
        Task <PacienteModel> CriarAsync(PacienteModel model);
        Task< PacienteModel> DeletarAsync(int id);
    }
}
