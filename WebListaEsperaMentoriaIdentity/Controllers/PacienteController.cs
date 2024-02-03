﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
                         group patient by pr.Nome into grouped
                         select new ProfissionalPacienteListaEsperaDTO
                         {
                             NomeProfissional = grouped.Key,
                             QtdePacienteListaEspera = grouped.Count(pa => pa != null)
                         }).OrderBy(x => x.QtdePacienteListaEspera).ToList();

                ListaEsperaViewModel pacienteViewModel = new ListaEsperaViewModel();
                pacienteViewModel.ProfissionaisPacienteListaEspera = result;

                PacienteBuscarDTQ pacienteBuscarQuery = new PacienteBuscarDTQ();
                List<PacienteModel> pacientes = await _pacienteService.Buscar(pacienteBuscarQuery);

                if (pacientes == null || pacientes.Count == 0)
                {
                    TempData["NaoHaPacientesCadastrados"] = "Nao ha pacientes cadastrados";
                }
                pacienteViewModel.Pacientes = pacientes;

                ViewData["ProfissionalId"] = new SelectList(_context.PROFISSIONAL, "Id", "Nome").OrderBy(x => x.Text);
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
            var buscarTodos =  await _pacienteService.Buscar(pacienteBuscarQuery);

            return View(buscarTodos);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["ProfissionalId"] = new SelectList(_context.PROFISSIONAL, "Id", "Nome");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ListaEsperaViewModel paciente)
        {
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
        public async Task<IActionResult> Edit(ListaEsperaViewModel paciente)
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
