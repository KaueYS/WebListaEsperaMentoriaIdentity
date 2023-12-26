using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebListaEsperaMentoriaIdentity.Data;
using WebListaEsperaMentoriaIdentity.Interfaces;
using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public PacienteRepository(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public List<PacienteModel> BuscarPacientes()
        {
            
            var pacientes = _context.PACIENTES.Where(x => x.UsuarioId == BuscarUsuarioLogado() && x.Status == Enums.StatusEnum.Ativo).AsNoTracking().ToList();

            return pacientes;
        }
        public List<PacienteModel> BuscarPacientesFinalizados()
        {

            var pacientes = _context.PACIENTES.Where(x => x.UsuarioId == BuscarUsuarioLogado() && x.Status == Enums.StatusEnum.Finalizado).AsNoTracking().ToList();

            return pacientes;
        }

        public PacienteModel BuscarPorId(int id)
        {
            var paciente = _context.PACIENTES.FirstOrDefault(x => x.Id == id);
            
            return paciente;
        }

        public PacienteModel CriarPaciente(PacienteModel paciente)
        {
            
            paciente.UsuarioId = BuscarUsuarioLogado();

            _context.PACIENTES.Add(paciente);
            _context.SaveChanges();
            return paciente;
        }

        public PacienteModel EditarPaciente(PacienteModel paciente)
        {
            
            paciente.UsuarioId = BuscarUsuarioLogado();
                       
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


        private Guid BuscarUsuarioLogado()
        {
            Guid usuarioLogado = Guid.Parse(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return usuarioLogado;
        }
    }
}

