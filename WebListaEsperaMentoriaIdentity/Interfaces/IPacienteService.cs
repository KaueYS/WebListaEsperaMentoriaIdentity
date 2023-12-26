using WebListaEsperaMentoriaIdentity.Models;
using WebListaEsperaMentoriaIdentity.ViewModels;

namespace WebListaEsperaMentoriaIdentity.Interfaces
{
    public interface IPacienteService
    {
        List<PacienteModel> Buscar();
        List<PacienteModel> BuscarFinalizados();
        PacienteViewModel BuscarPorId(int id);
        PacienteModel Criar(PacienteModel paciente);
        PacienteModel Editar(PacienteModel paciente);
        PacienteModel Deletar(int id);
    }
}
