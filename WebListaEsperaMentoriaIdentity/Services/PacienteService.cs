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
        
        public async Task<List<PacienteModel>> BuscarAsync()
        {
            var pacientes = await _pacienteRepositorio.BuscarAsync();

            return pacientes;
        }

        public async Task<List<PacienteModel>> BuscarFinalizadosAsync()
        {
            var pacientes = await _pacienteRepositorio.BuscarFinalizadosAsync();

            return pacientes;
        }

        public async Task<PacienteViewModel> BuscarPorId(int id)
        {
            var paciente = await _pacienteRepositorio.BuscarPorId(id);
                        
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

        public async Task<PacienteModel> DeletarAsync(int id)
        {
            var paciente = await _pacienteRepositorio.DeletarAsync(id);
            return paciente;
        }
    }
}

