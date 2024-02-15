using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

        public async Task<IActionResult> Index()
        {
            try
            {
                List<ProfissionalPacienteListaEsperaDTO> result =
                        (from pr in _context.PROFISSIONAL
                         join pa in _context.PACIENTE on pr.Id equals pa.ProfissionalId into patientGroup
                         from patient in patientGroup.DefaultIfEmpty()
                         //group patient by pr.Nome into grouped
                         group patient by new { pr.Nome, pr.Id } into grouped
                         
                         select new ProfissionalPacienteListaEsperaDTO
                         {
                             ProfissionalId = grouped.Key.Id,
                             NomeProfissional = grouped.Key.Nome,
                             QtdePacienteListaEspera = grouped.Count(pa => pa != null)
                         }).OrderBy(x => x.QtdePacienteListaEspera).ToList();

                ListaPacientesViewModel pacienteViewModel = new ListaPacientesViewModel();
                pacienteViewModel.ProfissionaisPacienteListaEspera = result;

                PacienteBuscarDTQ pacienteBuscarQuery = new PacienteBuscarDTQ();
                List<PacienteModel> pacientes = await _pacienteService.Buscar();
                

                if (pacientes == null || pacientes.Count == 0)
                {
                    TempData["NaoHaPacientesCadastrados"] = "Nao ha pacientes cadastrados";
                }
                pacienteViewModel.Pacientes = pacienteViewModel.ConverterPaciente(pacientes);

                ViewData["ProfissionalId"] = new SelectList(_context.PROFISSIONAL, "Id", "Nome").OrderBy(x => x.Text);
                return View(pacienteViewModel);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Erro!! tente novamente {e.Message}";
            }
            return View();
        }

        public async Task<IActionResult> Create()
        {
            ViewData["ProfissionalId"] = new SelectList(_context.PROFISSIONAL, "Id", "Nome");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ListaPacientesViewModel paciente)
        {
            Regex regular = new Regex(@"\d");
            string telefoneSemMascara = string.Empty;
            //paciente.Telefone = regular.Match(paciente.Telefone).Value;
            foreach (Match item in regular.Matches(paciente.Telefone))
            {
                telefoneSemMascara += item.Value;
            }
            paciente.Telefone = telefoneSemMascara;

            PacienteModel model = paciente;

            ViewData["ProfissionalId"] = new SelectList(_context.PROFISSIONAL, "Id", "Id", paciente.ProfissionalId);

            await _pacienteService.CriarAsync(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {

            PacienteBuscarDTQ pacienteBuscarQuery = new PacienteBuscarDTQ();
            pacienteBuscarQuery.PacienteId = id;

            var paciente = await _pacienteService.BuscarPorId(pacienteBuscarQuery);

            ViewData["ProfissionalId"] = new SelectList(_context.PROFISSIONAL, "Id", "Nome", paciente.ProfissionalId);
            return View(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ListaPacientesViewModel paciente)
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

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
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

        public async Task<IActionResult> DeleteConfirmed(Guid id)
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

        private Guid BuscarProfissionalLogado()
        {
            Guid profissionalLogado = Guid.Parse(HttpContext.User.FindFirst("ProfissionaId").Value);
            return profissionalLogado;
        }
    }
}
