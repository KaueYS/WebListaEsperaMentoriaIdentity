using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using WebListaEsperaMentoriaIdentity.Data;
using WebListaEsperaMentoriaIdentity.Models;
using WebListaEsperaMentoriaIdentity.ViewModels;


namespace WebListaEsperaMentoriaIdentity.Controllers
{
    [Authorize]
    public class ProfissionalController : Controller
    {
        private readonly AppDbContext _context;

        public ProfissionalController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult ListaPacientesProfissional(Guid id)
        {
            var pacientesFiltradosPeloProfissional = _context.PACIENTE.Include(p => p.Profissional).Where(x => x.ProfissionalId == id);
            ListaPacientesCadaProfissionalViewModel listaPacientesCadaProfissionalViewModel = new();

            listaPacientesCadaProfissionalViewModel.ListaPacientesCadaProfissional = pacientesFiltradosPeloProfissional.ToList();
            return View(listaPacientesCadaProfissionalViewModel);
        }



        // GET: Profissional
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PROFISSIONAL.Include(p => p.Especialidade);
            return View(await appDbContext.OrderBy(x => x.Nome).ToListAsync());
        }

        // GET: Profissional/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissionalModel = await _context.PROFISSIONAL
                .Include(p => p.Especialidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profissionalModel == null)
            {
                return NotFound();
            }

            return View(profissionalModel);
        }

        // GET: Profissional/Create
        public IActionResult Create()
        {
            ViewData["EspecialidadeId"] = new SelectList(_context.ESPECIALIDADE, "Id", "Nome");
            return View();
        }

        // POST: Profissional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfissionalModel profissionalModel)
        {
            if (ModelState.IsValid)
            {
                profissionalModel.Id = Guid.NewGuid();
                _context.Add(profissionalModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecialidadeId"] = new SelectList(_context.ESPECIALIDADE, "Id", "Id", profissionalModel.EspecialidadeId);
            return View(profissionalModel);
        }

        // GET: Profissional/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissionalModel = await _context.PROFISSIONAL.FindAsync(id);
            if (profissionalModel == null)
            {
                return NotFound();
            }
            ViewData["EspecialidadeId"] = new SelectList(_context.ESPECIALIDADE, "Id", "Nome", profissionalModel.EspecialidadeId);
            return View(profissionalModel);
        }

        // POST: Profissional/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProfissionalModel profissionalModel)
        {
            if (id != profissionalModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profissionalModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfissionalModelExists(profissionalModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecialidadeId"] = new SelectList(_context.ESPECIALIDADE, "Id", "Id", profissionalModel.EspecialidadeId);
            return View(profissionalModel);
        }

        // GET: Profissional/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissionalModel = await _context.PROFISSIONAL
                .Include(p => p.Especialidade)
                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profissionalModel == null)
            {
                return NotFound();
            }

            return View(profissionalModel);
        }

        // POST: Profissional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var profissionalModel = await _context.PROFISSIONAL.FindAsync(id);
            if (profissionalModel != null)
            {
                _context.PROFISSIONAL.Remove(profissionalModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfissionalModelExists(Guid id)
        {
            return _context.PROFISSIONAL.Any(e => e.Id == id);
        }
    }
}
