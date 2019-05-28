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
    public class DarbuotojasController : Controller
    {
        private readonly Motyvuoti_DviratininkaiContext _context;

        public DarbuotojasController(Motyvuoti_DviratininkaiContext context)
        {
            _context = context;
        }

        // GET: Darbuotojas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Darbuotojas.ToListAsync());
        }

        // GET: Darbuotojas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var darbuotojas = await _context.Darbuotojas
                .FirstOrDefaultAsync(m => m.DarbuotojasId == id);
            if (darbuotojas == null)
            {
                return NotFound();
            }

            return View(darbuotojas);
        }

        // GET: Darbuotojas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Darbuotojas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DarbuotojasId,Vardas,elPastas,Slaptazodis,Pavarde,tabelioNr,Pareigos")] Darbuotojas darbuotojas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(darbuotojas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(darbuotojas);
        }

        // GET: Darbuotojas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var darbuotojas = await _context.Darbuotojas.FindAsync(id);
            if (darbuotojas == null)
            {
                return NotFound();
            }
            return View(darbuotojas);
        }

        // POST: Darbuotojas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DarbuotojasId,Vardas,elPastas,Slaptazodis,Pavarde,tabelioNr,Pareigos")] Darbuotojas darbuotojas)
        {
            if (id != darbuotojas.DarbuotojasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(darbuotojas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DarbuotojasExists(darbuotojas.DarbuotojasId))
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
            return View(darbuotojas);
        }

        // GET: Darbuotojas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var darbuotojas = await _context.Darbuotojas
                .FirstOrDefaultAsync(m => m.DarbuotojasId == id);
            if (darbuotojas == null)
            {
                return NotFound();
            }

            return View(darbuotojas);
        }

        // POST: Darbuotojas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var darbuotojas = await _context.Darbuotojas.FindAsync(id);
            _context.Darbuotojas.Remove(darbuotojas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DarbuotojasExists(int id)
        {
            return _context.Darbuotojas.Any(e => e.DarbuotojasId == id);
        }
    }
}
