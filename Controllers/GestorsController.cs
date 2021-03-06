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
    public class GestorsController : Controller
    {
        private readonly ProjetoGestaoContext _context;

        public GestorsController(ProjetoGestaoContext context)
        {
            _context = context;
        }

        // GET: Gestors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gestor.ToListAsync());
        }

        // GET: Gestors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestor = await _context.Gestor
                .FirstOrDefaultAsync(m => m.GestorId == id);
            if (gestor == null)
            {
                return NotFound();
            }

            return View(gestor);
        }

        // GET: Gestors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gestors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GestorId,NomeGestor,Apelido,NumeroTelemovel,Email,DataNascimento,Genero,Endereco,ExperienciaComoGestor")] Gestor gestor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gestor);
                await _context.SaveChangesAsync();
                ViewBag.Title = "Gestor Adicionado";
                ViewBag.Message = "Gestor Adicionado com  Sucesso";
                return View("Success");
            }
            return View(gestor);
        }

        // GET: Gestors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestor = await _context.Gestor.FindAsync(id);
            if (gestor == null)
            {
                return NotFound();
            }
            return View(gestor);
        }

        // POST: Gestors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GestorId,NomeGestor,Apelido,NumeroTelemovel,Email,DataNascimento,Genero,Endereco,ExperienciaComoGestor")] Gestor gestor)
        {
            if (id != gestor.GestorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gestor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GestorExists(gestor.GestorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Title = "Gestor Editado";
                ViewBag.Message = "Gestor Editado com Sucesso";
                return View("Success");
            }
            return View(gestor);
        }

        // GET: Gestors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestor = await _context.Gestor
                .FirstOrDefaultAsync(m => m.GestorId == id);
            if (gestor == null)
            {
                return NotFound();
            }

            return View(gestor);
        }

        // POST: Gestors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gestor = await _context.Gestor.FindAsync(id);
            _context.Gestor.Remove(gestor);
            await _context.SaveChangesAsync();
            ViewBag.Title = "Gestor Eliminado";
            ViewBag.Message = "Gestor Eliminado com Sucesso.";
            return View("Success");
        }

        private bool GestorExists(int id)
        {
            return _context.Gestor.Any(e => e.GestorId == id);
        }
    }
}
