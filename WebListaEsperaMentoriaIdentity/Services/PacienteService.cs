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

        // deixar so o verbo em todos os metodos
        public List<PacienteModel> Buscar()
        {

            var pacientes = _pacienteRepositorio.Buscar();

            //if (pacientes == null)
            //{
            //    throw new Exception("Paciente nao encontrado");
            //}
            return pacientes;
        }

        public List<PacienteModel> BuscarFinalizados()
        {

            var pacientes = _pacienteRepositorio.BuscarFinalizados();

            //if (pacientes == null)
            //{
            //    throw new Exception("Paciente nao encontrado");
            //}
            return pacientes;
        }

        public PacienteViewModel BuscarPorId(int id)
        {
            var paciente = _pacienteRepositorio.BuscarPorId(id);
            if (paciente != null)
            {
                PacienteViewModel pacienteViewModel = paciente;
                return pacienteViewModel;
            }
            throw new Exception("Paciente nao encontrado");
        }

        public PacienteModel Editar(PacienteModel paciente)
        {
            var pact = _pacienteRepositorio.Editar(paciente);
            return pact;
        }

        public PacienteModel Criar(PacienteModel paciente)
        {
            var pcte = _pacienteRepositorio.Criar(paciente);
            return pcte;
        }

        public PacienteModel Deletar(int id)
        {
            var paciente = _pacienteRepositorio.Deletar(id);
            return paciente;
        }
    }
}

