using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebListaEsperaMentoriaIdentity.DTO;
using WebListaEsperaMentoriaIdentity.Enums;
using WebListaEsperaMentoriaIdentity.Models;
using WebListaEsperaMentoriaIdentity.ViewModels;

namespace WebListaEsperaMentoriaIdentity.Interfaces
{
    public interface IPacienteService
    {

        //Task <List<PacienteModel>> Buscar(PacienteBuscarDTQ pacienteBuscarQuery);
        Task <List<PacienteModel>> Buscar();
        Task<List<ProfissionalModel>> BuscarProfissional();
        
        Task<ListaEsperaViewModel> BuscarPorId(PacienteBuscarDTQ pacienteBuscarQuery);
        Task<PacienteModel> CriarAsync(PacienteModel paciente);
        Task<PacienteModel> EditarAsync(PacienteModel paciente);
        Task<PacienteModel> DeletarAsync(Guid id);
    }
}
