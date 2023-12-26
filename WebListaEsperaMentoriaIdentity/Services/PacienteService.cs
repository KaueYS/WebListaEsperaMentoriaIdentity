﻿using WebListaEsperaMentoriaIdentity.Interfaces;
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
        public List<PacienteModel> BuscarPacientes()
        {

            var pacientes = _pacienteRepositorio.BuscarPacientes();

            //if (pacientes == null)
            //{
            //    throw new Exception("Paciente nao encontrado");
            //}
            return pacientes;
        }

        public List<PacienteModel> BuscarPacientesFinalizados()
        {

            var pacientes = _pacienteRepositorio.BuscarPacientesFinalizados();

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

        public PacienteModel EditarPaciente(PacienteModel paciente)
        {
            var pact = _pacienteRepositorio.EditarPaciente(paciente);
            return pact;
        }

        public PacienteModel CriarPaciente(PacienteModel paciente)
        {
            var pcte = _pacienteRepositorio.CriarPaciente(paciente);
            return pcte;
        }

        public PacienteModel DeletarPacienteService(int id)
        {
            var paciente = _pacienteRepositorio.DeletarPacienteRepository(id);
            return paciente;
        }
    }
}

