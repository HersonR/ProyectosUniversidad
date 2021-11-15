using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamenFinal01.Data;
using ExamenFinal01.Models;

namespace ExamenFinal01
{
    public class CatedraticoesController : Controller
    {
        private readonly ExamenFinal01Context _context;

        public CatedraticoesController(ExamenFinal01Context context)
        {
            _context = context;
        }

        // GET: Catedraticoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Catedratico.ToListAsync());
        }

        // GET: Catedraticoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catedratico = await _context.Catedratico
                .FirstOrDefaultAsync(m => m.CodigoCatedratico == id);
            if (catedratico == null)
            {
                return NotFound();
            }

            return View(catedratico);
        }

        // GET: Catedraticoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catedraticoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoCatedratico,NombresCatedratico,ApellidosCatedratico,EstadoCatedratico")] Catedratico catedratico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catedratico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catedratico);
        }

        // GET: Catedraticoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catedratico = await _context.Catedratico.FindAsync(id);
            if (catedratico == null)
            {
                return NotFound();
            }
            return View(catedratico);
        }

        // POST: Catedraticoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoCatedratico,NombresCatedratico,ApellidosCatedratico,EstadoCatedratico")] Catedratico catedratico)
        {
            if (id != catedratico.CodigoCatedratico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catedratico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatedraticoExists(catedratico.CodigoCatedratico))
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
            return View(catedratico);
        }

        // GET: Catedraticoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catedratico = await _context.Catedratico
                .FirstOrDefaultAsync(m => m.CodigoCatedratico == id);
            if (catedratico == null)
            {
                return NotFound();
            }

            return View(catedratico);
        }

        // POST: Catedraticoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catedratico = await _context.Catedratico.FindAsync(id);
            _context.Catedratico.Remove(catedratico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatedraticoExists(int id)
        {
            return _context.Catedratico.Any(e => e.CodigoCatedratico == id);
        }
    }
}
