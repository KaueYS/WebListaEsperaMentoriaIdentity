﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Security.Claims;
using WebListaEsperaMentoriaIdentity.Interfaces;
using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.Controllers
{
    [Authorize]
    public class PacienteController : Controller
    {
        private readonly IPacienteService _services;

        public PacienteController(IPacienteService services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            var pacientes = _services.BuscarPacientes();
            return View(pacientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PacienteModel paciente)
        {
            _services.CriarPaciente(paciente);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var pacientes = _services.BuscarPorId(id);
            return View(pacientes);
        }

        [HttpPost]
        public IActionResult Edit(PacienteModel paciente)
        {
            _services.EditarPaciente(paciente);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _services.DeletarPaciente(id);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteConfirmed(int id)
        {
            var paciente = _services.BuscarPorId(id);
            return View(paciente);
        }
    }
}
