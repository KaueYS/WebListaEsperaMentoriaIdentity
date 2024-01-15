using WebListaEsperaMentoriaIdentity.DTO;
using WebListaEsperaMentoriaIdentity.Enums;
using WebListaEsperaMentoriaIdentity.Interfaces;
using WebListaEsperaMentoriaIdentity.Models;
using WebListaEsperaMentoriaIdentity.ViewModels;

namespace WebListaEsperaMentoriaIdentity.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepositorio;
        public PacienteService(IPacienteRepository pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
        }
       
        public async Task <List<ProfissionalModel>> BuscarProfissional()
        {

            var profissional = await _pacienteRepositorio.BuscarProfissional();
            return profissional;


        }
        public async Task <List<PacienteModel>> Buscar(PacienteBuscarDTQ pacienteBuscarQuery)
        {
            var pacientes = await _pacienteRepositorio.Buscar(pacienteBuscarQuery);
            return pacientes;
        }

        public async Task<PacienteViewModel> BuscarPorId(PacienteBuscarDTQ pacienteBuscarQuery)
        {
            var paciente = await _pacienteRepositorio.BuscarPorId(pacienteBuscarQuery);
                        
            return paciente;
        }

        public async Task<PacienteModel> EditarAsync(PacienteModel paciente)
        {
            var pact = await _pacienteRepositorio.EditarAsync(paciente);
            return pact;
        }

        public async Task<PacienteModel> CriarAsync(PacienteModel paciente)
        {
            var pcte = await _pacienteRepositorio.CriarAsync(paciente);
            return pcte;
        }

        public async Task<PacienteModel> DeletarAsync(Guid id)
        {
            var paciente = await _pacienteRepositorio.DeletarAsync(id);
            return paciente;
        }

       
    }
}

