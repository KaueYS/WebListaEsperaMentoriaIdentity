using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebListaEsperaMentoriaIdentity.Data;
using WebListaEsperaMentoriaIdentity.Models;
using WebListaEsperaMentoriaIdentity.ViewModels;

namespace WebListaEsperaMentoriaIdentity.Controllers
{
    public class ProfissionalController : Controller
    {
        private readonly AppDbContext _context;

        public ProfissionalController(AppDbContext context)
        {
            _context = context;
        }


        //public IActionResult EscolherProfissional()
        //{
        //    PacientelViewModel escolherProfissionalViewModel = new PacientelViewModel();

            
        //    List<SelectListItem> listItems = new List<SelectListItem>();
        //    listItems.Add(new SelectListItem("Selecione", string.Empty, true));

        //    var profissionais = _context.PROFISSIONAL.ToList();
        //    foreach (var profissional in profissionais)
        //    {
        //        listItems.Add(new SelectListItem(profissional.Nome, profissional.Id.ToString()));
        //    }
        //    escolherProfissionalViewModel.Profissionais = listItems;

        //    return View(escolherProfissionalViewModel);
        //}
        //[HttpPost]
        //public IActionResult EscolherProfissional(PacientelViewModel pacienteViewModel)
            

        //{
            
        //    return View();

        //}


        // GET: Profissional
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PROFISSIONAL.Include(p => p.Especialidade);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Profissional/Details/5
        public async Task<IActionResult> Details(int? id)
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
            ViewData["EspecialidadeId"] = new SelectList(_context.ESPECIALIDADE, "Id", "Id");
            return View();
        }

        // POST: Profissional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,EspecialidadeId")] ProfissionalModel profissionalModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profissionalModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecialidadeId"] = new SelectList(_context.ESPECIALIDADE, "Id", "Id", profissionalModel.EspecialidadeId);
            return View(profissionalModel);
        }

        // GET: Profissional/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["EspecialidadeId"] = new SelectList(_context.ESPECIALIDADE, "Id", "Id", profissionalModel.EspecialidadeId);
            return View(profissionalModel);
        }

        // POST: Profissional/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,EspecialidadeId")] ProfissionalModel profissionalModel)
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
        public async Task<IActionResult> Delete(int? id)
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profissionalModel = await _context.PROFISSIONAL.FindAsync(id);
            if (profissionalModel != null)
            {
                _context.PROFISSIONAL.Remove(profissionalModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfissionalModelExists(int id)
        {
            return _context.PROFISSIONAL.Any(e => e.Id == id);
        }
    }
}
