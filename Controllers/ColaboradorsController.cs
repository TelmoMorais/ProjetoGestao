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
    public class ColaboradorsController : Controller
    {
        private readonly ProjetoGestaoContext _context;

        public ColaboradorsController(ProjetoGestaoContext context)
        {
            _context = context;
        }

        // GET: Colaboradors
        public async Task<IActionResult> Index()
        {
            var projetoGestaoContext = _context.Colaborador.Include(c => c.Funcao);
            return View(await projetoGestaoContext.ToListAsync());
        }

        // GET: Colaboradors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador
                .Include(c => c.Funcao)
                .FirstOrDefaultAsync(m => m.ColaboradorId == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // GET: Colaboradors/Create
        public IActionResult Create()
        {
            ViewData["FuncaoId"] = new SelectList(_context.Funcao, "FuncaoId", "NomeFuncao");
            return View();
        }

        // POST: Colaboradors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColaboradorId,NomeColaborador,Apelido,NumeroTelemovel,Email,DataNascimento,Genero,Endereco,FuncaoId")] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaborador);
                await _context.SaveChangesAsync();

                ViewBag.Title = "Gestor Adicionado";
                ViewBag.Message = "Gestor Adicionado com  Sucesso";
                return View("Success");
            }
            ViewData["FuncaoId"] = new SelectList(_context.Funcao, "FuncaoId", "NomeFuncao", colaborador.FuncaoId);
            return View(colaborador);
        }

        // GET: Colaboradors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador.FindAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }
            ViewData["FuncaoId"] = new SelectList(_context.Funcao, "FuncaoId", "NomeFuncao", colaborador.FuncaoId);
            return View(colaborador);
        }

        // POST: Colaboradors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColaboradorId,NomeColaborador,Apelido,NumeroTelemovel,Email,DataNascimento,Genero,Endereco,FuncaoId")] Colaborador colaborador)
        {
            if (id != colaborador.ColaboradorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaborador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradorExists(colaborador.ColaboradorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                ViewBag.Title = "Projeto Editado";
                ViewBag.Message = "Projeto Editado com Sucesso";
                return View("Success");
            }
            ViewData["FuncaoId"] = new SelectList(_context.Funcao, "FuncaoId", "NomeFuncao", colaborador.FuncaoId);
            return View(colaborador);
        }

        // GET: Colaboradors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador
                .Include(c => c.Funcao)
                .FirstOrDefaultAsync(m => m.ColaboradorId == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // POST: Colaboradors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colaborador = await _context.Colaborador.FindAsync(id);
            _context.Colaborador.Remove(colaborador);
            await _context.SaveChangesAsync();

            ViewBag.Title = "Projeto Eliminado";
            ViewBag.Message = "Projeto Eliminado com Sucesso";
            return View("Success");
        }

        private bool ColaboradorExists(int id)
        {
            return _context.Colaborador.Any(e => e.ColaboradorId == id);
        }
    }
}
