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
    public class KlientoPasiekimaisController : Controller
    {
        private readonly Motyvuoti_DviratininkaiContext _context;

        public KlientoPasiekimaisController(Motyvuoti_DviratininkaiContext context)
        {
            _context = context;
        }

        // GET: KlientoPasiekimais
        public async Task<IActionResult> Index()
        {
            var motyvuoti_DviratininkaiContext = _context.KlientoPasiekimai.Include(k => k.Klientas).Include(k => k.Pasiekimas);
            return View(await motyvuoti_DviratininkaiContext.ToListAsync());
        }

        // GET: KlientoPasiekimais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klientoPasiekimai = await _context.KlientoPasiekimai
                .Include(k => k.Klientas)
                .Include(k => k.Pasiekimas)
                .FirstOrDefaultAsync(m => m.KlientoPasiekimaiId == id);
            if (klientoPasiekimai == null)
            {
                return NotFound();
            }

            return View(klientoPasiekimai);
        }

        // GET: KlientoPasiekimais/Create
        public IActionResult Create()
        {
            ViewData["KlientasId"] = new SelectList(_context.Klientas, "KlientasId", "KlientasId");
            ViewData["PasiekimasId"] = new SelectList(_context.Set<Pasiekimas>(), "PasiekimasId", "PasiekimasId");
            return View();
        }

        // POST: KlientoPasiekimais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KlientoPasiekimaiId,KlientasId,PasiekimasId")] KlientoPasiekimai klientoPasiekimai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klientoPasiekimai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlientasId"] = new SelectList(_context.Klientas, "KlientasId", "KlientasId", klientoPasiekimai.KlientasId);
            ViewData["PasiekimasId"] = new SelectList(_context.Set<Pasiekimas>(), "PasiekimasId", "PasiekimasId", klientoPasiekimai.PasiekimasId);
            return View(klientoPasiekimai);
        }

        // GET: KlientoPasiekimais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klientoPasiekimai = await _context.KlientoPasiekimai.FindAsync(id);
            if (klientoPasiekimai == null)
            {
                return NotFound();
            }
            ViewData["KlientasId"] = new SelectList(_context.Klientas, "KlientasId", "KlientasId", klientoPasiekimai.KlientasId);
            ViewData["PasiekimasId"] = new SelectList(_context.Set<Pasiekimas>(), "PasiekimasId", "PasiekimasId", klientoPasiekimai.PasiekimasId);
            return View(klientoPasiekimai);
        }

        // POST: KlientoPasiekimais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KlientoPasiekimaiId,KlientasId,PasiekimasId")] KlientoPasiekimai klientoPasiekimai)
        {
            if (id != klientoPasiekimai.KlientoPasiekimaiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klientoPasiekimai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlientoPasiekimaiExists(klientoPasiekimai.KlientoPasiekimaiId))
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
            ViewData["KlientasId"] = new SelectList(_context.Klientas, "KlientasId", "KlientasId", klientoPasiekimai.KlientasId);
            ViewData["PasiekimasId"] = new SelectList(_context.Set<Pasiekimas>(), "PasiekimasId", "PasiekimasId", klientoPasiekimai.PasiekimasId);
            return View(klientoPasiekimai);
        }

        // GET: KlientoPasiekimais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klientoPasiekimai = await _context.KlientoPasiekimai
                .Include(k => k.Klientas)
                .Include(k => k.Pasiekimas)
                .FirstOrDefaultAsync(m => m.KlientoPasiekimaiId == id);
            if (klientoPasiekimai == null)
            {
                return NotFound();
            }

            return View(klientoPasiekimai);
        }

        // POST: KlientoPasiekimais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klientoPasiekimai = await _context.KlientoPasiekimai.FindAsync(id);
            _context.KlientoPasiekimai.Remove(klientoPasiekimai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlientoPasiekimaiExists(int id)
        {
            return _context.KlientoPasiekimai.Any(e => e.KlientoPasiekimaiId == id);
        }
    }
}
