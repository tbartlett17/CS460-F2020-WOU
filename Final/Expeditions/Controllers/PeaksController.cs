using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Expeditions.Models;

namespace Expeditions.Controllers
{
    public class PeaksController : Controller
    {
        private readonly ExpeditionsDbContext _context;

        public PeaksController(ExpeditionsDbContext context)
        {
            _context = context;
        }

        // GET: Peaks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Peaks.ToListAsync());
        }

        // GET: Peaks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peak = await _context.Peaks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peak == null)
            {
                return NotFound();
            }

            return View(peak);
        }

        // GET: Peaks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Peaks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Height,ClimbingStatus,FirstAscentYear")] Peak peak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peak);
        }

        // GET: Peaks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peak = await _context.Peaks.FindAsync(id);
            if (peak == null)
            {
                return NotFound();
            }
            return View(peak);
        }

        // POST: Peaks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Height,ClimbingStatus,FirstAscentYear")] Peak peak)
        {
            if (id != peak.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeakExists(peak.Id))
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
            return View(peak);
        }

        // GET: Peaks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peak = await _context.Peaks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peak == null)
            {
                return NotFound();
            }

            return View(peak);
        }

        // POST: Peaks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peak = await _context.Peaks.FindAsync(id);
            _context.Peaks.Remove(peak);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeakExists(int id)
        {
            return _context.Peaks.Any(e => e.Id == id);
        }
    }
}
