using System;
using WebListaEsperaMentoriaIdentity.Data;
using WebListaEsperaMentoriaIdentity.Interfaces;
using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.Services
{
    public class PacienteService : IPacienteService
    {

        private readonly AppDbContext _context;

        public PacienteService(AppDbContext context)
        {
            _context = context;
        }

        public List<PacienteModel> BuscarPacientes()
        {
            return _context.PACIENTES.ToList();
        }

        public PacienteModel BuscarPorId(int id)
        {
            var paciente = _context.PACIENTES.FirstOrDefault(x => x.Id == id);
            if (paciente != null)
            {
                return paciente;
            }
            throw new Exception("Paciente nao encontrado");
        }

        public PacienteModel CriarPaciente(PacienteModel paciente)
        {
            _context.PACIENTES.Add(paciente);
            _context.SaveChanges();
            return paciente;
        }

        public PacienteModel DeletarPaciente(int id)
        {
            var paciente = BuscarPorId(id);
            _context.PACIENTES.Remove(paciente);
            _context.SaveChanges();
            return paciente;
        }

        public PacienteModel EditarPaciente(PacienteModel paciente)
        {
            _context.PACIENTES.Update(paciente);
            _context.SaveChanges();
            return paciente;
        }
    }
}

