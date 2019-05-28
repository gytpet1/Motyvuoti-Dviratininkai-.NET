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
    public class GedimasController : Controller
    {
        private readonly Motyvuoti_DviratininkaiContext _context;

        public GedimasController(Motyvuoti_DviratininkaiContext context)
        {
            _context = context;
        }

        // GET: Gedimas
        public async Task<IActionResult> Index()
        {
            var motyvuoti_DviratininkaiContext = _context.Gedimas.Include(g => g.Dviratis).Include(g => g.Klientas);
            return View(await motyvuoti_DviratininkaiContext.ToListAsync());
        }

        // GET: Gedimas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gedimas = await _context.Gedimas
                .Include(g => g.Dviratis)
                .Include(g => g.Klientas)
                .FirstOrDefaultAsync(m => m.GedimasId == id);
            if (gedimas == null)
            {
                return NotFound();
            }

            return View(gedimas);
        }

        // GET: Gedimas/Create
        public IActionResult Create()
        {
            ViewData["DviratisId"] = new SelectList(_context.Dviratis, "DviratisId", "DviratisId");
            ViewData["KlientasId"] = new SelectList(_context.Set<Klientas>(), "KlientasId", "KlientasId");
            return View();
        }

        // POST: Gedimas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GedimasId,registravimoLaikas,Apibudinimas,DviratisId,KlientasId")] Gedimas gedimas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gedimas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DviratisId"] = new SelectList(_context.Dviratis, "DviratisId", "DviratisId", gedimas.DviratisId);
            ViewData["KlientasId"] = new SelectList(_context.Set<Klientas>(), "KlientasId", "KlientasId", gedimas.KlientasId);
            return View(gedimas);
        }

        // GET: Gedimas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gedimas = await _context.Gedimas.FindAsync(id);
            if (gedimas == null)
            {
                return NotFound();
            }
            ViewData["DviratisId"] = new SelectList(_context.Dviratis, "DviratisId", "DviratisId", gedimas.DviratisId);
            ViewData["KlientasId"] = new SelectList(_context.Set<Klientas>(), "KlientasId", "KlientasId", gedimas.KlientasId);
            return View(gedimas);
        }

        // POST: Gedimas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GedimasId,registravimoLaikas,Apibudinimas,DviratisId,KlientasId")] Gedimas gedimas)
        {
            if (id != gedimas.GedimasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gedimas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GedimasExists(gedimas.GedimasId))
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
            ViewData["DviratisId"] = new SelectList(_context.Dviratis, "DviratisId", "DviratisId", gedimas.DviratisId);
            ViewData["KlientasId"] = new SelectList(_context.Set<Klientas>(), "KlientasId", "KlientasId", gedimas.KlientasId);
            return View(gedimas);
        }

        // GET: Gedimas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gedimas = await _context.Gedimas
                .Include(g => g.Dviratis)
                .Include(g => g.Klientas)
                .FirstOrDefaultAsync(m => m.GedimasId == id);
            if (gedimas == null)
            {
                return NotFound();
            }

            return View(gedimas);
        }

        // POST: Gedimas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gedimas = await _context.Gedimas.FindAsync(id);
            _context.Gedimas.Remove(gedimas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GedimasExists(int id)
        {
            return _context.Gedimas.Any(e => e.GedimasId == id);
        }
    }
}
