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
    public class ProjetoesController : Controller
    {
        private readonly ProjetoGestaoContext _context;

        public ProjetoesController(ProjetoGestaoContext context)
        {
            _context = context;
        }

        // GET: Projetoes
        public async Task<IActionResult> Index()
        {
            var projetoGestaoContext = _context.Projeto.Include(p => p.Cliente).Include(p => p.Gestor);
            return View(await projetoGestaoContext.ToListAsync());
        }

        // GET: Projetoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto
                .Include(p => p.Cliente)
                .Include(p => p.Gestor)
                .FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // GET: Projetoes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Apelido");
            ViewData["GestorId"] = new SelectList(_context.Gestor, "GestorId", "Apelido");
            return View();
        }

        // POST: Projetoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjetoId,NomeProjeto,DescricaoProjeto,DataPrevistaInicio,DataEfetivaInicio,DataEfetivaFim,DataPrevistaFim,GestorId,ClienteId")] Projeto projeto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Apelido", projeto.ClienteId);
            ViewData["GestorId"] = new SelectList(_context.Gestor, "GestorId", "Apelido", projeto.GestorId);
            return View(projeto);
        }

        // GET: Projetoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto.FindAsync(id);
            if (projeto == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Apelido", projeto.ClienteId);
            ViewData["GestorId"] = new SelectList(_context.Gestor, "GestorId", "Apelido", projeto.GestorId);
            return View(projeto);
        }

        // POST: Projetoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjetoId,NomeProjeto,DescricaoProjeto,DataPrevistaInicio,DataEfetivaInicio,DataEfetivaFim,DataPrevistaFim,GestorId,ClienteId")] Projeto projeto)
        {
            if (id != projeto.ProjetoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projeto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetoExists(projeto.ProjetoId))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Apelido", projeto.ClienteId);
            ViewData["GestorId"] = new SelectList(_context.Gestor, "GestorId", "Apelido", projeto.GestorId);
            return View(projeto);
        }

        // GET: Projetoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto
                .Include(p => p.Cliente)
                .Include(p => p.Gestor)
                .FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // POST: Projetoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projeto = await _context.Projeto.FindAsync(id);
            _context.Projeto.Remove(projeto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetoExists(int id)
        {
            return _context.Projeto.Any(e => e.ProjetoId == id);
        }
    }
}
