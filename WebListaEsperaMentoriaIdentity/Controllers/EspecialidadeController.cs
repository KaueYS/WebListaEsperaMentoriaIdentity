using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebListaEsperaMentoriaIdentity.Data;
using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.Controllers
{
    public class EspecialidadeController : Controller
    {
        private readonly AppDbContext _context;

        public EspecialidadeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Especialidade
        public async Task<IActionResult> Index()
        {
            return View(await _context.ESPECIALIDADE.ToListAsync());
        }

        // GET: Especialidade/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidadeModel = await _context.ESPECIALIDADE
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especialidadeModel == null)
            {
                return NotFound();
            }

            return View(especialidadeModel);
        }

        // GET: Especialidade/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Especialidade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] EspecialidadeModel especialidadeModel)
        {
            if (ModelState.IsValid)
            {
                especialidadeModel.Id = Guid.NewGuid();
                _context.Add(especialidadeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidadeModel);
        }

        // GET: Especialidade/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidadeModel = await _context.ESPECIALIDADE.FindAsync(id);
            if (especialidadeModel == null)
            {
                return NotFound();
            }
            return View(especialidadeModel);
        }

        // POST: Especialidade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome")] EspecialidadeModel especialidadeModel)
        {
            if (id != especialidadeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especialidadeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecialidadeModelExists(especialidadeModel.Id))
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
            return View(especialidadeModel);
        }

        // GET: Especialidade/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidadeModel = await _context.ESPECIALIDADE
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especialidadeModel == null)
            {
                return NotFound();
            }

            return View(especialidadeModel);
        }

        // POST: Especialidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var especialidadeModel = await _context.ESPECIALIDADE.FindAsync(id);
            if (especialidadeModel != null)
            {
                _context.ESPECIALIDADE.Remove(especialidadeModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecialidadeModelExists(Guid id)
        {
            return _context.ESPECIALIDADE.Any(e => e.Id == id);
        }
    }
}
