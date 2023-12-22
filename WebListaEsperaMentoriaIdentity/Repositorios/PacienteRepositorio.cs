using System.Security.Claims;
using WebListaEsperaMentoriaIdentity.Data;
using WebListaEsperaMentoriaIdentity.Interfaces;
using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.Repositorios
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public PacienteRepositorio(AppDbContext context, IHttpContextAccessor contextAccessor = null)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public List<PacienteModel> BuscarPacientes()
        {
            Guid usuarioLogado = Guid.Parse(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var pacientes = _context.PACIENTES.Where(x => x.UsuarioId == usuarioLogado).ToList();

            if (pacientes == null)
            {
                throw new Exception("Paciente nao encontrado");
            }
            return pacientes;
        }

        public PacienteModel BuscarPorId(int id)
        {
            var paciente = _context.PACIENTES.FirstOrDefault(x => x.Id == id);
            if (paciente == null)
            {
                throw new Exception("Paciente nao encontrado");
            }
            return paciente;
        }

        public PacienteModel CriarPaciente(PacienteModel paciente)
        {
            Guid usuarioLogado = Guid.Parse(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            paciente.UsuarioId = usuarioLogado;

            if (paciente == null)
            {
                throw new Exception("Paciente nao encontrado");
            }

            _context.PACIENTES.Add(paciente);
            _context.SaveChanges();
            return paciente;
        }

        public PacienteModel EditarPaciente(PacienteModel paciente)
        {
            Guid usuarioLogado = Guid.Parse(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            paciente.UsuarioId = usuarioLogado;

            if (paciente == null)
            {
                throw new Exception("Paciente nao encontrado");
            }

            _context.PACIENTES.Update(paciente);
            _context.SaveChanges();
            return paciente;
        }

        public PacienteModel DeletarPacienteRepository(int id)
        {
            var del = BuscarPorId(id);
            
            _context.PACIENTES.Remove(del);
            _context.SaveChanges();
            return del;
        }
    }
}

