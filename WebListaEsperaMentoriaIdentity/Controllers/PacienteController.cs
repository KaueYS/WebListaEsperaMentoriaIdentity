using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        public async Task<IActionResult> PacientesFinalizados()
        {
            try
            {
                PacienteBuscarDTQ pacienteBuscarQuery = new PacienteBuscarDTQ();
                pacienteBuscarQuery.Status = Enums.StatusEnum.Finalizado;
                pacienteBuscarQuery.UsuarioLogado = BuscarUsuarioLogado();
                var pacientes = await _pacienteService.Buscar(pacienteBuscarQuery);


                //var pacientes = await _pacienteService.BuscarFinalizadosAsync();
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
                pacienteBuscarQuery.UsuarioLogado = BuscarUsuarioLogado();
                var pacientes = await _pacienteService.Buscar(pacienteBuscarQuery);


                //var pacientes = await _pacienteService.BuscarAsync();
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

        public async Task<IActionResult> Inativos()
        {
            PacienteBuscarDTQ pacienteBuscarQuery = new PacienteBuscarDTQ();
            pacienteBuscarQuery.Status = Enums.StatusEnum.Inativo;
            pacienteBuscarQuery.UsuarioLogado = BuscarUsuarioLogado();
            await _pacienteService.Buscar(pacienteBuscarQuery);

            return View();
        }

        public async Task<IActionResult> Todos()
        {
            PacienteBuscarDTQ pacienteBuscarQuery = new PacienteBuscarDTQ();

            await _pacienteService.Buscar(pacienteBuscarQuery);

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PacienteViewModel paciente)
        {
            try
            {
                PacienteModel model = paciente;

                await _pacienteService.CriarAsync(model);
                

                if (model == null)
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

        public async Task<IActionResult> Edit(int id)
        {
            PacienteBuscarDTQ pacienteBuscarQuery = new PacienteBuscarDTQ();
            pacienteBuscarQuery.PacienteId = id;


            var paciente = await _pacienteService.BuscarPorId(pacienteBuscarQuery);
            return View(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PacienteModel paciente)
        {
            try
            {
                await _pacienteService.EditarAsync(paciente);
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
