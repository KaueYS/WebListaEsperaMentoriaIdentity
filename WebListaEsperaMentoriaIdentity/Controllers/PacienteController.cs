using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebListaEsperaMentoriaIdentity.Interfaces;
using WebListaEsperaMentoriaIdentity.Models;
using WebListaEsperaMentoriaIdentity.ViewModels;

namespace WebListaEsperaMentoriaIdentity.Controllers
{
    [Authorize]
    public class PacienteController : Controller
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        public IActionResult PacientesFinalizados()
        {
            try
            {
                var pacientes = _pacienteService.BuscarPacientesFinalizados();
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

        public IActionResult Index()
        {
            try
            {
                var pacientes = _pacienteService.BuscarPacientes();
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PacienteViewModel paciente)
        {
            try
            {
                PacienteModel model = paciente;

                _pacienteService.CriarPaciente(model);
                if (paciente == null)
                {
                    TempData["ErroCadastro"] = "Nao foi possivel cadastrar o paciente";
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Erro!! tente novamente {e.Message}";
            }
            return View();

        }

        public IActionResult Edit(int id)
        {
            var paciente = _pacienteService.BuscarPorId(id);
            return View(paciente);
        }

        [HttpPost]
        public IActionResult Edit(PacienteModel paciente)
        {
            try
            {
                _pacienteService.EditarPaciente(paciente);
                if (paciente == null)
                {
                    TempData["ErroEdicao"] = "Nao foi possivel editar o paciente";
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Erro!! tente novamente {e.Message}";
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    TempData["ErroDeletar"] = "Nao foi possivel Deletar o paciente";
                }
                _pacienteService.DeletarPacienteService(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Erro!! tente novamente {e.Message}";
            }
            return View();

        }

        public IActionResult DeleteConfirmed(int id)
        {
            var paciente = _pacienteService.BuscarPorId(id);
            return View(paciente);
        }
    }
}
