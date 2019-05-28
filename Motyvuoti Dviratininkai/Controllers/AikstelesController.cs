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
    public class AikstelesController : Controller
    {
        private readonly Motyvuoti_DviratininkaiContext _context;

        public AikstelesController(Motyvuoti_DviratininkaiContext context)
        {
            _context = context;
        }

        // GET: Aiksteles
        public async Task<IActionResult> Index()
        {

            //reikia dar paduoti dviraciu busena !!!!!!!!
            //bbz kaip sujungti visas lenteles !

            var a = _context.Dviratis.Include(d => d.Aikstele).Include(d => d.Busena).Include(d => d.Aikstele.Dviraciai);

          //  var motyvuoti_DviratininkaiContext1 = _context.Aikstele.Include(d => d.Dviraciai).Include(d => d.Darbuotojas);
            //var motyvuoti_DviratininkaiContext = motyvuoti_DviratininkaiContext1.Include(d => d.Darbuotojas);
          //  var a = motyvuoti_DviratininkaiContext1.ToList();
          //  foreach(var b in motyvuoti_DviratininkaiContext1)
           // {
               
           // }



            return View(await a.ToListAsync());
        }

        // GET: Aiksteles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aikstele = await _context.Aikstele
                .Include(a => a.Darbuotojas)
                .FirstOrDefaultAsync(m => m.AiksteleId == id);
            if (aikstele == null)
            {
                return NotFound();
            }

            return View(aikstele);
        }

        // GET: Aiksteles/Create
        public IActionResult Create()
        {
            ViewData["DarbuotojasId"] = new SelectList(_context.Darbuotojas, "DarbuotojasId", "DarbuotojasId");
            return View();
        }

        // POST: Aiksteles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AiksteleId,Adresas,vietuSkaicius,laisvuVietuSkacius,Latitude,Longtitude,DarbuotojasId")] Aikstele aikstele)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aikstele);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DarbuotojasId"] = new SelectList(_context.Darbuotojas, "DarbuotojasId", "DarbuotojasId", aikstele.DarbuotojasId);
            return View(aikstele);
        }

        // GET: Aiksteles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aikstele = await _context.Aikstele.FindAsync(id);
            if (aikstele == null)
            {
                return NotFound();
            }
            ViewData["DarbuotojasId"] = new SelectList(_context.Darbuotojas, "DarbuotojasId", "DarbuotojasId", aikstele.DarbuotojasId);
            return View(aikstele);
        }

        // POST: Aiksteles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AiksteleId,Adresas,vietuSkaicius,laisvuVietuSkacius,Latitude,Longtitude,DarbuotojasId")] Aikstele aikstele)
        {
            if (id != aikstele.AiksteleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aikstele);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AiksteleExists(aikstele.AiksteleId))
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
            ViewData["DarbuotojasId"] = new SelectList(_context.Darbuotojas, "DarbuotojasId", "DarbuotojasId", aikstele.DarbuotojasId);
            return View(aikstele);
        }

        // GET: Aiksteles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aikstele = await _context.Aikstele
                .Include(a => a.Darbuotojas)
                .FirstOrDefaultAsync(m => m.AiksteleId == id);
            if (aikstele == null)
            {
                return NotFound();
            }

            return View(aikstele);
        }

        // POST: Aiksteles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aikstele = await _context.Aikstele.FindAsync(id);
            _context.Aikstele.Remove(aikstele);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AiksteleExists(int id)
        {
            return _context.Aikstele.Any(e => e.AiksteleId == id);
        }
    }
}
