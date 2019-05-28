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
    public class DviratisController : Controller
    {
        private readonly Motyvuoti_DviratininkaiContext _context;

        public DviratisController(Motyvuoti_DviratininkaiContext context)
        {
            _context = context;
        }

        // GET: Dviratis
        public async Task<IActionResult> Index()
        {
            var motyvuoti_DviratininkaiContext = _context.Dviratis.Include(d => d.Aikstele).Include(d => d.Busena);
            return View(await motyvuoti_DviratininkaiContext.ToListAsync());
        }

     

        public async Task<IActionResult> NuomosDetales(int? id)
        {
          if (id == null)
            {
                return NotFound();
            }

            var dviratis = await _context.Dviratis
                .Include(d => d.Aikstele)
                .Include(d => d.Busena)
                .FirstOrDefaultAsync(m => m.DviratisId == id);
            if (dviratis == null)
            {
                return NotFound();
            }
            
            return View(dviratis);
        }

        // GET: Dviratis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dviratis = await _context.Dviratis
                .Include(d => d.Aikstele)
                .Include(d => d.Busena)
                .FirstOrDefaultAsync(m => m.DviratisId == id);
            if (dviratis == null)
            {
                return NotFound();
            }
            
            return View(dviratis);
        }

        // GET: Dviratis/Create
        public IActionResult Create()
        {
            ViewData["AiksteleId"] = new SelectList(_context.Aikstele, "AiksteleId", "AiksteleId");
            ViewData["DviracioBusenaId"] = new SelectList(_context.Set<DviracioBusena>(), "DviracioBusenaId", "DviracioBusenaId");
            return View();
        }

        // POST: Dviratis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DviratisId,Gamintojas,Tipas,nuomosKaina,DviracioBusenaId,AiksteleId")] Dviratis dviratis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dviratis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AiksteleId"] = new SelectList(_context.Aikstele, "AiksteleId", "AiksteleId", dviratis.AiksteleId);
            ViewData["DviracioBusenaId"] = new SelectList(_context.Set<DviracioBusena>(), "DviracioBusenaId", "DviracioBusenaId", dviratis.DviracioBusenaId);
            return View(dviratis);
        }

        // GET: Dviratis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dviratis = await _context.Dviratis.FindAsync(id);
            if (dviratis == null)
            {
                return NotFound();
            }
            ViewData["AiksteleId"] = new SelectList(_context.Aikstele, "AiksteleId", "AiksteleId", dviratis.AiksteleId);
            ViewData["DviracioBusenaId"] = new SelectList(_context.Set<DviracioBusena>(), "DviracioBusenaId", "DviracioBusenaId", dviratis.DviracioBusenaId);
            return View(dviratis);
        }

        // POST: Dviratis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DviratisId,Gamintojas,Tipas,nuomosKaina,DviracioBusenaId,AiksteleId")] Dviratis dviratis)
        {
            if (id != dviratis.DviratisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dviratis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DviratisExists(dviratis.DviratisId))
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
            ViewData["AiksteleId"] = new SelectList(_context.Aikstele, "AiksteleId", "AiksteleId", dviratis.AiksteleId);
            ViewData["DviracioBusenaId"] = new SelectList(_context.Set<DviracioBusena>(), "DviracioBusenaId", "DviracioBusenaId", dviratis.DviracioBusenaId);
            return View(dviratis);
        }

        // GET: Dviratis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dviratis = await _context.Dviratis
                .Include(d => d.Aikstele)
                .Include(d => d.Busena)
                .FirstOrDefaultAsync(m => m.DviratisId == id);
            if (dviratis == null)
            {
                return NotFound();
            }

            return View(dviratis);
        }

        // POST: Dviratis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dviratis = await _context.Dviratis.FindAsync(id);
            _context.Dviratis.Remove(dviratis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DviratisExists(int id)
        {
            return _context.Dviratis.Any(e => e.DviratisId == id);
        }
    }
}
