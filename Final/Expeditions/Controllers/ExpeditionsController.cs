using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Expeditions.Models;
using System.Diagnostics;

namespace Expeditions.Controllers
{
    public class ExpeditionsController : Controller
    {
        private readonly ExpeditionsDbContext _context;

        public ExpeditionsController(ExpeditionsDbContext context)
        {
            _context = context;
        }

        // GET: Expeditions
        public async Task<IActionResult> Index()
        {
            var expeditionsDbContext = _context.Expeditions.Include(e => e.Peak).Include(e => e.TrekkingAgency).OrderByDescending(d => d.StartDate).Take(50);
            return View(await expeditionsDbContext.ToListAsync());
        }

        // GET: Expeditions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expedition = await _context.Expeditions
                .Include(e => e.Peak)
                .Include(e => e.TrekkingAgency)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expedition == null)
            {
                return NotFound();
            }

            return View(expedition);
        }

        // GET: Expeditions/Create
        public IActionResult Create()
        {
            ViewData["PeakId"] = new SelectList(_context.Peaks.OrderBy(p => p.Name), "Id", "Name");
            ViewData["TrekkingAgencyId"] = new SelectList(_context.TrekkingAgencies.OrderBy(ta => ta.Name), "Id", "Name");
            return View();
        }

        // POST: Expeditions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,TerminationReason,OxygenUsed,PeakId,TrekkingAgencyId")] Expedition expedition)
        {
            if (ModelState.IsValid)
            {
                if (expedition.StartDate.Value.Month >= 3 && expedition.StartDate.Value.Month <= 5)
                {
                    expedition.Season = "Spring";
                    expedition.Year = expedition.StartDate.Value.Year;
                }
                else if (expedition.StartDate.Value.Month >= 6 && expedition.StartDate.Value.Month <= 8)
                {
                    expedition.Season = "Summer";
                    expedition.Year = expedition.StartDate.Value.Year;
                }
                else if (expedition.StartDate.Value.Month >= 9 && expedition.StartDate.Value.Month <= 11)
                {
                    expedition.Season = "Fall";
                    expedition.Year = expedition.StartDate.Value.Year;
                }
                else if (expedition.StartDate.Value.Month == 12)
                {
                    expedition.Season = "Winter";
                    expedition.Year = expedition.StartDate.Value.Year;
                }
                else if (expedition.StartDate.Value.Month == 1 || expedition.StartDate.Value.Month == 2)
                {
                    expedition.Season = "Winter";
                    expedition.Year = expedition.StartDate.Value.Year - 1;
                }
                else
                {
                    Debug.WriteLine("SOMETHING SUPER WRONG HAPPENED");
                }

                    _context.Add(expedition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PeakId"] = new SelectList(_context.Peaks, "Id", "Name", expedition.PeakId);
            ViewData["TrekkingAgencyId"] = new SelectList(_context.TrekkingAgencies, "Id", "Name", expedition.TrekkingAgencyId);
            return View(expedition);
        }

        // GET: Expeditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expedition = await _context.Expeditions.FindAsync(id);
            if (expedition == null)
            {
                return NotFound();
            }
            ViewData["PeakId"] = new SelectList(_context.Peaks, "Id", "Name", expedition.PeakId);
            ViewData["TrekkingAgencyId"] = new SelectList(_context.TrekkingAgencies, "Id", "Id", expedition.TrekkingAgencyId);
            return View(expedition);
        }

        // POST: Expeditions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Season,Year,StartDate,TerminationReason,OxygenUsed,PeakId,TrekkingAgencyId")] Expedition expedition)
        {
            if (id != expedition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expedition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpeditionExists(expedition.Id))
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
            ViewData["PeakId"] = new SelectList(_context.Peaks, "Id", "Name", expedition.PeakId);
            ViewData["TrekkingAgencyId"] = new SelectList(_context.TrekkingAgencies, "Id", "Id", expedition.TrekkingAgencyId);
            return View(expedition);
        }

        // GET: Expeditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expedition = await _context.Expeditions
                .Include(e => e.Peak)
                .Include(e => e.TrekkingAgency)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expedition == null)
            {
                return NotFound();
            }

            return View(expedition);
        }

        // POST: Expeditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expedition = await _context.Expeditions.FindAsync(id);
            _context.Expeditions.Remove(expedition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpeditionExists(int id)
        {
            return _context.Expeditions.Any(e => e.Id == id);
        }
    }
}
