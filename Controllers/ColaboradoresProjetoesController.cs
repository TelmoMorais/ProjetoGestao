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
    public class ColaboradoresProjetoesController : Controller
    {
        private readonly ProjetoGestaoContext _context;

        public ColaboradoresProjetoesController(ProjetoGestaoContext context)
        {
            _context = context;
        }

        // GET: ColaboradoresProjetoes
        public async Task<IActionResult> Index()
        {
            var projetoGestaoContext = _context.ColaboradoresProjeto.Include(c => c.Colaborador).Include(c => c.Projeto);
            return View(await projetoGestaoContext.ToListAsync());
        }

        // GET: ColaboradoresProjetoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradoresProjeto = await _context.ColaboradoresProjeto
                .Include(c => c.Colaborador)
                .Include(c => c.Projeto)
                .FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (colaboradoresProjeto == null)
            {
                return NotFound();
            }

            return View(colaboradoresProjeto);
        }

        // GET: ColaboradoresProjetoes/Create
        public IActionResult Create()
        {
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Apelido");
            ViewData["ProjetoId"] = new SelectList(_context.Projeto, "ProjetoId", "DataEfetivaFim");
            return View();
        }

        // POST: ColaboradoresProjetoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjetoId,ColaboradorId")] ColaboradoresProjeto colaboradoresProjeto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaboradoresProjeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Apelido", colaboradoresProjeto.ColaboradorId);
            ViewData["ProjetoId"] = new SelectList(_context.Projeto, "ProjetoId", "DataEfetivaFim", colaboradoresProjeto.ProjetoId);
            return View(colaboradoresProjeto);
        }

        // GET: ColaboradoresProjetoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradoresProjeto = await _context.ColaboradoresProjeto.FindAsync(id);
            if (colaboradoresProjeto == null)
            {
                return NotFound();
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Apelido", colaboradoresProjeto.ColaboradorId);
            ViewData["ProjetoId"] = new SelectList(_context.Projeto, "ProjetoId", "DataEfetivaFim", colaboradoresProjeto.ProjetoId);
            return View(colaboradoresProjeto);
        }

        // POST: ColaboradoresProjetoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjetoId,ColaboradorId")] ColaboradoresProjeto colaboradoresProjeto)
        {
            if (id != colaboradoresProjeto.ProjetoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaboradoresProjeto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradoresProjetoExists(colaboradoresProjeto.ProjetoId))
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
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Apelido", colaboradoresProjeto.ColaboradorId);
            ViewData["ProjetoId"] = new SelectList(_context.Projeto, "ProjetoId", "DataEfetivaFim", colaboradoresProjeto.ProjetoId);
            return View(colaboradoresProjeto);
        }

        // GET: ColaboradoresProjetoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradoresProjeto = await _context.ColaboradoresProjeto
                .Include(c => c.Colaborador)
                .Include(c => c.Projeto)
                .FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (colaboradoresProjeto == null)
            {
                return NotFound();
            }

            return View(colaboradoresProjeto);
        }

        // POST: ColaboradoresProjetoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colaboradoresProjeto = await _context.ColaboradoresProjeto.FindAsync(id);
            _context.ColaboradoresProjeto.Remove(colaboradoresProjeto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboradoresProjetoExists(int id)
        {
            return _context.ColaboradoresProjeto.Any(e => e.ProjetoId == id);
        }
    }
}
