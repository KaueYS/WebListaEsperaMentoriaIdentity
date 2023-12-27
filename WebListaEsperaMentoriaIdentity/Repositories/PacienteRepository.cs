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

        public async Task<List<PacienteModel>> BuscarAsync()
        {
            var pacientes = await _context.PACIENTES.Where(x => x.UsuarioId == BuscarUsuarioLogado() && x.Status == Enums.StatusEnum.Ativo).AsNoTracking().ToListAsync();
            return pacientes;
        }

        public async Task<List<PacienteModel>> BuscarFinalizadosAsync()
        {
            var pacientes = await _context.PACIENTES.Where(x => x.UsuarioId == BuscarUsuarioLogado() && x.Status == Enums.StatusEnum.Finalizado).AsNoTracking().ToListAsync();
            return pacientes;
        }

        public async Task<PacienteModel> BuscarPorId(int id)
        {
            var paciente = await _context.PACIENTES.FirstOrDefaultAsync(x => x.Id == id);
            return paciente;
        }

        public async Task<PacienteModel> CriarAsync(PacienteModel paciente)
        {
            paciente.UsuarioId = BuscarUsuarioLogado();
            _context.PACIENTES.Add(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task<PacienteModel> EditarAsync(PacienteModel paciente)
        {
            paciente.UsuarioId = BuscarUsuarioLogado();
            _context.PACIENTES.Update(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task<PacienteModel> DeletarAsync(int id)
        {
            var del = await BuscarPorId(id);
            _context.PACIENTES.Remove(del);
            await _context.SaveChangesAsync();
            return del;
        }

        private Guid BuscarUsuarioLogado()
        {
            Guid usuarioLogado = Guid.Parse(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return usuarioLogado;
        }
    }
}

