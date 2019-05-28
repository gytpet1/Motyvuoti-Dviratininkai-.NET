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
    public class ApmokejimasController : Controller
    {
        private readonly Motyvuoti_DviratininkaiContext _context;

        public ApmokejimasController(Motyvuoti_DviratininkaiContext context)
        {
            _context = context;
        }

        // GET: Apmokejimas
        public async Task<IActionResult> Index()
        {
            var motyvuoti_DviratininkaiContext = _context.Apmokejimas.Include(a => a.Kelione);
            return View(await motyvuoti_DviratininkaiContext.ToListAsync());
        }

        public async Task<IActionResult> ParodytiSekmingaApmokejima(int? id)
        {
            var motyvuoti_DviratininkaiContext = _context.Kelione.Where(d => d.KelioneId == id).Include(k => k.Dviratis).Include(k => k.Klientas).First();
             var motyvuoti_DviratininkaiContext1 = _context.Apmokejimas.Where(a => a.KelioneId == id).Include(a => a.Kelione).ThenInclude(a => a.Dviratis).First();
            motyvuoti_DviratininkaiContext1.arApmoketas = true;

            _context.Update(motyvuoti_DviratininkaiContext1);
            await _context.SaveChangesAsync();
            return View();
        }

        public async Task<IActionResult> Apmoketi(int? id)
        {
            var motyvuoti_DviratininkaiContext = _context.Kelione.Where(d => d.KelioneId == id).Include(k => k.Dviratis).Include(k => k.Klientas).First();
            // var motyvuoti_DviratininkaiContext = _context.Apmokejimas.Where(a => a.KelioneId == id).Include(a => a.Kelione).ThenInclude(a => a.Dviratis).First();
            var Apmokejimas = new Apmokejimas
            {
                arApmoketas = false,
                Data = motyvuoti_DviratininkaiContext.kelionesPabaiga,
                KelioneId = motyvuoti_DviratininkaiContext.KelioneId,
                Suma = float.Parse(motyvuoti_DviratininkaiContext.kelionesPabaiga.Subtract(motyvuoti_DviratininkaiContext.kelionesPradzia).Multiply(motyvuoti_DviratininkaiContext.Dviratis.nuomosKaina).TotalHours.ToString().Substring(0, 4).Replace(':', ',')),
        };
            _context.Add(Apmokejimas);
            await _context.SaveChangesAsync();
            return View(motyvuoti_DviratininkaiContext);
        }

        // GET: Apmokejimas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apmokejimas = await _context.Apmokejimas
                .Include(a => a.Kelione)
                .FirstOrDefaultAsync(m => m.ApmokejimasId == id);
            if (apmokejimas == null)
            {
                return NotFound();
            }
            
            return View(apmokejimas);
        }

        // GET: Apmokejimas/Create
        public IActionResult Create()
        {
            ViewData["KelioneId"] = new SelectList(_context.Kelione, "KelioneId", "KelioneId");
            return View();
        }

        // POST: Apmokejimas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApmokejimasId,Data,Suma,arApmoketas,KelioneId")] Apmokejimas apmokejimas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apmokejimas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KelioneId"] = new SelectList(_context.Kelione, "KelioneId", "KelioneId", apmokejimas.KelioneId);
            return View(apmokejimas);
        }

        // GET: Apmokejimas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apmokejimas = await _context.Apmokejimas.FindAsync(id);
            if (apmokejimas == null)
            {
                return NotFound();
            }
            ViewData["KelioneId"] = new SelectList(_context.Kelione, "KelioneId", "KelioneId", apmokejimas.KelioneId);
            return View(apmokejimas);
        }

        // POST: Apmokejimas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApmokejimasId,Data,Suma,arApmoketas,KelioneId")] Apmokejimas apmokejimas)
        {
            if (id != apmokejimas.ApmokejimasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apmokejimas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApmokejimasExists(apmokejimas.ApmokejimasId))
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
            ViewData["KelioneId"] = new SelectList(_context.Kelione, "KelioneId", "KelioneId", apmokejimas.KelioneId);
            return View(apmokejimas);
        }

        // GET: Apmokejimas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apmokejimas = await _context.Apmokejimas
                .Include(a => a.Kelione)
                .FirstOrDefaultAsync(m => m.ApmokejimasId == id);
            if (apmokejimas == null)
            {
                return NotFound();
            }

            return View(apmokejimas);
        }

        // POST: Apmokejimas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apmokejimas = await _context.Apmokejimas.FindAsync(id);
            _context.Apmokejimas.Remove(apmokejimas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApmokejimasExists(int id)
        {
            return _context.Apmokejimas.Any(e => e.ApmokejimasId == id);
        }
    }
}
