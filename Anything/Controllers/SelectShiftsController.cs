using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Anything.Data;
using Anything.Models;

namespace Anything.Controllers
{
    public class SelectShiftsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SelectShiftsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SelectShifts
        public async Task<IActionResult> Index()
        {
            return View(await _context.SelectShifts.ToListAsync());
        }

        // GET: SelectShifts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selectShift = await _context.SelectShifts
                .FirstOrDefaultAsync(m => m.ShiftId == id);
            if (selectShift == null)
            {
                return NotFound();
            }

            return View(selectShift);
        }

        // GET: SelectShifts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SelectShifts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShiftId,ShiftName")] SelectShift selectShift)
        {
            if (ModelState.IsValid)
            {
                _context.Add(selectShift);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(selectShift);
        }

        // GET: SelectShifts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selectShift = await _context.SelectShifts.FindAsync(id);
            if (selectShift == null)
            {
                return NotFound();
            }
            return View(selectShift);
        }

        // POST: SelectShifts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShiftId,ShiftName")] SelectShift selectShift)
        {
            if (id != selectShift.ShiftId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(selectShift);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SelectShiftExists(selectShift.ShiftId))
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
            return View(selectShift);
        }

        // GET: SelectShifts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selectShift = await _context.SelectShifts
                .FirstOrDefaultAsync(m => m.ShiftId == id);
            if (selectShift == null)
            {
                return NotFound();
            }

            return View(selectShift);
        }

        // POST: SelectShifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var selectShift = await _context.SelectShifts.FindAsync(id);
            if (selectShift != null)
            {
                _context.SelectShifts.Remove(selectShift);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SelectShiftExists(int id)
        {
            return _context.SelectShifts.Any(e => e.ShiftId == id);
        }
    }
}
