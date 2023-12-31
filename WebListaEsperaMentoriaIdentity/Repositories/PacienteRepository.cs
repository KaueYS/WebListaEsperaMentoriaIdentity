using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebListaEsperaMentoriaIdentity.Data;
using WebListaEsperaMentoriaIdentity.DTO;
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

        public async Task <List<PacienteModel>> Buscar(PacienteBuscarDTQ pacienteBuscarQuery)
        {
            if (pacienteBuscarQuery.Status == Enums.StatusEnum.Nenhum && pacienteBuscarQuery.UsuarioLogado == Guid.Empty)
            {
                var pacientes = await _context.PACIENTES.AsNoTracking().ToListAsync();
                return pacientes;

            }

            else if (pacienteBuscarQuery.Status != Enums.StatusEnum.Nenhum && pacienteBuscarQuery.UsuarioLogado == Guid.Empty)
            {
                var pacientes = await _context.PACIENTES.Where(x => x.Status == pacienteBuscarQuery.Status).AsNoTracking().ToListAsync();
                return pacientes;
            }

            else if (pacienteBuscarQuery.Status != Enums.StatusEnum.Nenhum && pacienteBuscarQuery.UsuarioLogado != Guid.Empty)
            {
                var pacientes = await _context.PACIENTES.Where(x => x.Status == pacienteBuscarQuery.Status && x.UsuarioId == pacienteBuscarQuery.UsuarioLogado).AsNoTracking().ToListAsync();
                return pacientes;
            }

            else 
            {
                var pacientes = await _context.PACIENTES.Where(x => x.UsuarioId == pacienteBuscarQuery.UsuarioLogado).AsNoTracking().ToListAsync();
                return pacientes;
            }
        }
       
        public async Task<PacienteModel> BuscarPorId(PacienteBuscarDTQ pacienteBuscarQuery)
        {
            var paciente = await _context.PACIENTES.FirstOrDefaultAsync(x => x.Id == pacienteBuscarQuery.PacienteId);
            return paciente;
        }

        public async Task<PacienteModel> CriarAsync(PacienteModel paciente)
        {
            paciente.UsuarioId = BuscarUsuarioLogado();
            paciente.DataCadastro = DateTime.Now;
            paciente.Status = Enums.StatusEnum.Ativo;
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
            PacienteBuscarDTQ pacienteBuscarQuery = new PacienteBuscarDTQ();

            pacienteBuscarQuery.PacienteId = id;
            var del = await BuscarPorId(pacienteBuscarQuery);

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

