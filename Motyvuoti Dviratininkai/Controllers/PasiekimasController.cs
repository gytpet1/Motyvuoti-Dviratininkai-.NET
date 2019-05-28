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
    public class PasiekimasController : Controller
    {
        private readonly Motyvuoti_DviratininkaiContext _context;

        public PasiekimasController(Motyvuoti_DviratininkaiContext context)
        {
            _context = context;
        }

        // GET: Pasiekimas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pasiekimas.ToListAsync());
        }

        // GET: Pasiekimas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasiekimas = await _context.Pasiekimas
                .FirstOrDefaultAsync(m => m.PasiekimasId == id);
            if (pasiekimas == null)
            {
                return NotFound();
            }

            return View(pasiekimas);
        }

        // GET: Pasiekimas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pasiekimas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PasiekimasId,Pavadinimas,Kilometrai")] Pasiekimas pasiekimas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pasiekimas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pasiekimas);
        }

        // GET: Pasiekimas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasiekimas = await _context.Pasiekimas.FindAsync(id);
            if (pasiekimas == null)
            {
                return NotFound();
            }
            return View(pasiekimas);
        }

        // POST: Pasiekimas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PasiekimasId,Pavadinimas,Kilometrai")] Pasiekimas pasiekimas)
        {
            if (id != pasiekimas.PasiekimasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pasiekimas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PasiekimasExists(pasiekimas.PasiekimasId))
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
            return View(pasiekimas);
        }

        // GET: Pasiekimas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasiekimas = await _context.Pasiekimas
                .FirstOrDefaultAsync(m => m.PasiekimasId == id);
            if (pasiekimas == null)
            {
                return NotFound();
            }

            return View(pasiekimas);
        }

        // POST: Pasiekimas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pasiekimas = await _context.Pasiekimas.FindAsync(id);
            _context.Pasiekimas.Remove(pasiekimas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PasiekimasExists(int id)
        {
            return _context.Pasiekimas.Any(e => e.PasiekimasId == id);
        }
    }
}
