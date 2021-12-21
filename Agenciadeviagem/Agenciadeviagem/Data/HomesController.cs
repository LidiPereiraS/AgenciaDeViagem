using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agenciadeviagem.Models;

namespace Agenciadeviagem.Data
{
    public class HomesController : Controller
    {
        private readonly AgenciaDeViagemContext _context;

        public HomesController(AgenciaDeViagemContext context)
        {
            _context = context;
        }

        // GET: Homes
        public async Task<IActionResult> Index()
        {
            var agenciaDeViagemContext = _context.Home.Include(h => h.Contato).Include(h => h.Destino);
            return View(await agenciaDeViagemContext.ToListAsync());
        }

        // GET: Homes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Home
                .Include(h => h.Contato)
                .Include(h => h.Destino)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // GET: Homes/Create
        public IActionResult Create()
        {
            ViewData["ContatoID"] = new SelectList(_context.Contato, "ID", "Endereco");
            ViewData["DestinoID"] = new SelectList(_context.Destino, "ID", "Ciadade");
            return View();
        }

        // POST: Homes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Promocao,Preco,ContatoID,DestinoID")] Home home)
        {
            if (ModelState.IsValid)
            {
                _context.Add(home);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContatoID"] = new SelectList(_context.Contato, "ID", "Endereco", home.ContatoID);
            ViewData["DestinoID"] = new SelectList(_context.Destino, "ID", "Ciadade", home.DestinoID);
            return View(home);
        }

        // GET: Homes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Home.FindAsync(id);
            if (home == null)
            {
                return NotFound();
            }
            ViewData["ContatoID"] = new SelectList(_context.Contato, "ID", "Endereco", home.ContatoID);
            ViewData["DestinoID"] = new SelectList(_context.Destino, "ID", "Ciadade", home.DestinoID);
            return View(home);
        }

        // POST: Homes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Promocao,Preco,ContatoID,DestinoID")] Home home)
        {
            if (id != home.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(home);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeExists(home.ID))
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
            ViewData["ContatoID"] = new SelectList(_context.Contato, "ID", "Endereco", home.ContatoID);
            ViewData["DestinoID"] = new SelectList(_context.Destino, "ID", "Ciadade", home.DestinoID);
            return View(home);
        }

        // GET: Homes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Home
                .Include(h => h.Contato)
                .Include(h => h.Destino)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // POST: Homes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var home = await _context.Home.FindAsync(id);
            _context.Home.Remove(home);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeExists(int id)
        {
            return _context.Home.Any(e => e.ID == id);
        }
    }
}
