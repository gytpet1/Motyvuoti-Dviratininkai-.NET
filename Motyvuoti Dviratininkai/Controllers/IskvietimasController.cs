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
    public class IskvietimasController : Controller
    {
        private readonly Motyvuoti_DviratininkaiContext _context;

        public IskvietimasController(Motyvuoti_DviratininkaiContext context)
        {
            _context = context;
        }

        // GET: Iskvietimas
        public async Task<IActionResult> Index()
        {
            var motyvuoti_DviratininkaiContext = _context.Iskvietimas.Include(i => i.Darbuotojas).Include(i => i.Klientas);
            return View(await motyvuoti_DviratininkaiContext.ToListAsync());
        }

        // GET: Iskvietimas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iskvietimas = await _context.Iskvietimas
                .Include(i => i.Darbuotojas)
                .Include(i => i.Klientas)
                .FirstOrDefaultAsync(m => m.IskvietimasId == id);
            if (iskvietimas == null)
            {
                return NotFound();
            }

            return View(iskvietimas);
        }

        // GET: Iskvietimas/Create
        public IActionResult Create()
        {
            ViewData["DarbuotojasId"] = new SelectList(_context.Darbuotojas, "DarbuotojasId", "DarbuotojasId");
            ViewData["KlientasId"] = new SelectList(_context.Set<Klientas>(), "KlientasId", "KlientasId");
            return View();
        }

        // POST: Iskvietimas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IskvietimasId,Apibudinimas,KlientasId,DarbuotojasId")] Iskvietimas iskvietimas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iskvietimas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DarbuotojasId"] = new SelectList(_context.Darbuotojas, "DarbuotojasId", "DarbuotojasId", iskvietimas.DarbuotojasId);
            ViewData["KlientasId"] = new SelectList(_context.Set<Klientas>(), "KlientasId", "KlientasId", iskvietimas.KlientasId);
            return View(iskvietimas);
        }

        // GET: Iskvietimas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iskvietimas = await _context.Iskvietimas.FindAsync(id);
            if (iskvietimas == null)
            {
                return NotFound();
            }
            ViewData["DarbuotojasId"] = new SelectList(_context.Darbuotojas, "DarbuotojasId", "DarbuotojasId", iskvietimas.DarbuotojasId);
            ViewData["KlientasId"] = new SelectList(_context.Set<Klientas>(), "KlientasId", "KlientasId", iskvietimas.KlientasId);
            return View(iskvietimas);
        }

        // POST: Iskvietimas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IskvietimasId,Apibudinimas,KlientasId,DarbuotojasId")] Iskvietimas iskvietimas)
        {
            if (id != iskvietimas.IskvietimasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iskvietimas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IskvietimasExists(iskvietimas.IskvietimasId))
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
            ViewData["DarbuotojasId"] = new SelectList(_context.Darbuotojas, "DarbuotojasId", "DarbuotojasId", iskvietimas.DarbuotojasId);
            ViewData["KlientasId"] = new SelectList(_context.Set<Klientas>(), "KlientasId", "KlientasId", iskvietimas.KlientasId);
            return View(iskvietimas);
        }

        // GET: Iskvietimas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iskvietimas = await _context.Iskvietimas
                .Include(i => i.Darbuotojas)
                .Include(i => i.Klientas)
                .FirstOrDefaultAsync(m => m.IskvietimasId == id);
            if (iskvietimas == null)
            {
                return NotFound();
            }

            return View(iskvietimas);
        }

        // POST: Iskvietimas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iskvietimas = await _context.Iskvietimas.FindAsync(id);
            _context.Iskvietimas.Remove(iskvietimas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IskvietimasExists(int id)
        {
            return _context.Iskvietimas.Any(e => e.IskvietimasId == id);
        }
    }
}
