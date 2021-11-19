using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoGestao.Data;
using ProjetoGestao.Models;

namespace ProjetoGestao.Controllers
{
    public class NovoGestorController : Controller
    {
        private readonly ProjetoGestaoContext _context;

        public NovoGestorController(ProjetoGestaoContext context)
        {
            _context = context;
        }

        // GET: NovoGestor
        public async Task<IActionResult> Index()
        {
            return View(await _context.NovoGestor.ToListAsync());
        }

        // GET: NovoGestor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novoGestor = await _context.NovoGestor
                .FirstOrDefaultAsync(m => m.NovoGestorId == id);
            if (novoGestor == null)
            {
                return NotFound();
            }

            return View(novoGestor);
        }

        // GET: NovoGestor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NovoGestor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NovoGestorId,NomeGestor")] NovoGestor novoGestor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(novoGestor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(novoGestor);
        }

        // GET: NovoGestor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novoGestor = await _context.NovoGestor.FindAsync(id);
            if (novoGestor == null)
            {
                return NotFound();
            }
            return View(novoGestor);
        }

        // POST: NovoGestor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NovoGestorId,NomeGestor")] NovoGestor novoGestor)
        {
            if (id != novoGestor.NovoGestorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(novoGestor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NovoGestorExists(novoGestor.NovoGestorId))
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
            return View(novoGestor);
        }

        // GET: NovoGestor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novoGestor = await _context.NovoGestor
                .FirstOrDefaultAsync(m => m.NovoGestorId == id);
            if (novoGestor == null)
            {
                return NotFound();
            }

            return View(novoGestor);
        }

        // POST: NovoGestor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var novoGestor = await _context.NovoGestor.FindAsync(id);
            _context.NovoGestor.Remove(novoGestor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NovoGestorExists(int id)
        {
            return _context.NovoGestor.Any(e => e.NovoGestorId == id);
        }
    }
}
