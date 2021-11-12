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
    public class NovoColaboradorController : Controller
    {
        private readonly ProjetoGestaoContext _context;

        public NovoColaboradorController(ProjetoGestaoContext context)
        {
            _context = context;
        }

        // GET: NovoColaborador
        public async Task<IActionResult> Index()
        {
            return View(await _context.NovoColaborador.ToListAsync());
        }

        // GET: NovoColaborador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novoColaborador = await _context.NovoColaborador
                .FirstOrDefaultAsync(m => m.NovoColaboradorId == id);
            if (novoColaborador == null)
            {
                return NotFound();
            }

            return View(novoColaborador);
        }

        // GET: NovoColaborador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NovoColaborador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NovoColaboradorId,NomeColaborador")] NovoColaborador novoColaborador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(novoColaborador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(novoColaborador);
        }

        // GET: NovoColaborador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novoColaborador = await _context.NovoColaborador.FindAsync(id);
            if (novoColaborador == null)
            {
                return NotFound();
            }
            return View(novoColaborador);
        }

        // POST: NovoColaborador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NovoColaboradorId,NomeColaborador")] NovoColaborador novoColaborador)
        {
            if (id != novoColaborador.NovoColaboradorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(novoColaborador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NovoColaboradorExists(novoColaborador.NovoColaboradorId))
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
            return View(novoColaborador);
        }

        // GET: NovoColaborador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novoColaborador = await _context.NovoColaborador
                .FirstOrDefaultAsync(m => m.NovoColaboradorId == id);
            if (novoColaborador == null)
            {
                return NotFound();
            }

            return View(novoColaborador);
        }

        // POST: NovoColaborador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var novoColaborador = await _context.NovoColaborador.FindAsync(id);
            _context.NovoColaborador.Remove(novoColaborador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NovoColaboradorExists(int id)
        {
            return _context.NovoColaborador.Any(e => e.NovoColaboradorId == id);
        }
    }
}
