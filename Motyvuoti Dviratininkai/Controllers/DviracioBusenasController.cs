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
    public class DviracioBusenasController : Controller
    {
        private readonly Motyvuoti_DviratininkaiContext _context;

        public DviracioBusenasController(Motyvuoti_DviratininkaiContext context)
        {
            _context = context;
        }

        // GET: DviracioBusenas
        public async Task<IActionResult> Index()
        {
            return View(await _context.DviracioBusena.ToListAsync());
        }

        // GET: DviracioBusenas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dviracioBusena = await _context.DviracioBusena
                .FirstOrDefaultAsync(m => m.DviracioBusenaId == id);
            if (dviracioBusena == null)
            {
                return NotFound();
            }

            return View(dviracioBusena);
        }

        // GET: DviracioBusenas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DviracioBusenas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DviracioBusenaId,Busena")] DviracioBusena dviracioBusena)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dviracioBusena);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dviracioBusena);
        }

        // GET: DviracioBusenas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dviracioBusena = await _context.DviracioBusena.FindAsync(id);
            if (dviracioBusena == null)
            {
                return NotFound();
            }
            return View(dviracioBusena);
        }

        // POST: DviracioBusenas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DviracioBusenaId,Busena")] DviracioBusena dviracioBusena)
        {
            if (id != dviracioBusena.DviracioBusenaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dviracioBusena);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DviracioBusenaExists(dviracioBusena.DviracioBusenaId))
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
            return View(dviracioBusena);
        }

        // GET: DviracioBusenas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dviracioBusena = await _context.DviracioBusena
                .FirstOrDefaultAsync(m => m.DviracioBusenaId == id);
            if (dviracioBusena == null)
            {
                return NotFound();
            }

            return View(dviracioBusena);
        }

        // POST: DviracioBusenas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dviracioBusena = await _context.DviracioBusena.FindAsync(id);
            _context.DviracioBusena.Remove(dviracioBusena);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DviracioBusenaExists(int id)
        {
            return _context.DviracioBusena.Any(e => e.DviracioBusenaId == id);
        }
    }
}
