using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SQLitePCL;
using System.Security.Claims;
using WebListaEsperaMentoriaIdentity.Data;
using WebListaEsperaMentoriaIdentity.DTO;
using WebListaEsperaMentoriaIdentity.Interfaces;
using WebListaEsperaMentoriaIdentity.Models;
using WebListaEsperaMentoriaIdentity.ViewModels;

namespace WebListaEsperaMentoriaIdentity.Controllers
{
    [Authorize]
    public class PacienteController : Controller
    {
        private readonly IPacienteService _pacienteService;
        private readonly AppDbContext _context;


        public PacienteController(IPacienteService pacienteService, AppDbContext context)
        {
            _pacienteService = pacienteService;
            _context = context;
        }

        public async Task<IActionResult> PacientesFinalizados()
        {
            try
            {
                PacienteBuscarDTQ pacienteBuscarQuery = new PacienteBuscarDTQ();
                pacienteBuscarQuery.Status = Enums.StatusEnum.Finalizado;
                //pacienteBuscarQuery.UsuarioLogado = BuscarUsuarioLogado();
                var pacientes = await _pacienteService.Buscar(pacienteBuscarQuery);

                if (pacientes == null || pacientes.Count == 0)
                {
                    TempData["NaoHaPacientesCadastrados"] = "Nao ha pacientes cadastrados";
                }
                return View(pacientes);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Erro!! tente novamente {e.Message}";
            }
            return View();
        }

        public async Task<IActionResult> Index()
        {

            try
            {
                PacienteBuscarDTQ pacienteBuscarQuery = new PacienteBuscarDTQ();
                pacienteBuscarQuery.Status = Enums.StatusEnum.Ativo;
                //pacienteBuscarQuery.UsuarioLogado = BuscarUsuarioLogado();
                var pacientes = await _pacienteService.Buscar(pacienteBuscarQuery);

                if (pacientes == null || pacientes.Count == 0)
                {
                    TempData["NaoHaPacientesCadastrados"] = "Nao ha pacientes cadastrados";
                }

                PacienteViewModel pacienteViewModel = new PacienteViewModel();
                pacienteViewModel.Pacientes = pacientes;
                ViewData["ProfissionalId"] = new SelectList(_context.PROFISSIONAL, "Id", "Nome");
                return View(pacienteViewModel);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Erro!! tente novamente {e.Message}";
            }
            return View();
        }

        
        public async Task<IActionResult> Todos()
        {
            PacienteBuscarDTQ pacienteBuscarQuery = new PacienteBuscarDTQ();
            await _pacienteService.Buscar(pacienteBuscarQuery);

            return View();
        }

        public async Task<IActionResult> Create()
        {
            ViewData["ProfissionalId"] = new SelectList(_context.PROFISSIONAL, "Id", "Nome");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PacienteViewModel paciente)
        {
            PacienteModel model = paciente;

            ViewData["ProfissionalId"] = new SelectList(_context.PROFISSIONAL, "Id", "Id", paciente.ProfissionalId);

            await _pacienteService.CriarAsync(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Edit(int id)
        {

            PacienteBuscarDTQ pacienteBuscarQuery = new PacienteBuscarDTQ();
            pacienteBuscarQuery.PacienteId = id;


            var paciente = await _pacienteService.BuscarPorId(pacienteBuscarQuery);


            ViewData["ProfissionalId"] = new SelectList(_context.PROFISSIONAL, "Id", "Nome", paciente.ProfissionalId);
            return View(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PacienteViewModel paciente)
        {
            try
            {

                await _pacienteService.EditarAsync(paciente);
                if (paciente == null)
                {
                    TempData["ErroEdicao"] = "Nao foi possivel editar o paciente";
                }

                ViewData["ProfissionalId"] = new SelectList(_context.PROFISSIONAL, "Id", "Id", paciente.ProfissionalId);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Erro!! tente novamente {e.Message}";
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    TempData["ErroDeletar"] = "Nao foi possivel Deletar o paciente";
                }
                await _pacienteService.DeletarAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Erro!! tente novamente {e.Message}";
            }
            return View();
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            PacienteBuscarDTQ pacienteBuscarQuery = new PacienteBuscarDTQ();
            pacienteBuscarQuery.PacienteId = id;
            var paciente = await _pacienteService.BuscarPorId(pacienteBuscarQuery);
            return View(paciente);
        }

        private Guid BuscarUsuarioLogado()
        {
            Guid usuarioLogado = Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return usuarioLogado;
        }
    }
}
