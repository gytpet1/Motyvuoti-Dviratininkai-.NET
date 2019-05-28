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
    public class KlientasController : Controller
    {
        private readonly Motyvuoti_DviratininkaiContext _context;

        public KlientasController(Motyvuoti_DviratininkaiContext context)
        {
            _context = context;
        }

        // GET: Klientas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Klientas.ToListAsync());
        }

        // GET: Klientas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klientas = await _context.Klientas
                .FirstOrDefaultAsync(m => m.KlientasId == id);
            if (klientas == null)
            {
                return NotFound();
            }

            return View(klientas);
        }

        // GET: Klientas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klientas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KlientasId,elPastas,Slaptazodis,telNumeris,Pavarde,Vardas")] Klientas klientas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klientas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klientas);
        }

        // GET: Klientas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klientas = await _context.Klientas.FindAsync(id);
            if (klientas == null)
            {
                return NotFound();
            }
            return View(klientas);
        }

        // POST: Klientas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KlientasId,elPastas,Slaptazodis,telNumeris,Pavarde,Vardas")] Klientas klientas)
        {
            if (id != klientas.KlientasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klientas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlientasExists(klientas.KlientasId))
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
            return View(klientas);
        }

        // GET: Klientas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klientas = await _context.Klientas
                .FirstOrDefaultAsync(m => m.KlientasId == id);
            if (klientas == null)
            {
                return NotFound();
            }

            return View(klientas);
        }

        // POST: Klientas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klientas = await _context.Klientas.FindAsync(id);
            _context.Klientas.Remove(klientas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlientasExists(int id)
        {
            return _context.Klientas.Any(e => e.KlientasId == id);
        }
    }
}
