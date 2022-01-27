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
    public class RelatoriosController : Controller
    {
        private readonly ProjetoGestaoContext _context;

        public RelatoriosController(ProjetoGestaoContext context)
        {
            _context = context;
        }

        // GET: Relatorios
        public async Task<IActionResult> Index()
        {
            var projetoGestaoContext = _context.Relatorio.Include(r => r.Projeto);
            return View(await projetoGestaoContext.ToListAsync());
        }

        // GET: Relatorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorio = await _context.Relatorio
                .Include(r => r.Projeto)
                .FirstOrDefaultAsync(m => m.RelatorioId == id);
            if (relatorio == null)
            {
                return NotFound();
            }

            return View(relatorio);
        }

        // GET: Relatorios/Create
        public IActionResult Create()
        {
            ViewData["ProjetoId"] = new SelectList(_context.Projeto, "ProjetoId", "DataEfetivaFim");
            return View();
        }

        // POST: Relatorios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RelatorioId,NomeRelatorio,DataEfetivaInicio,ProjetoId")] Relatorio relatorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relatorio);
                await _context.SaveChangesAsync();

                ViewBag.Title = "Relatório Adicionado";
                ViewBag.Message = "Relatório Adicionado com Sucesso";
                return View("Success");
            }
            ViewData["ProjetoId"] = new SelectList(_context.Projeto, "ProjetoId", "DataEfetivaFim", relatorio.ProjetoId);
            return View(relatorio);
        }

        // GET: Relatorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorio = await _context.Relatorio.FindAsync(id);
            if (relatorio == null)
            {
                return NotFound();
            }
            ViewData["ProjetoId"] = new SelectList(_context.Projeto, "ProjetoId", "DataEfetivaFim", relatorio.ProjetoId);
            return View(relatorio);
        }

        // POST: Relatorios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RelatorioId,NomeRelatorio,DataEfetivaInicio,ProjetoId")] Relatorio relatorio)
        {
            if (id != relatorio.RelatorioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relatorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelatorioExists(relatorio.RelatorioId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                ViewBag.Title = "Relatório Editado";
                ViewBag.Message = "Relatório Editado com Sucesso";
                return View("Success");

            }
            ViewData["ProjetoId"] = new SelectList(_context.Projeto, "ProjetoId", "DataEfetivaFim", relatorio.ProjetoId);
            return View(relatorio);
        }

        // GET: Relatorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorio = await _context.Relatorio
                .Include(r => r.Projeto)
                .FirstOrDefaultAsync(m => m.RelatorioId == id);
            if (relatorio == null)
            {
                return NotFound();
            }

            return View(relatorio);
        }

        // POST: Relatorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relatorio = await _context.Relatorio.FindAsync(id);
            _context.Relatorio.Remove(relatorio);
            await _context.SaveChangesAsync();

            ViewBag.Title = "Relatório Eliminado";
            ViewBag.Message = "Relatório Eliminado com Sucesso";
            return View("Success");
        }

        private bool RelatorioExists(int id)
        {
            return _context.Relatorio.Any(e => e.RelatorioId == id);
        }
    }
}
