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
    public class TaskasController : Controller
    {
        private readonly Motyvuoti_DviratininkaiContext _context;

        public TaskasController(Motyvuoti_DviratininkaiContext context)
        {
            _context = context;
        }

        // GET: Taskas
        public async Task<IActionResult> Index()
        {
            var motyvuoti_DviratininkaiContext = _context.Taskas.Include(t => t.Marsrutas);
            return View(await motyvuoti_DviratininkaiContext.ToListAsync());
        }

        // GET: Taskas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskas = await _context.Taskas
                .Include(t => t.Marsrutas)
                .FirstOrDefaultAsync(m => m.TaskasId == id);
            if (taskas == null)
            {
                return NotFound();
            }

            return View(taskas);
        }

        // GET: Taskas/Create
        public IActionResult Create()
        {
            ViewData["MarsrutasId"] = new SelectList(_context.Marsrutas, "MarsrutasId", "MarsrutasId");
            return View();
        }

        // POST: Taskas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskasId,Longtitude,Latitude,MarsrutasId")] Taskas taskas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarsrutasId"] = new SelectList(_context.Marsrutas, "MarsrutasId", "MarsrutasId", taskas.MarsrutasId);
            return View(taskas);
        }

        // GET: Taskas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskas = await _context.Taskas.FindAsync(id);
            if (taskas == null)
            {
                return NotFound();
            }
            ViewData["MarsrutasId"] = new SelectList(_context.Marsrutas, "MarsrutasId", "MarsrutasId", taskas.MarsrutasId);
            return View(taskas);
        }

        // POST: Taskas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskasId,Longtitude,Latitude,MarsrutasId")] Taskas taskas)
        {
            if (id != taskas.TaskasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskasExists(taskas.TaskasId))
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
            ViewData["MarsrutasId"] = new SelectList(_context.Marsrutas, "MarsrutasId", "MarsrutasId", taskas.MarsrutasId);
            return View(taskas);
        }

        // GET: Taskas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskas = await _context.Taskas
                .Include(t => t.Marsrutas)
                .FirstOrDefaultAsync(m => m.TaskasId == id);
            if (taskas == null)
            {
                return NotFound();
            }

            return View(taskas);
        }

        // POST: Taskas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskas = await _context.Taskas.FindAsync(id);
            _context.Taskas.Remove(taskas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskasExists(int id)
        {
            return _context.Taskas.Any(e => e.TaskasId == id);
        }
    }
}
