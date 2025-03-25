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
    public class LineMastersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LineMastersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LineMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.LineMasters.ToListAsync());
        }

        // GET: LineMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineMaster = await _context.LineMasters
                .FirstOrDefaultAsync(m => m.LineId == id);
            if (lineMaster == null)
            {
                return NotFound();
            }

            return View(lineMaster);
        }

        // GET: LineMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LineMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LineId,LineName")] LineMaster lineMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lineMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lineMaster);
        }

        // GET: LineMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineMaster = await _context.LineMasters.FindAsync(id);
            if (lineMaster == null)
            {
                return NotFound();
            }
            return View(lineMaster);
        }

        // POST: LineMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LineId,LineName")] LineMaster lineMaster)
        {
            if (id != lineMaster.LineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lineMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineMasterExists(lineMaster.LineId))
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
            return View(lineMaster);
        }

        // GET: LineMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineMaster = await _context.LineMasters
                .FirstOrDefaultAsync(m => m.LineId == id);
            if (lineMaster == null)
            {
                return NotFound();
            }

            return View(lineMaster);
        }

        // POST: LineMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lineMaster = await _context.LineMasters.FindAsync(id);
            if (lineMaster != null)
            {
                _context.LineMasters.Remove(lineMaster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LineMasterExists(int id)
        {
            return _context.LineMasters.Any(e => e.LineId == id);
        }
    }
}
