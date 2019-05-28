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
    public class MokejimoKortelesController : Controller
    {
        private readonly Motyvuoti_DviratininkaiContext _context;

        public MokejimoKortelesController(Motyvuoti_DviratininkaiContext context)
        {
            _context = context;
        }

        // GET: MokejimoKorteles
        public async Task<IActionResult> Index()
        {
            var motyvuoti_DviratininkaiContext = _context.MokejimoKortele.Include(m => m.Klientas);
            return View(await motyvuoti_DviratininkaiContext.ToListAsync());
        }

        // GET: MokejimoKorteles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mokejimoKortele = await _context.MokejimoKortele
                .Include(m => m.Klientas)
                .FirstOrDefaultAsync(m => m.MokejimoKorteleId == id);
            if (mokejimoKortele == null)
            {
                return NotFound();
            }

            return View(mokejimoKortele);
        }

        // GET: MokejimoKorteles/Create
        public IActionResult Create()
        {
            ViewData["KlientasId"] = new SelectList(_context.Klientas, "KlientasId", "KlientasId");
            return View();
        }

        // POST: MokejimoKorteles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MokejimoKorteleId,Numeris,Savininkas,KlientasId")] MokejimoKortele mokejimoKortele)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mokejimoKortele);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlientasId"] = new SelectList(_context.Klientas, "KlientasId", "KlientasId", mokejimoKortele.KlientasId);
            return View(mokejimoKortele);
        }

        // GET: MokejimoKorteles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mokejimoKortele = await _context.MokejimoKortele.FindAsync(id);
            if (mokejimoKortele == null)
            {
                return NotFound();
            }
            ViewData["KlientasId"] = new SelectList(_context.Klientas, "KlientasId", "KlientasId", mokejimoKortele.KlientasId);
            return View(mokejimoKortele);
        }

        // POST: MokejimoKorteles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MokejimoKorteleId,Numeris,Savininkas,KlientasId")] MokejimoKortele mokejimoKortele)
        {
            if (id != mokejimoKortele.MokejimoKorteleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mokejimoKortele);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MokejimoKorteleExists(mokejimoKortele.MokejimoKorteleId))
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
            ViewData["KlientasId"] = new SelectList(_context.Klientas, "KlientasId", "KlientasId", mokejimoKortele.KlientasId);
            return View(mokejimoKortele);
        }

        // GET: MokejimoKorteles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mokejimoKortele = await _context.MokejimoKortele
                .Include(m => m.Klientas)
                .FirstOrDefaultAsync(m => m.MokejimoKorteleId == id);
            if (mokejimoKortele == null)
            {
                return NotFound();
            }

            return View(mokejimoKortele);
        }

        // POST: MokejimoKorteles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mokejimoKortele = await _context.MokejimoKortele.FindAsync(id);
            _context.MokejimoKortele.Remove(mokejimoKortele);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MokejimoKorteleExists(int id)
        {
            return _context.MokejimoKortele.Any(e => e.MokejimoKorteleId == id);
        }
    }
}
