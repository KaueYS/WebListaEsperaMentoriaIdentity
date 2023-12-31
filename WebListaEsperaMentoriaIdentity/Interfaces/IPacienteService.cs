using WebListaEsperaMentoriaIdentity.DTO;
using WebListaEsperaMentoriaIdentity.Enums;
using WebListaEsperaMentoriaIdentity.Models;
using WebListaEsperaMentoriaIdentity.ViewModels;

namespace WebListaEsperaMentoriaIdentity.Interfaces
{
    public interface IPacienteService
    {

        Task <List<PacienteModel>> Buscar(PacienteBuscarDTQ pacienteBuscarQuery);
        //Task<List<PacienteModel>> BuscarAsync();
        //Task<List<PacienteModel>> BuscarFinalizadosAsync();
        Task<PacienteViewModel> BuscarPorId(PacienteBuscarDTQ pacienteBuscarQuery);
        Task<PacienteModel> CriarAsync(PacienteModel paciente);
        Task<PacienteModel> EditarAsync(PacienteModel paciente);
        Task<PacienteModel> DeletarAsync(int id);
    }
}
