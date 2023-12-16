using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using WebListaEsperaMentoriaIdentity.Data;
using WebListaEsperaMentoriaIdentity.Data.Migrations;
using WebListaEsperaMentoriaIdentity.Interfaces;
using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public PacienteService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _contextAccessor = contextAccessor;
        }



        public List<PacienteModel> BuscarPacientes()
        {
            Guid usuarioLogado = Guid.Parse(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var pacientes = _context.PACIENTES.Where(x => x.UsuarioId == usuarioLogado).ToList();

            return pacientes;
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

        public async Task<PacienteModel> CriarPaciente(PacienteModel paciente)
        {
            Guid userId = Guid.Parse(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            paciente.UsuarioId = userId;
            
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

