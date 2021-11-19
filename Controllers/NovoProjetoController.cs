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
    public class NovoProjetoController : Controller
    {
        private readonly ProjetoGestaoContext _context;

        public NovoProjetoController(ProjetoGestaoContext context)
        {
            _context = context;
        }

        // GET: NovoProjeto
        public async Task<IActionResult> Index()
        {
            var projetoGestaoContext = _context.NovoProjeto.Include(n => n.NovoGestor);
            return View(await projetoGestaoContext.ToListAsync());
        }

        // GET: NovoProjeto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novoProjeto = await _context.NovoProjeto
                .Include(n => n.NovoGestor)
                .FirstOrDefaultAsync(m => m.NovoProjetoId == id);
            if (novoProjeto == null)
            {
                return NotFound();
            }

            return View(novoProjeto);
        }

        // GET: NovoProjeto/Create
        public IActionResult Create()
        {
            ViewData["NovoGestorId"] = new SelectList(_context.Set<NovoGestor>(), "NovoGestorId", "NomeGestor");
            return View();
        }

        // POST: NovoProjeto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NovoProjetoId,NomeProjeto,DescricaoProjeto,NovoGestorId")] NovoProjeto novoProjeto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(novoProjeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NovoGestorId"] = new SelectList(_context.Set<NovoGestor>(), "NovoGestorId", "NomeGestor", novoProjeto.NovoGestorId);
            return View(novoProjeto);
        }

        // GET: NovoProjeto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novoProjeto = await _context.NovoProjeto.FindAsync(id);
            if (novoProjeto == null)
            {
                return NotFound();
            }
            ViewData["NovoGestorId"] = new SelectList(_context.Set<NovoGestor>(), "NovoGestorId", "NomeGestor", novoProjeto.NovoGestorId);
            return View(novoProjeto);
        }

        // POST: NovoProjeto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NovoProjetoId,NomeProjeto,DescricaoProjeto,NovoGestorId")] NovoProjeto novoProjeto)
        {
            if (id != novoProjeto.NovoProjetoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(novoProjeto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NovoProjetoExists(novoProjeto.NovoProjetoId))
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
            ViewData["NovoGestorId"] = new SelectList(_context.Set<NovoGestor>(), "NovoGestorId", "NomeGestor", novoProjeto.NovoGestorId);
            return View(novoProjeto);
        }

        // GET: NovoProjeto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novoProjeto = await _context.NovoProjeto
                .Include(n => n.NovoGestor)
                .FirstOrDefaultAsync(m => m.NovoProjetoId == id);
            if (novoProjeto == null)
            {
                return NotFound();
            }

            return View(novoProjeto);
        }

        // POST: NovoProjeto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var novoProjeto = await _context.NovoProjeto.FindAsync(id);
            _context.NovoProjeto.Remove(novoProjeto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NovoProjetoExists(int id)
        {
            return _context.NovoProjeto.Any(e => e.NovoProjetoId == id);
        }
    }
}
