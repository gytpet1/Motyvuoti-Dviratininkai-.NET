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
    public class KelionesController : Controller
    {

        private readonly Motyvuoti_DviratininkaiContext _context;

        public KelionesController(Motyvuoti_DviratininkaiContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Uzbaigti(int? id)
        {

            //reik dar pakeitimu
             var motyvuoti_DviratininkaiContext = _context.Kelione.Where(d => d.KelioneId == id).Include(k => k.Dviratis).Include(k => k.Klientas).First();
            motyvuoti_DviratininkaiContext.Dviratis.DviracioBusenaId = 2;
            motyvuoti_DviratininkaiContext.kelionesPabaiga = DateTime.UtcNow;
            _context.Update(motyvuoti_DviratininkaiContext);
            await _context.SaveChangesAsync();

            return RedirectToAction("Apmoketi","Apmokejimas",new { id = id });
        }
            public async Task<IActionResult> Nuomoti(int? id)
        {
             
            Kelione k = new Kelione
            {
                kelionesPradzia = DateTime.UtcNow,
                kelionesTrukme = 0,
                DviratisId = _context.Dviratis.Where(d => d.DviratisId == id).Select(d => d.DviratisId).First(),
                kelionesPabaiga = DateTime.UtcNow,
                pradziosAdresas = _context.Dviratis.Where(d => d.DviratisId == id).Select(d => d.Aikstele.Adresas).First(),
                Dviratis = _context.Dviratis.Where(d => d.DviratisId == id).Select(d => d).First(),
                nuvaziuotasAtstumas = 1.5f,
                KlientasId = 1
            };

            var Dviratis = _context.Dviratis.Where(d => d.DviratisId == id).Select(d => d).First();
            Dviratis.DviracioBusenaId = 1;
            _context.Update(Dviratis);
            _context.Add(k);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { id = k.KelioneId });
        }

        // GET: Keliones
        public async Task<IActionResult> Index(int? id)
        {
            var motyvuoti_DviratininkaiContext = _context.Kelione.Where(d => d.KelioneId == id).Include(k => k.Dviratis).Include(k => k.Klientas).First();
            return View("Nuomoti",motyvuoti_DviratininkaiContext);
        }

        // GET: Keliones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kelione = await _context.Kelione
                .Include(k => k.Dviratis)
                .Include(k => k.Klientas)
                .FirstOrDefaultAsync(m => m.KelioneId == id);
            if (kelione == null)
            {
                return NotFound();
            }

            return View(kelione);
        }
        public async Task<IActionResult> NuvaziotiKilometrai()
        {
            var motyvuoti_DviratininkaiContext = _context.Kelione;
    
            return View(motyvuoti_DviratininkaiContext);


        }

        // GET: Keliones/Create
        public IActionResult Create()
        {
            ViewData["DviratisId"] = new SelectList(_context.Dviratis, "DviratisId", "DviratisId");
            ViewData["KlientasId"] = new SelectList(_context.Klientas, "KlientasId", "KlientasId");
            return View();
        }

        // POST: Keliones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KelioneId,kelionesPradzia,kelionesPabaiga,nuvaziuotasAtstumas,kelionesTrukme,pradziosAdresas,pabaigosAdresas,DviratisId,KlientasId")] Kelione kelione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kelione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DviratisId"] = new SelectList(_context.Dviratis, "DviratisId", "DviratisId", kelione.DviratisId);
            ViewData["KlientasId"] = new SelectList(_context.Klientas, "KlientasId", "KlientasId", kelione.KlientasId);
            return View(kelione);
        }

        // GET: Keliones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kelione = await _context.Kelione.FindAsync(id);
            if (kelione == null)
            {
                return NotFound();
            }
            ViewData["DviratisId"] = new SelectList(_context.Dviratis, "DviratisId", "DviratisId", kelione.DviratisId);
            ViewData["KlientasId"] = new SelectList(_context.Klientas, "KlientasId", "KlientasId", kelione.KlientasId);
            return View(kelione);
        }

        // POST: Keliones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KelioneId,kelionesPradzia,kelionesPabaiga,nuvaziuotasAtstumas,kelionesTrukme,pradziosAdresas,pabaigosAdresas,DviratisId,KlientasId")] Kelione kelione)
        {
            if (id != kelione.KelioneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kelione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KelioneExists(kelione.KelioneId))
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
            ViewData["DviratisId"] = new SelectList(_context.Dviratis, "DviratisId", "DviratisId", kelione.DviratisId);
            ViewData["KlientasId"] = new SelectList(_context.Klientas, "KlientasId", "KlientasId", kelione.KlientasId);
            return View(kelione);
        }

        // GET: Keliones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kelione = await _context.Kelione
                .Include(k => k.Dviratis)
                .Include(k => k.Klientas)
                .FirstOrDefaultAsync(m => m.KelioneId == id);
            if (kelione == null)
            {
                return NotFound();
            }

            return View(kelione);
        }

        // POST: Keliones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kelione = await _context.Kelione.FindAsync(id);
            _context.Kelione.Remove(kelione);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KelioneExists(int id)
        {
            return _context.Kelione.Any(e => e.KelioneId == id);
        }
    }
}
