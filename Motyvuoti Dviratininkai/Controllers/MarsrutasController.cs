using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Motyvuoti_Dviratininkai.Models;

namespace Motyvuoti_Dviratininkai.Controllers
{
    public class MarsrutasController : Controller
    {
        private readonly Motyvuoti_DviratininkaiContext _context;

        public MarsrutasController(Motyvuoti_DviratininkaiContext context)
        {
            _context = context;
        }

        // GET: Marsrutas
        public async Task<IActionResult> Index()
        {
            var motyvuoti_DviratininkaiContext = _context.Marsrutas.Include(m => m.Klientas);
            return View(await motyvuoti_DviratininkaiContext.ToListAsync());
        }

        // GET: Marsrutas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marsrutas = await _context.Marsrutas
                .Include(m => m.Klientas)
                .FirstOrDefaultAsync(m => m.MarsrutasId == id);
            if (marsrutas == null)
            {
                return NotFound();
            }

            return View(marsrutas);
        }

        // GET: Marsrutas/Create
        public IActionResult Create()
        {
            ViewData["KlientasId"] = new SelectList(_context.Klientas, "KlientasId", "KlientasId");
            return View();
        }

        // POST: Marsrutas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MarsrutasId,Pavadinimas,Kategorija,Miestas,Ivertinimas,Ilgis,KlientasId")] Marsrutas marsrutas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marsrutas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlientasId"] = new SelectList(_context.Klientas, "KlientasId", "KlientasId", marsrutas.KlientasId);
            return View(marsrutas);
        }

        // GET: Marsrutas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marsrutas = await _context.Marsrutas.FindAsync(id);
            if (marsrutas == null)
            {
                return NotFound();
            }
            ViewData["KlientasId"] = new SelectList(_context.Klientas, "KlientasId", "KlientasId", marsrutas.KlientasId);
            return View(marsrutas);
        }

        // POST: Marsrutas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MarsrutasId,Pavadinimas,Kategorija,Miestas,Ivertinimas,Ilgis,KlientasId")] Marsrutas marsrutas)
        {
            if (id != marsrutas.MarsrutasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marsrutas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarsrutasExists(marsrutas.MarsrutasId))
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
            ViewData["KlientasId"] = new SelectList(_context.Klientas, "KlientasId", "KlientasId", marsrutas.KlientasId);
            return View(marsrutas);
        }

        // GET: Marsrutas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marsrutas = await _context.Marsrutas
                .Include(m => m.Klientas)
                .FirstOrDefaultAsync(m => m.MarsrutasId == id);
            if (marsrutas == null)
            {
                return NotFound();
            }

            return View(marsrutas);
        }

        // POST: Marsrutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marsrutas = await _context.Marsrutas.FindAsync(id);
            _context.Marsrutas.Remove(marsrutas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarsrutasExists(int id)
        {
            return _context.Marsrutas.Any(e => e.MarsrutasId == id);
        }
    }
}
